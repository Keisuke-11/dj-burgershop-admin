-- ============================================================
-- DJ Burgershop - Realistic 10K Seed Data (Option A: ADD ONLY)
-- Safe: does NOT delete or modify any existing records.
-- Run in phpMyAdmin against dj_burgershop.
-- ============================================================

USE dj_burgershop;
SET FOREIGN_KEY_CHECKS = 0;
SET autocommit = 0;

-- ============================================================
-- STEP 1: GENERATE 10,000 CUSTOMERS
-- ============================================================
DROP PROCEDURE IF EXISTS seed_customers;
DELIMITER //
CREATE PROCEDURE seed_customers()
BEGIN
  DECLARE i INT DEFAULT 1;
  DECLARE fn VARCHAR(50);
  DECLARE ln VARCHAR(50);
  DECLARE emails VARCHAR(100);
  DECLARE phones VARCHAR(20);
  DECLARE addrs VARCHAR(255);
  DECLARE ctype VARCHAR(20);
  DECLARE ctag  VARCHAR(50);
  DECLARE rating DECIMAL(3,2);

  WHILE i <= 10000 DO
    SET fn = ELT(1 + FLOOR(RAND()*40),
      'Juan','Maria','Jose','Ana','Carlo','Rosa','Miguel','Liza','Ramon','Elena',
      'Pedro','Carla','Luis','Nina','Mark','Grace','Rodel','Faith','Arnel','Claire',
      'Ben','Joy','Dante','Lea','Erwin','Mel','Ronnie','Cathy','Efren','Daisy',
      'Gio','Tess','Raffy','Vina','Nonoy','Gina','Boboy','Peachy','Lito','Ligaya');
    SET ln = ELT(1 + FLOOR(RAND()*40),
      'Santos','Reyes','Cruz','Bautista','Ocampo','Garcia','Tor res','Flores','Mendoza','Ramos',
      'Dela Cruz','Villanueva','Castro','Castillo','Aquino','Evangelista','Pascual','Soriano','Lim','Ong',
      'Tan','Go','Co','Sy','Chua','Yap','Sison','Delos Santos','Espiritu','Macaraeg',
      'Aguilar','Bernardo','Diaz','Estrada','Figueroa','Gonzales','Hernandez','Jimenez','Lagman','Macapagal');

    SET phones = CONCAT('09', LPAD(FLOOR(100000000 + RAND()*899999999), 9, '0'));
    SET emails = CONCAT(LOWER(fn), '.', LOWER(REPLACE(ln,' ','')), i, '@', ELT(1+FLOOR(RAND()*4),'gmail.com','yahoo.com','outlook.com','icloud.com'));
    SET addrs  = CONCAT(FLOOR(1+RAND()*999), ' ', ELT(1+FLOOR(RAND()*10),'Rizal St','Mabini Ave','Bonifacio Blvd','Luna Rd','Del Pilar St','Aguinaldo Ave','Quezon Blvd','Magsaysay Dr','Roxas Blvd','Burgos St'), ', ', ELT(1+FLOOR(RAND()*8),'Quezon City','Manila','Makati','Caloocan','Pasig','Taguig','Mandaluyong','Parañaque'));
    SET ctype  = IF(RAND() < 0.75, 'Walk-in', 'Reservation');
    SET ctag   = ELT(1+FLOOR(RAND()*4),'New Customer','Regular','VIP','Loyal Customer');
    SET rating = ROUND(2.5 + RAND()*2.5, 2);

    INSERT INTO customer
      (FirstName,LastName,Email,ContactNumber,Address,CustomerType,AccountStatus,CustomerTag,
       TotalOrdersCount,FeedbackCount,SatisfactionRating,CreatedDate,LastTransactionDate)
    VALUES
      (fn, ln, emails, phones, addrs, ctype, 'Active', ctag,
       FLOOR(1+RAND()*50), FLOOR(RAND()*10), rating,
       DATE_SUB(NOW(), INTERVAL FLOOR(RAND()*730) DAY),
       DATE_SUB(NOW(), INTERVAL FLOOR(RAND()*180) DAY));

    SET i = i + 1;
    IF MOD(i, 500) = 0 THEN COMMIT; END IF;
  END WHILE;
  COMMIT;
