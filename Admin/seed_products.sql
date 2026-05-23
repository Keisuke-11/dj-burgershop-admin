-- ============================================================
-- DJ Burgershop - 10,000 Products Seed (ADD ONLY)
-- Generates realistic burger-shop menu item variations
-- across all 4 categories with proper Availability values.
-- ============================================================

USE dj_burgershop;
SET FOREIGN_KEY_CHECKS = 0;
SET autocommit = 0;

DROP PROCEDURE IF EXISTS seed_products;
DELIMITER //
CREATE PROCEDURE seed_products()
BEGIN
  DECLARE i        INT DEFAULT 1;
  DECLARE v_name   VARCHAR(100);
  DECLARE v_code   VARCHAR(50);
  DECLARE v_cat    VARCHAR(20);
  DECLARE v_price  DECIMAL(10,2);
  DECLARE v_avail  VARCHAR(20);
  DECLARE v_size   VARCHAR(10);
  DECLARE v_pop    VARCHAR(20);
  DECLARE v_spicy  VARCHAR(10);
  DECLARE v_meal   VARCHAR(20);
  DECLARE v_prep   INT;
  DECLARE v_desc   VARCHAR(255);
  DECLARE v_orders INT;

  -- Name-part arrays (by category)
  -- BURGERS: modifier + protein + sauce + "Burger"
  DECLARE b_mod  VARCHAR(50);
  DECLARE b_prot VARCHAR(50);
  DECLARE b_sauce VARCHAR(50);
  DECLARE b_extra VARCHAR(50);

  -- SIDES: style + base
  DECLARE s_style VARCHAR(50);
  DECLARE s_base  VARCHAR(50);

  -- SILOG: meat + extras
  DECLARE si_meat VARCHAR(50);
  DECLARE si_extra VARCHAR(50);

  -- DRINKS: size + type
  DECLARE d_type  VARCHAR(50);
  DECLARE d_flav  VARCHAR(50);

  WHILE i <= 10000 DO

    -- Pick category (distribute: 40% Burgers, 20% Sides, 20% Silog, 20% Drinks)
    SET v_cat = ELT(1 + FLOOR(RAND()*10),
      'Burgers','Burgers','Burgers','Burgers',
      'Sides','Sides',
      'Silog Meals','Silog Meals',
      'Drinks','Drinks');

    -- -------------------------------------------------------
    -- BURGERS
    -- -------------------------------------------------------
    IF v_cat = 'Burgers' THEN
      SET b_mod  = ELT(1+FLOOR(RAND()*20),
        'Classic','Smoky','Crispy','Grilled','Spicy','BBQ','Loaded',
        'Ultimate','Double','Triple','Mega','Giant','Jumbo','Signature',
        'Deluxe','Premium','Special','Gourmet','Fire','Cool');
      SET b_prot = ELT(1+FLOOR(RAND()*10),
        'Beef','Chicken','Pork','Bacon','Mushroom','Fish','Shrimp',
        'Veggie','Cheese','Combo');
      SET b_sauce= ELT(1+FLOOR(RAND()*10),
        'Ranch','Garlic Mayo','Sriracha','Honey Mustard','Teriyaki',
        'Buffalo','Chipotle','Pesto','Blue Cheese','Thousand Island');
      SET b_extra= ELT(1+FLOOR(RAND()*8),
        'Burger','Burger','Burger','Burger Steak','Smash Burger',
        'Tower Burger','Slider','Wrap');

      SET v_name  = CONCAT(b_mod, ' ', b_prot, ' ', b_extra);
      SET v_price = ROUND(88 + RAND()*312, 2);   -- 88–400
      SET v_spicy = ELT(1+FLOOR(RAND()*4),'None','Mild','Medium','Hot');
      SET v_meal  = ELT(1+FLOOR(RAND()*3),'Lunch','Dinner','All Day');
      SET v_prep  = FLOOR(8 + RAND()*12);
      SET v_desc  = CONCAT(b_mod, ' ', b_prot, ' burger with ', b_sauce, ' sauce');

    -- -------------------------------------------------------
    -- SIDES
    -- -------------------------------------------------------
    ELSEIF v_cat = 'Sides' THEN
      SET s_style = ELT(1+FLOOR(RAND()*16),
        'Crispy','Loaded','Cheesy','Spicy','Smoky','Garlic','Ranch',
        'BBQ','Buffalo','Truffle','Cajun','Herb','Sweet','Waffle',
        'Curly','Seasoned');
      SET s_base  = ELT(1+FLOOR(RAND()*12),
        'Fries','Fries','Fries','Nachos','Rings','Wedges','Tots',
        'Coleslaw','Corn Dog','Poppers','Nuggets','Strips');

      SET v_name  = CONCAT(s_style, ' ', s_base);
      SET v_price = ROUND(45 + RAND()*155, 2);   -- 45–200
      SET v_spicy = ELT(1+FLOOR(RAND()*4),'None','None','Mild','Medium');
      SET v_meal  = 'All Day';
      SET v_prep  = FLOOR(5 + RAND()*10);
      SET v_desc  = CONCAT('Delicious ', s_style, ' ', s_base, ' — a perfect side dish');

    -- -------------------------------------------------------
    -- SILOG MEALS
    -- -------------------------------------------------------
    ELSEIF v_cat = 'Silog Meals' THEN
      SET si_meat = ELT(1+FLOOR(RAND()*16),
        'Pork','Chicken','Beef','Tocino','Longganisa','Bacon',
        'Hotdog','Hungarian','Shanghai','Tapa','Bangus','Corned Beef',
        'Spam','Ham','Squid','Dilis');
      SET si_extra= ELT(1+FLOOR(RAND()*6),
        '+ Egg','+ 2 Eggs','+ Atchara','+ Sawsawan','+ Salted Egg','');

      SET v_name  = CONCAT(si_meat, 'silog ', si_extra);
      SET v_price = ROUND(89 + RAND()*111, 2);   -- 89–200
      SET v_spicy = 'None';
      SET v_meal  = ELT(1+FLOOR(RAND()*2),'Breakfast','All Day');
      SET v_prep  = FLOOR(7 + RAND()*8);
      SET v_desc  = CONCAT(si_meat, ' silog meal with garlic fried rice and egg ', si_extra);

    -- -------------------------------------------------------
    -- DRINKS
    -- -------------------------------------------------------
    ELSE
      SET d_type  = ELT(1+FLOOR(RAND()*16),
        'Soda','Iced Tea','Lemonade','Fruit Shake','Milk Tea','Smoothie',
        'Juice','Frappe','Coffee','Hot Choco','Bottled Water','Sparkling Water',
        'Energy Drink','Calamansi Juice','Buko Juice','Guyabano Shake');
      SET d_flav  = ELT(1+FLOOR(RAND()*14),
        'Mango','Strawberry','Grape','Lychee','Watermelon','Pineapple',
        'Melon','Banana','Mixed Berry','Green Apple','Peach','Passion Fruit',
        'Coconut','Original');

      SET v_name  = IF(d_type IN ('Bottled Water','Sparkling Water','Energy Drink'),
                       d_type,
                       CONCAT(d_flav, ' ', d_type));
      SET v_price = ROUND(25 + RAND()*125, 2);   -- 25–150
      SET v_spicy = 'None';
      SET v_meal  = 'All Day';
      SET v_prep  = FLOOR(2 + RAND()*5);
      SET v_desc  = CONCAT('Refreshing ', v_name, ' — served cold');
    END IF;

    -- Common fields
    SET v_code   = CONCAT(UPPER(LEFT(v_cat,2)), '-', LPAD(i, 6, '0'));
    SET v_avail  = 'Not Available'; -- Set all generated products to Not Available by default
    SET v_size   = IF(RAND() < 0.5, 'Regular', 'Large');
    SET v_pop    = IF(RAND() < 0.25, 'Best Seller', 'Regular');
    SET v_orders = FLOOR(RAND() * 500);

    INSERT INTO products
      (ProductName, ProductCode, Category, Description, Price, Availability,
       ServingSize, PopularityTag, MealTime, OrderCount, PrepTime, SpicyLevel,
       DateAdded, LastUpdated)
    VALUES
      (v_name, v_code, v_cat, v_desc, v_price, v_avail,
       v_size, v_pop, v_meal, v_orders, v_prep, v_spicy,
       DATE_SUB(NOW(), INTERVAL FLOOR(RAND()*730) DAY),
       DATE_SUB(NOW(), INTERVAL FLOOR(RAND()*30) DAY));

    SET i = i + 1;
    IF MOD(i, 500) = 0 THEN COMMIT; END IF;
  END WHILE;
  COMMIT;
END //
DELIMITER ;

CALL seed_products();
DROP PROCEDURE IF EXISTS seed_products;

SET FOREIGN_KEY_CHECKS = 1;
COMMIT;

-- Final count
SELECT Category, COUNT(*) AS count,
       SUM(IF(Availability='Available',1,0)) AS available,
       SUM(IF(Availability='Not Available',1,0)) AS not_available
FROM products
GROUP BY Category;

SELECT COUNT(*) AS total_products FROM products;
