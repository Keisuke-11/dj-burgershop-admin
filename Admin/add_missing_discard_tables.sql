-- ============================================================
-- MISSING TABLES & STORED PROCEDURE FOR BATCH DISCARD
-- Run this in phpMyAdmin on the `dj_burgershop` database
-- ============================================================

USE `dj_burgershop`;

-- ============================================================
-- 1. CREATE batch_transactions (if it does not already exist)
--    Used by EditBatch.vb and the DiscardBatch stored procedure
-- ============================================================

CREATE TABLE IF NOT EXISTS `batch_transactions` (
  `TransactionID`   int(11)      NOT NULL AUTO_INCREMENT,
  `BatchID`         int(11)      NOT NULL,
  `TransactionType` varchar(50)  NOT NULL DEFAULT 'Adjustment',
                        -- Common values: 'Adjustment', 'Restock', 'Discard', 'Transfer'
  `QuantityChanged` decimal(12,3) NOT NULL DEFAULT 0.000,
  `StockBefore`     decimal(12,3) NOT NULL DEFAULT 0.000,
  `StockAfter`      decimal(12,3) NOT NULL DEFAULT 0.000,
  `ReferenceID`     varchar(50)  DEFAULT NULL,
  `PerformedBy`     varchar(100) DEFAULT 'System',
  `Reason`          varchar(255) DEFAULT NULL,
  `Notes`           text         DEFAULT NULL,
  `TransactionDate` datetime     NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`TransactionID`),
  KEY `fk_batchtrx_batch` (`BatchID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Add foreign-key only if inventory_batches exists (it should)
-- Uncomment the line below if you want strict referential integrity:
-- ALTER TABLE `batch_transactions`
--   ADD CONSTRAINT `fk_batchtrx_batch`
--   FOREIGN KEY (`BatchID`) REFERENCES `inventory_batches` (`BatchID`);


-- ============================================================
-- 2. CREATE DiscardBatch stored procedure (if it does not exist)
--    Called by BatchManagement.vb whenever a batch is discarded
-- ============================================================

DROP PROCEDURE IF EXISTS `DiscardBatch`;

DELIMITER $$

CREATE PROCEDURE `DiscardBatch` (
    IN `p_batch_id` INT,
    IN `p_reason`   VARCHAR(255),
    IN `p_notes`    TEXT
)
BEGIN
    DECLARE v_ingredient_id  INT          DEFAULT 0;
    DECLARE v_batch_number   VARCHAR(50)  DEFAULT '';
    DECLARE v_stock_before   DECIMAL(12,3) DEFAULT 0.000;
    DECLARE v_unit_type      VARCHAR(20)  DEFAULT '';
    DECLARE v_global_before  DECIMAL(12,3) DEFAULT 0.000;
    DECLARE v_global_after   DECIMAL(12,3) DEFAULT 0.000;

    -- 1. Read current batch data
    SELECT IngredientID, BatchNumber, StockQuantity, UnitType
    INTO   v_ingredient_id, v_batch_number, v_stock_before, v_unit_type
    FROM   inventory_batches
    WHERE  BatchID = p_batch_id;

    -- 2. Mark batch as Discarded and zero out its stock
    UPDATE inventory_batches
    SET    BatchStatus    = 'Discarded',
           StockQuantity  = 0,
           Notes          = CONCAT(IFNULL(Notes, ''), ' | Discarded: ', p_reason)
    WHERE  BatchID = p_batch_id;

    -- 3. Recalculate the ingredient's total stock from remaining active batches
    UPDATE ingredients
    SET    StockQuantity = (
               SELECT COALESCE(SUM(StockQuantity), 0)
               FROM   inventory_batches
               WHERE  IngredientID = v_ingredient_id
                 AND  BatchStatus  = 'Active'
           )
    WHERE  IngredientID = v_ingredient_id;

    -- 4. Log in batch_transactions (existing log table)
    INSERT INTO batch_transactions (
        BatchID, TransactionType, QuantityChanged,
        StockBefore, StockAfter, Reason, Notes, TransactionDate
    ) VALUES (
        p_batch_id, 'Discard', -v_stock_before,
        v_stock_before, 0, p_reason, p_notes, NOW()
    );

    -- 5. Get the last global stock level from inventory_movement for
    --    a clean StockBefore value, defaulting to ingredient stock if none found
    SELECT COALESCE(MAX(StockAfter), 0)
    INTO   v_global_before
    FROM   inventory_movement
    WHERE  IngredientID = v_ingredient_id;

    SET v_global_after = v_global_before - v_stock_before;
    IF v_global_after < 0 THEN
        SET v_global_after = 0;
    END IF;

    -- 6. Log in inventory_movement (new movement tracking table)
    INSERT INTO inventory_movement (
        IngredientID, BatchID, ChangeType,
        QuantityChanged, StockBefore, StockAfter,
        UnitType, Reason, Source, SourceName,
        ReferenceNumber, Notes, MovementDate
    ) VALUES (
        v_ingredient_id, p_batch_id, 'DISCARD',
        -v_stock_before, v_global_before, v_global_after,
        v_unit_type, p_reason, 'ADMIN', 'Admin User',
        v_batch_number, p_notes, NOW()
    );
END$$

DELIMITER ;

-- ============================================================
-- Verification — these should both return results after you run
-- the script above:
--   SHOW TABLES LIKE 'batch_transactions';
--   SHOW PROCEDURE STATUS WHERE Name = 'DiscardBatch';
-- ============================================================