END //
DELIMITER ;
CALL seed_customers();
DROP PROCEDURE IF EXISTS seed_customers;

-- ============================================================
-- STEP 2: GENERATE 10,000 EMPLOYEES
-- ============================================================
DROP PROCEDURE IF EXISTS seed_employees;
DELIMITER //
CREATE PROCEDURE seed_employees()
BEGIN
  DECLARE i INT DEFAULT 1;
  DECLARE fn VARCHAR(50);
  DECLARE ln VARCHAR(50);
  DECLARE pos VARCHAR(50);
  DECLARE emptype VARCHAR(20);
  DECLARE shift VARCHAR(20);
  DECLARE salary DECIMAL(10,2);
  DECLARE gend VARCHAR(10);
  DECLARE v_empid INT;

  WHILE i <= 10000 DO
    SET fn = ELT(1 + FLOOR(RAND()*30),
      'Angelo','Bianca','Carlo','Diana','Edmond','Fatima','Gerardo','Hannah','Ivan','Jasmine',
      'Kevin','Lara','Manuel','Nora','Oscar','Patricia','Quirino','Rachel','Samuel','Theresa',
      'Ulysses','Vanessa','Wilfredo','Xenia','Yamil','Zara','Aldrin','Belen','Cesar','Dolores');
    SET ln = ELT(1 + FLOOR(RAND()*30),
      'Abaya','Bagasao','Cabrera','Dagdag','Ebora','Fajardo','Ganzon','Halog','Igna','Jalbuena',
      'Kintanar','Ladera','Macaraeg','Nabor','Oabel','Pabalan','Quiambao','Rabacal','Salazar','Tagalog',
      'Ulanday','Valdez','Wenceslao','Xavier','Yalung','Zamora','Acosta','Badillo','Camiling','Dalisay');
    SET pos    = ELT(1+FLOOR(RAND()*8),'Cashier','Cook','Waitstaff','Supervisor','Delivery Rider','Dishwasher','Barista','Staff');
    SET emptype= ELT(1+FLOOR(RAND()*3),'Full-time','Part-time','Contract');
    SET shift  = ELT(1+FLOOR(RAND()*3),'Morning','Evening','Split');
    SET gend   = ELT(1+FLOOR(RAND()*2),'Male','Female');
    SET salary = ROUND(ELT(1+FLOOR(RAND()*8),
      600,650,700,750,800,850,900,950) * 26, 2);  -- daily rate * 26 working days

    INSERT INTO employee
      (FirstName,LastName,Gender,DateOfBirth,ContactNumber,Email,Address,
       HireDate,Position,MaritalStatus,EmploymentStatus,EmploymentType,WorkShift,Salary)
    VALUES
      (fn, ln, gend,
       DATE_SUB(CURDATE(), INTERVAL FLOOR(20*365 + RAND()*15*365) DAY),
       CONCAT('09', LPAD(FLOOR(100000000 + RAND()*899999999), 9, '0')),
       CONCAT(LOWER(fn),'.', LOWER(REPLACE(ln,' ','')), i, '@djburger.com'),
       CONCAT(FLOOR(1+RAND()*999),' ', ELT(1+FLOOR(RAND()*6),'Katipunan','EDSA','Commonwealth','Aurora Blvd','Shaw Blvd','Taft Ave')),
       DATE_SUB(CURDATE(), INTERVAL FLOOR(RAND()*1825) DAY),
       pos,
       ELT(1+FLOOR(RAND()*3),'Single','Married','Separated'),
       IF(RAND()<0.9,'Active',IF(RAND()<0.5,'On Leave','Resigned')),
       emptype, shift, salary);

    SET v_empid = LAST_INSERT_ID();

    -- Seed user accounts for the first 50 active employees to enable Payroll & POS demo
    IF i <= 50 THEN
      INSERT IGNORE INTO user_accounts (employee_id, name, username, password, type, position, status)
      VALUES (v_empid, CONCAT(fn, ' ', ln), CONCAT('staff', i), 'staff123', 2, 'Staff', 'Active');
    END IF;

    SET i = i + 1;
    IF MOD(i, 500) = 0 THEN COMMIT; END IF;
  END WHILE;
  COMMIT;
END //
DELIMITER ;
CALL seed_employees();
DROP PROCEDURE IF EXISTS seed_employees;

-- ============================================================
-- STEP 3: GENERATE 10,000 ORDERS (with orderdetails + payment)
-- Uses real CustomerIDs and EmployeeIDs from the DB
-- ============================================================
DROP PROCEDURE IF EXISTS seed_orders;
DELIMITER //
CREATE PROCEDURE seed_orders()
BEGIN
  DECLARE i INT DEFAULT 1;
  DECLARE v_cid INT;
  DECLARE v_eid INT;
  DECLARE v_otype VARCHAR(20);
  DECLARE v_osrc  VARCHAR(20);
  DECLARE v_odate DATE;
  DECLARE v_otime TIME;
  DECLARE v_status VARCHAR(20);
  DECLARE v_pay   VARCHAR(10);
  DECLARE v_total DECIMAL(10,2);
  DECLARE v_items INT;
  DECLARE v_oid   INT;
  DECLARE v_pid   INT;
  DECLARE v_price DECIMAL(10,2);
  DECLARE v_qty   INT;
  DECLARE j INT;
  DECLARE max_cid INT;
  DECLARE max_eid INT;
  DECLARE max_pid INT DEFAULT 21;  -- existing products 1-21

  SELECT MAX(CustomerID) INTO max_cid FROM customer;
  SELECT MAX(EmployeeID) INTO max_eid FROM employee;

  WHILE i <= 10000 DO
    SET v_cid   = FLOOR(1 + RAND() * max_cid);
    SET v_eid   = IF(RAND()<0.8, FLOOR(1 + RAND()*max_eid), NULL);
    SET v_otype = ELT(1+FLOOR(RAND()*3),'Dine-in','Take out','Online');
    SET v_osrc  = ELT(1+FLOOR(RAND()*2),'POS','Website');
    SET v_odate = DATE_SUB(CURDATE(), INTERVAL FLOOR(RAND()*730) DAY);
    SET v_otime = MAKETIME(FLOOR(8+RAND()*14), FLOOR(RAND()*60), FLOOR(RAND()*60));
    SET v_status= ELT(1+FLOOR(RAND()*4),'Completed','Completed','Completed','Cancelled');
    SET v_pay   = ELT(1+FLOOR(RAND()*2),'Cash','GCash');
    SET v_items = FLOOR(1 + RAND()*5);
    SET v_total = 0;

    INSERT INTO orders
      (CustomerID,OrderType,OrderSource,OrderDate,OrderTime,EmployeeID,
       ItemsOrderedCount,TotalAmount,PaymentMethod,OrderStatus,OrderPriority,
       ReceiptNumber,CreatedDate)
    VALUES
      (v_cid, v_otype, v_osrc, v_odate, v_otime, v_eid,
       v_items, 0, v_pay, v_status,
       IF(RAND()<0.15,'Rush','Normal'),
       CONCAT('VT-',YEAR(v_odate),'-',LPAD(i,6,'0')),
       CONCAT(v_odate,' ',v_otime));

    SET v_oid = LAST_INSERT_ID();

    -- Insert order details
    SET j = 1;
    WHILE j <= v_items DO
      SET v_pid   = FLOOR(1 + RAND() * max_pid);
      SET v_price = (SELECT Price FROM products WHERE ProductID = v_pid LIMIT 1);
      SET v_qty   = FLOOR(1 + RAND()*4);
      SET v_total = v_total + (v_price * v_qty);

      INSERT INTO orderdetails (OrderID, ProductID, Quantity, UnitPrice, TotalPrice)
      VALUES (v_oid, v_pid, v_qty, v_price, v_price * v_qty);

      SET j = j + 1;
    END WHILE;

    -- Update total in orders
    UPDATE orders SET TotalAmount = v_total WHERE OrderID = v_oid;

    -- Insert payment
    INSERT INTO payment
      (OrderID, PaymentDate, PaymentMethod, PaymentStatus,
       AmountPaid, PaymentSource,
       ReferenceNumber)
    VALUES
      (v_oid,
       CONCAT(v_odate,' ',v_otime),
       v_pay,
       IF(v_status='Cancelled','Failed','Completed'),
       v_total,
       v_osrc,
       IF(v_pay='GCash', CONCAT('GC-',LPAD(FLOOR(RAND()*9999999),7,'0')), NULL));

    SET i = i + 1;
    IF MOD(i, 200) = 0 THEN COMMIT; END IF;
  END WHILE;
  COMMIT;
END //
DELIMITER ;
CALL seed_orders();
DROP PROCEDURE IF EXISTS seed_orders;

-- ============================================================
-- STEP 4: GENERATE 10,000 RESERVATIONS (with reservation_items)
-- ============================================================
DROP PROCEDURE IF EXISTS seed_reservations;
DELIMITER //
CREATE PROCEDURE seed_reservations()
BEGIN
  DECLARE i INT DEFAULT 1;
  DECLARE v_cid     INT;
  DECLARE v_eid     INT;
  DECLARE v_rdate   DATE;
  DECLARE v_rtime   TIME;
  DECLARE v_etime   TIME;
  DECLARE v_status  VARCHAR(20);
  DECLARE v_etype   VARCHAR(50);
  DECLARE v_guests  INT;
  DECLARE v_deposit DECIMAL(10,2);
  DECLARE v_sub     DECIMAL(10,2);
  DECLARE v_total   DECIMAL(10,2);
  DECLARE v_rid     INT;
  DECLARE v_pid     INT;
  DECLARE v_price   DECIMAL(10,2);
  DECLARE v_qty     INT;
  DECLARE j         INT;
  DECLARE v_items   INT;
  DECLARE max_cid   INT;
  DECLARE max_eid   INT;
  DECLARE max_pid   INT DEFAULT 21;

  SELECT MAX(CustomerID) INTO max_cid FROM customer;
  SELECT MAX(EmployeeID) INTO max_eid FROM employee;

  WHILE i <= 10000 DO
    SET v_cid    = FLOOR(1 + RAND()*max_cid);
    SET v_eid    = IF(RAND()<0.7, FLOOR(1+RAND()*max_eid), NULL);
    SET v_rdate  = DATE_ADD(CURDATE(), INTERVAL FLOOR(-365 + RAND()*730) DAY);
    SET v_rtime  = MAKETIME(FLOOR(10+RAND()*10), FLOOR(RAND()*60), 0);
    SET v_etime  = ADDTIME(v_rtime, '02:00:00');
    SET v_status = ELT(1+FLOOR(RAND()*8),'Pending','Confirmed','Confirmed','Confirmed','Confirmed','Completed','Completed','Cancelled');
    SET v_etype  = ELT(1+FLOOR(RAND()*7),'Birthday','Anniversary','Corporate','Wedding','General','Debut','Family Gathering');
    SET v_guests = FLOOR(2 + RAND()*48);
    SET v_deposit= ROUND(500 + RAND()*2000, 2);
    SET v_sub    = 0;
    SET v_items  = FLOOR(2 + RAND()*6);

    INSERT INTO reservation
      (CustomerID, FullName, ContactNumber, ReservationType, EventType,
       ReservationCode, ReservationDate, EventDate, ReservationTime, EndTime,
       NumberOfGuests, NumberOfCustomers, DepositAmount, SubTotal, CateringFee,
       EquipmentRentalFee, TotalPrice, ReservationStatus, AssignedStaffID,
       SeatType, TableNumber, CreatedAt)
    VALUES
      (v_cid,
       (SELECT CONCAT(FirstName,' ',LastName) FROM customer WHERE CustomerID=v_cid),
       (SELECT ContactNumber FROM customer WHERE CustomerID=v_cid),
       ELT(1+FLOOR(RAND()*2),'Walk-in','Online'),
       v_etype,
       CONCAT('RES-',YEAR(v_rdate),'-',LPAD(i,6,'0')),
       v_rdate, DATE_ADD(v_rdate, INTERVAL FLOOR(RAND()*7) DAY),
       v_rtime, v_etime,
       v_guests, v_guests,
       v_deposit, 0, ROUND(RAND()*2000,2), ROUND(RAND()*1000,2), 0,
       v_status, v_eid,
       ELT(1+FLOOR(RAND()*2),'Indoor','Outdoor'),
       CONCAT('T-', FLOOR(1+RAND()*20)),
       DATE_SUB(v_rdate, INTERVAL FLOOR(1+RAND()*30) DAY));

    SET v_rid = LAST_INSERT_ID();

    -- Insert reservation items
    SET j = 1;
    WHILE j <= v_items DO
      SET v_pid   = FLOOR(1 + RAND()*max_pid);
      SET v_price = (SELECT Price FROM products WHERE ProductID=v_pid LIMIT 1);
      SET v_qty   = v_guests * FLOOR(1+RAND()*2);
      SET v_sub   = v_sub + (v_price * v_qty);

      INSERT INTO reservation_items (ReservationID, ProductID, ProductName, Quantity, UnitPrice, TotalPrice)
      VALUES (v_rid, v_pid,
              (SELECT ProductName FROM products WHERE ProductID=v_pid LIMIT 1),
              v_qty, v_price, v_price*v_qty);

      SET j = j + 1;
    END WHILE;

    -- Update subtotal + total
    UPDATE reservation
    SET SubTotal   = v_sub,
        TotalPrice = v_sub + CateringFee + EquipmentRentalFee
    WHERE ReservationID = v_rid;

    SET i = i + 1;
    IF MOD(i, 200) = 0 THEN COMMIT; END IF;
  END WHILE;
  COMMIT;
END //
DELIMITER ;
CALL seed_reservations();
DROP PROCEDURE IF EXISTS seed_reservations;

-- ============================================================
-- STEP 5: EMPLOYEE ATTENDANCE (365 days × employees, sampled)
-- Generates ~10k+ realistic attendance records
-- ============================================================
DROP PROCEDURE IF EXISTS seed_attendance;
DELIMITER //
CREATE PROCEDURE seed_attendance()
BEGIN
  DECLARE i INT DEFAULT 1;
  DECLARE j INT DEFAULT 1;
  DECLARE v_eid  INT;
  DECLARE v_date DATE;
  DECLARE v_tin  TIME;
  DECLARE v_tout TIME;
  DECLARE v_stat VARCHAR(20);
  DECLARE max_eid INT;

  SELECT MAX(EmployeeID) INTO max_eid FROM employee;

  -- A. Guarantee attendance records for the first 50 demo employees
  SET i = 1;
  WHILE i <= 50 DO
    SET j = 1;
    WHILE j <= 20 DO
      SET v_date = DATE_SUB(CURDATE(), INTERVAL j DAY);
      SET v_tin  = MAKETIME(7 + FLOOR(RAND()*2), FLOOR(RAND()*30), 0);
      SET v_tout = MAKETIME(16 + FLOOR(RAND()*3), FLOOR(RAND()*60), 0);
      
      INSERT IGNORE INTO employeeattendance (EmployeeID, Date, TimeIn, TimeOut, Status)
      VALUES (i, v_date, v_tin, v_tout, 'Present');
      
      SET j = j + 1;
    END WHILE;
    SET i = i + 1;
  END WHILE;
  COMMIT;

  -- B. Generate random remaining attendance records
  SET i = 1;
  WHILE i <= 10000 DO
    SET v_eid  = FLOOR(1 + RAND()*max_eid);
    SET v_date = DATE_SUB(CURDATE(), INTERVAL FLOOR(RAND()*365) DAY);
    SET v_stat = ELT(1+FLOOR(RAND()*10),'Present','Present','Present','Present','Present','Present','Present','Late','Absent','On Leave');

    IF v_stat = 'Absent' OR v_stat = 'On Leave' THEN
      SET v_tin  = NULL;
      SET v_tout = NULL;
    ELSEIF v_stat = 'Late' THEN
      SET v_tin  = MAKETIME(FLOOR(9+RAND()*2), FLOOR(RAND()*60), 0);
      SET v_tout = MAKETIME(FLOOR(17+RAND()*2), FLOOR(RAND()*60), 0);
    ELSE
      SET v_tin  = MAKETIME(FLOOR(7+RAND()*2), FLOOR(RAND()*30), 0);
      SET v_tout = MAKETIME(FLOOR(16+RAND()*3), FLOOR(RAND()*60), 0);
    END IF;

    INSERT IGNORE INTO employeeattendance (EmployeeID, Date, TimeIn, TimeOut, Status)
    VALUES (v_eid, v_date, v_tin, v_tout, v_stat);

    SET i = i + 1;
    IF MOD(i, 500) = 0 THEN COMMIT; END IF;
  END WHILE;
  COMMIT;
END //
DELIMITER ;
CALL seed_attendance();
DROP PROCEDURE IF EXISTS seed_attendance;

-- ============================================================
-- STEP 6: PAYROLL (one record per employee per month, ~10k)
-- ============================================================
DROP PROCEDURE IF EXISTS seed_payroll;
DELIMITER //
CREATE PROCEDURE seed_payroll()
BEGIN
  DECLARE i INT DEFAULT 1;
  DECLARE v_eid    INT;
  DECLARE v_pstart DATE;
  DECLARE v_pend   DATE;
  DECLARE v_basic  DECIMAL(10,2);
  DECLARE v_ot     DECIMAL(10,2);
  DECLARE v_bonus  DECIMAL(10,2);
  DECLARE v_ded    DECIMAL(10,2);
  DECLARE v_net    DECIMAL(10,2);
  DECLARE v_hrs    DECIMAL(10,2);
  DECLARE v_rate   DECIMAL(10,2);
  DECLARE v_month  INT;
  DECLARE v_year   INT;
  DECLARE max_eid  INT;

  SELECT MAX(EmployeeID) INTO max_eid FROM employee;

  -- A. Guarantee historical payroll records for the first 30 demo employees (May 1 - May 15, 2026)
  SET @p_start = DATE_SUB(CURDATE(), INTERVAL DAY(CURDATE()) - 1 DAY); -- 1st of current month
  SET @p_end = DATE_ADD(@p_start, INTERVAL 14 DAY); -- 15th of current month

  SET i = 1;
  WHILE i <= 30 DO
    SET v_rate   = (SELECT IFNULL(Salary,15000)/26/8 FROM employee WHERE EmployeeID=i LIMIT 1);
    SET v_hrs    = 80.00;
    SET v_basic  = ROUND(v_rate * v_hrs, 2);
    SET v_ot     = ROUND(RAND()*100, 2);
    SET v_bonus  = 0;
    SET v_ded    = 0;
    SET v_net    = ROUND(v_basic + v_ot, 2);
    SET v_stat   = IF(i <= 15, 'Paid', IF(i <= 25, 'Approved', 'Pending'));

    INSERT INTO payroll
      (EmployeeID, PayPeriodStart, PayPeriodEnd, BasicSalary, Overtime,
       Bonuses, Deductions, NetPay, HoursWorked, HourlyRate,
       Status, PaymentDate, CreatedDate)
    VALUES
      (i, @p_start, @p_end, v_basic, v_ot,
       v_bonus, v_ded, v_net, v_hrs, v_rate,
       v_stat, IF(v_stat='Paid', DATE_ADD(@p_end, INTERVAL 3 DAY), NULL),
       @p_start);

    SET i = i + 1;
  END WHILE;
  COMMIT;

  -- B. Generate random remaining monthly payroll records
  SET i = 1;
  WHILE i <= 10000 DO
    SET v_eid   = FLOOR(1 + RAND()*max_eid);
    SET v_month = FLOOR(1 + RAND()*12);
    SET v_year  = FLOOR(2022 + RAND()*3);
    SET v_pstart= STR_TO_DATE(CONCAT(v_year,'-',LPAD(v_month,2,'0'),'-01'), '%Y-%m-%d');
    SET v_pend  = LAST_DAY(v_pstart);
    SET v_rate  = (SELECT IFNULL(Salary,15000)/26/8 FROM employee WHERE EmployeeID=v_eid LIMIT 1);
    SET v_hrs   = ROUND(160 + RAND()*40, 2);
    SET v_basic = ROUND(v_rate * v_hrs, 2);
    SET v_ot    = ROUND(RAND()*500, 2);
    SET v_bonus = ROUND(IF(RAND()<0.3, 500+RAND()*2000, 0), 2);
    SET v_ded   = ROUND(v_basic * 0.12, 2);  -- SSS + Pag-IBIG + PhilHealth ~12%
    SET v_net   = ROUND(v_basic + v_ot + v_bonus - v_ded, 2);

    INSERT INTO payroll
      (EmployeeID, PayPeriodStart, PayPeriodEnd, BasicSalary, Overtime,
       Bonuses, Deductions, NetPay, HoursWorked, HourlyRate,
       Status, PaymentDate, CreatedDate)
    VALUES
      (v_eid, v_pstart, v_pend, v_basic, v_ot,
       v_bonus, v_ded, v_net, v_hrs, v_rate,
       ELT(1+FLOOR(RAND()*3),'Paid','Approved','Pending'),
       DATE_ADD(v_pend, INTERVAL 5 DAY),
       v_pstart);

    SET i = i + 1;
    IF MOD(i, 500) = 0 THEN COMMIT; END IF;
  END WHILE;
  COMMIT;
END //
DELIMITER ;
CALL seed_payroll();
DROP PROCEDURE IF EXISTS seed_payroll;

-- ============================================================
-- DONE — Re-enable FK checks
-- ============================================================
SET FOREIGN_KEY_CHECKS = 1;
COMMIT;

SELECT 'SEEDING COMPLETE' AS result;
SELECT 'products'           AS tbl, COUNT(*) AS total FROM products
UNION ALL SELECT 'customer',         COUNT(*) FROM customer
UNION ALL SELECT 'employee',         COUNT(*) FROM employee
UNION ALL SELECT 'orders',           COUNT(*) FROM orders
UNION ALL SELECT 'orderdetails',     COUNT(*) FROM orderdetails
UNION ALL SELECT 'payment',          COUNT(*) FROM payment
UNION ALL SELECT 'reservation',      COUNT(*) FROM reservation
UNION ALL SELECT 'reservation_items',COUNT(*) FROM reservation_items
UNION ALL SELECT 'employeeattendance',COUNT(*) FROM employeeattendance
UNION ALL SELECT 'payroll',          COUNT(*) FROM payroll;
