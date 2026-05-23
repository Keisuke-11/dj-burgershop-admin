-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 11, 2026 at 04:57 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `burger_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `activity_logs`
--

CREATE TABLE `activity_logs` (
  `LogID` int(11) NOT NULL,
  `UserType` enum('Admin','Staff','Customer') NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `Username` varchar(100) DEFAULT NULL,
  `Action` varchar(255) NOT NULL,
  `ActivityType` varchar(100) DEFAULT NULL,
  `Module` varchar(100) DEFAULT NULL,
  `ActionCategory` enum('Login','Logout','Order','Reservation','Payment','Inventory','Product','User Management','Report','System') NOT NULL,
  `Description` text DEFAULT NULL,
  `SourceSystem` enum('POS','Website','Admin Panel') NOT NULL,
  `ReferenceID` varchar(50) DEFAULT NULL,
  `ReferenceTable` varchar(100) DEFAULT NULL,
  `OldValue` text DEFAULT NULL,
  `NewValue` text DEFAULT NULL,
  `Status` enum('Success','Failed','Warning') DEFAULT 'Success',
  `SessionID` varchar(100) DEFAULT NULL,
  `Timestamp` datetime NOT NULL DEFAULT current_timestamp(),
  `LogDate` datetime DEFAULT current_timestamp(),
  `IPAddress` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `activity_logs`
--

INSERT INTO `activity_logs` (`LogID`, `UserType`, `UserID`, `Username`, `Action`, `ActivityType`, `Module`, `ActionCategory`, `Description`, `SourceSystem`, `ReferenceID`, `ReferenceTable`, `OldValue`, `NewValue`, `Status`, `SessionID`, `Timestamp`, `LogDate`, `IPAddress`) VALUES
(58, 'Admin', 29, 'juan.delacruz', 'Product Price Updated', 'Update', 'Products', 'Product', 'Updated price of DJ Classic Burger from ₱139.00 to ₱149.00', 'Admin Panel', '1', 'products', '{\"Price\": \"139.00\"}', '{\"Price\": \"149.00\"}', 'Success', 'SESS-2026-001', '2026-05-09 09:00:00', '2026-05-09 09:00:00', '127.0.0.1'),
(59, 'Admin', 33, 'rico.bautista', 'New User Account Created', 'Create', 'User Management', 'User Management', 'Created new user account for Paolo Cruz — Cashier', 'Admin Panel', '35', 'user_accounts', NULL, '{\"username\": \"paolo.cruz\", \"position\": \"Cashier\"}', 'Success', 'SESS-2026-002', '2026-05-09 10:00:00', '2026-05-09 10:00:00', '127.0.0.1'),
(60, 'Admin', 29, 'juan.delacruz', 'Reservation Confirmed', 'Update', 'Reservations', 'Reservation', 'Confirmed Reservation ID 12 for Keldon Johnson Jr.', 'Admin Panel', '12', 'reservation', '{\"ReservationStatus\": \"Pending\"}', '{\"ReservationStatus\": \"Confirmed\"}', 'Success', 'SESS-2026-001', '2026-05-09 11:00:00', '2026-05-09 11:00:00', '127.0.0.1'),
(61, 'Admin', 33, 'rico.bautista', 'Inventory Restocked', 'Create', 'Inventory', 'Inventory', 'Restocked Brioche Bun — added 50 pcs to BATCH-006', 'Admin Panel', '6', 'inventory_batches', '{\"StockQuantity\": \"150.000\"}', '{\"StockQuantity\": \"200.000\"}', 'Success', 'SESS-2026-002', '2026-05-09 12:00:00', '2026-05-09 12:00:00', '127.0.0.1'),
(62, 'Admin', 29, 'juan.delacruz', 'Payroll Processed', 'Create', 'Payroll', 'Report', 'Processed payroll for May 2026 — 10 employees', 'Admin Panel', NULL, 'payroll', NULL, '{\"PayPeriod\": \"May 2026\", \"TotalEmployees\": 10}', 'Success', 'SESS-2026-001', '2026-05-09 13:00:00', '2026-05-09 13:00:00', '127.0.0.1'),
(63, 'Customer', 17, 'Keldon Johnson Jr.', 'Reservation Created', NULL, NULL, 'Reservation', 'Customer created a indoor reservation for 12 guests on 2026-05-12', 'Website', '21', 'reservations', NULL, '{\"reservation_id\":21,\"event_type\":\"indoor\",\"event_date\":\"2026-05-12\",\"guests\":12}', 'Success', NULL, '2026-05-11 22:23:33', '2026-05-11 22:23:33', NULL),
(64, 'Staff', 29, 'Juan dela Cruz', 'User Login', NULL, NULL, 'Login', 'Juan dela Cruz logged into POS', 'POS', NULL, NULL, NULL, NULL, 'Success', NULL, '2026-05-11 22:52:01', '2026-05-11 22:52:01', NULL);

-- --------------------------------------------------------

--
-- Stand-in structure for view `approved_customer_reviews`
-- (See below for the actual view)
--
CREATE TABLE `approved_customer_reviews` (
`reviewid` int(11)
,`customerid` int(11)
,`displayname` varchar(101)
,`firstname` varchar(50)
,`overallrating` int(11)
,`foodtasterating` int(11)
,`portionsizerating` int(11)
,`customerservicerating` int(11)
,`ambiencerating` int(11)
,`cleanlinessrating` int(11)
,`foodtastecomment` text
,`portionsizecomment` text
,`customerservicecomment` text
,`ambiencecomment` text
,`cleanlinesscomment` text
,`generalcomment` text
,`createddate` datetime
,`approveddate` datetime
);

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `CustomerID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `FeedbackCount` int(5) NOT NULL DEFAULT 0,
  `ContactNumber` varchar(20) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `CustomerType` enum('Walk-in','Reservation') DEFAULT 'Walk-in',
  `AccountStatus` varchar(50) DEFAULT 'Active',
  `CustomerTag` varchar(50) NOT NULL DEFAULT 'New Customer',
  `TotalOrdersCount` int(10) NOT NULL DEFAULT 0,
  `LastTransactionDate` datetime DEFAULT NULL,
  `ReservationCount` int(10) NOT NULL DEFAULT 0,
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp(),
  `SatisfactionRating` decimal(3,2) NOT NULL DEFAULT 0.00,
  `LastReservationDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`CustomerID`, `FirstName`, `LastName`, `Email`, `Password`, `LastLoginDate`, `FeedbackCount`, `ContactNumber`, `Address`, `CustomerType`, `AccountStatus`, `CustomerTag`, `TotalOrdersCount`, `LastTransactionDate`, `ReservationCount`, `CreatedDate`, `SatisfactionRating`, `LastReservationDate`) VALUES
(1, 'Maria', 'Santos', 'maria@gmail.com', 'Maria123', '2025-04-30 10:15:00', 3, '09171234567', 'Blk 4 Lot 2 Sampaguita St., Quezon City', 'Walk-in', 'Active', 'Regular Customer', 12, '2025-04-30 10:15:00', 2, '2024-11-01 08:00:00', 4.50, '2025-03-15'),
(2, 'Jose', 'Reyes', NULL, NULL, '2025-04-28 14:30:00', 1, '09281234568', '123 Rizal Ave., Manila', 'Walk-in', 'Active', 'Regular Customer', 8, '2025-04-28 14:30:00', 0, '2024-12-05 09:00:00', 4.00, NULL),
(3, 'Ana', 'Cruz', NULL, NULL, '2025-04-25 11:00:00', 5, '09391234569', '45 Mabini St., Caloocan City', 'Reservation', 'Active', 'Regular Customer', 20, '2025-04-25 11:00:00', 4, '2024-10-10 07:30:00', 4.80, '2025-04-10'),
(4, 'Carlos', 'Garcia', NULL, NULL, '2025-04-20 09:45:00', 0, '09501234570', '78 Del Pilar St., Pasay City', 'Walk-in', 'Active', 'New Customer', 3, '2025-04-20 09:45:00', 0, '2025-03-01 10:00:00', 3.50, NULL),
(5, 'Rosa', 'Mendoza', NULL, NULL, '2025-04-18 16:00:00', 2, '09611234571', '12 Luna St., Makati City', 'Reservation', 'Active', 'Regular Customer', 15, '2025-04-18 16:00:00', 3, '2024-09-20 08:00:00', 4.20, '2025-04-01'),
(6, 'Miguel', 'Torres', NULL, NULL, '2025-04-15 12:30:00', 1, '09721234572', '99 Bonifacio St., Mandaluyong', 'Walk-in', 'Active', 'New Customer', 5, '2025-04-15 12:30:00', 0, '2025-02-14 09:00:00', 3.80, NULL),
(7, 'Liza', 'Ramos', NULL, NULL, '2025-04-10 08:00:00', 4, '09831234573', '33 Aguinaldo Ave., Cavite City', 'Reservation', 'Active', 'Regular Customer', 18, '2025-04-10 08:00:00', 5, '2024-08-30 07:00:00', 4.90, '2025-04-05'),
(8, 'Ramon', 'Flores', NULL, NULL, '2025-04-08 13:15:00', 0, '09941234574', '21 Katipunan Rd., Quezon City', 'Walk-in', 'Active', 'New Customer', 2, '2025-04-08 13:15:00', 0, '2025-04-01 11:00:00', 0.00, NULL),
(9, 'Elena', 'Villanueva', NULL, NULL, '2025-04-05 17:45:00', 2, '09051234575', '55 Shaw Blvd., Mandaluyong', 'Walk-in', 'Active', 'Regular Customer', 9, '2025-04-05 17:45:00', 1, '2024-11-11 08:30:00', 4.10, '2025-02-20'),
(10, 'Danilo', 'Aquino', NULL, NULL, '2025-03-30 10:00:00', 3, '09161234576', '8 EDSA, Pasig City', 'Reservation', 'Active', 'Regular Customer', 11, '2025-03-30 10:00:00', 2, '2024-07-07 09:00:00', 4.60, '2025-03-20'),
(11, 'Patricia', 'Bautista', NULL, NULL, '2025-03-25 14:00:00', 1, '09271234577', '67 Taft Ave., Manila', 'Walk-in', 'Active', 'New Customer', 4, '2025-03-25 14:00:00', 0, '2025-01-15 10:30:00', 3.70, NULL),
(12, 'Roberto', 'Dela Cruz', NULL, NULL, '2025-03-20 09:30:00', 0, '09381234578', '14 Commonwealth Ave., Quezon City', 'Walk-in', 'Active', 'New Customer', 1, '2025-03-20 09:30:00', 0, '2025-03-15 08:00:00', 0.00, NULL),
(13, 'Gloria', 'Pascual', NULL, NULL, '2025-03-15 15:00:00', 6, '09491234579', '30 Aurora Blvd., Quezon City', 'Reservation', 'Active', 'Regular Customer', 25, '2025-03-15 15:00:00', 6, '2024-06-01 07:30:00', 4.95, '2025-03-10'),
(14, 'Fernando', 'Castillo', NULL, NULL, '2025-03-10 11:00:00', 1, '09601234580', '77 España St., Sampaloc, Manila', 'Walk-in', 'Active', 'Regular Customer', 7, '2025-03-10 11:00:00', 0, '2024-12-20 09:00:00', 4.30, NULL),
(15, 'Josephine', 'Navarro', NULL, NULL, '2025-03-05 08:45:00', 2, '09711234581', '5 Mayon St., Quezon City', 'Reservation', 'Active', 'Regular Customer', 13, '2025-03-05 08:45:00', 3, '2024-05-18 08:00:00', 4.40, '2025-02-25'),
(16, 'Lebron', 'James', 'lebronjames@gmail.com', '$2y$12$OkDEzQrfzl7AjK92b4eJ2OX8fkY5TkMSdeuQBmOCudKfekjwvxSwm', NULL, 0, '09886545589', NULL, 'Reservation', 'Active', 'New Customer', 0, '2026-05-07 15:33:10', 1, '2026-05-06 19:47:39', 0.00, NULL),
(17, 'Keldon', 'Johnson Jr.', 'keldon@gmail.com', '$2y$12$URgMdH3vimy8QfqbY49Tfed7chyHesvbJzvLXPOtlQwRqMdRVd0jO', '2026-05-11 16:02:04', 0, '09886545555', NULL, 'Reservation', 'Active', 'New Customer', 4, '2026-05-11 22:23:33', 3, '2026-05-07 16:25:03', 0.00, NULL),
(18, 'Kevin', 'Durant', 'kd@gmail.com', '$2y$12$ZinjY9YolOm3P0JtUSk/j.Pfgiz1gsKu9nDHTyQsE2Z3ANzSQ1SCy', NULL, 0, '09886545444', NULL, 'Reservation', 'Active', 'New Customer', 2, '2026-05-08 18:36:23', 0, '2026-05-07 20:11:23', 0.00, NULL),
(19, 'Chris', 'Paul', '', NULL, NULL, 0, '09887865555', NULL, 'Walk-in', 'Suspended', 'New Customer', 0, NULL, 0, '2026-05-08 23:08:57', 0.00, NULL),
(20, 'Luka', 'Doncic', '', NULL, NULL, 0, '09876665453', NULL, 'Walk-in', 'Active', 'New Customer', 0, NULL, 0, '2026-05-08 23:45:43', 0.00, NULL),
(21, 'Nikola', 'Jokic', '', NULL, NULL, 0, '09783213333', NULL, 'Walk-in', 'Inactive', 'New Customer', 0, NULL, 0, '2026-05-09 00:05:56', 0.00, NULL),
(22, 'Trae', 'Young', '', NULL, NULL, 0, '09887775643', NULL, 'Walk-in', 'Inactive', 'New Customer', 0, NULL, 0, '2026-05-09 11:33:04', 0.00, NULL),
(23, 'John', 'Wall', '', NULL, NULL, 0, '09999888767', NULL, 'Walk-in', 'Suspended', 'New Customer', 0, NULL, 0, '2026-05-09 13:07:01', 0.00, NULL),
(24, 'Ann', 'dominique', '', NULL, NULL, 0, '09888786565', NULL, 'Walk-in', 'Active', 'New Customer', 0, NULL, 0, '2026-05-11 22:53:22', 0.00, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `customers_archive`
--

CREATE TABLE `customers_archive` (
  `CustomerID` int(10) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `PasswordHash` varchar(255) DEFAULT NULL,
  `ContactNumber` varchar(20) DEFAULT NULL,
  `CustomerType` enum('Walk-in','Online','Reservation','Corporate/Event') DEFAULT 'Walk-in',
  `FeedbackCount` int(10) NOT NULL DEFAULT 0,
  `TotalOrdersCount` int(10) NOT NULL DEFAULT 0,
  `ReservationCount` int(10) NOT NULL DEFAULT 0,
  `LastTransactionDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp(),
  `AccountStatus` enum('Active','Suspended','Inactive') DEFAULT 'Active',
  `SatisfactionRating` decimal(3,2) NOT NULL DEFAULT 0.00,
  `ArchivedDate` datetime NOT NULL DEFAULT current_timestamp(),
  `ArchivedReason` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers_archive`
--

INSERT INTO `customers_archive` (`CustomerID`, `FirstName`, `LastName`, `Email`, `PasswordHash`, `ContactNumber`, `CustomerType`, `FeedbackCount`, `TotalOrdersCount`, `ReservationCount`, `LastTransactionDate`, `LastLoginDate`, `CreatedDate`, `AccountStatus`, `SatisfactionRating`, `ArchivedDate`, `ArchivedReason`) VALUES
(1, 'Pedro', 'Penduko', 'pedro@gmail.com', 'hashed123', '09171234500', 'Walk-in', 2, 10, 1, '2025-12-01 10:00:00', '2025-12-01 09:00:00', '2024-01-01 08:00:00', 'Inactive', 3.50, '2026-01-01 00:00:00', 'Account inactive for 6 months'),
(2, 'Nena', 'Gomez', 'nena@gmail.com', 'hashed456', '09281234501', 'Reservation', 5, 20, 4, '2025-11-15 14:00:00', '2025-11-15 13:00:00', '2024-02-15 08:00:00', 'Suspended', 4.20, '2026-02-01 00:00:00', 'Violation of terms'),
(3, 'Bert', 'Santos', 'bert@gmail.com', 'hashed789', '09391234502', 'Online', 1, 5, 0, '2025-10-20 11:00:00', '2025-10-20 10:00:00', '2024-03-10 08:00:00', 'Inactive', 2.80, '2026-03-01 00:00:00', 'Customer requested deletion'),
(4, 'Lorna', 'Reyes', 'lorna@gmail.com', 'hashedabc', '09501234503', 'Walk-in', 3, 8, 2, '2025-09-05 09:00:00', '2025-09-05 08:30:00', '2024-04-20 08:00:00', 'Inactive', 3.90, '2026-04-01 00:00:00', 'No activity for 1 year'),
(5, 'Danny', 'Cruz', 'danny@gmail.com', 'hasheddef', '09611234504', 'Reservation', 0, 3, 1, '2025-08-10 16:00:00', '2025-08-10 15:00:00', '2024-05-05 08:00:00', 'Suspended', 1.50, '2026-05-01 00:00:00', 'Fraudulent activity detected');

-- --------------------------------------------------------

--
-- Table structure for table `customer_feedback`
--

CREATE TABLE `customer_feedback` (
  `FeedbackID` int(11) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `ReservationID` int(11) DEFAULT NULL,
  `FeedbackType` enum('Order','Reservation','General') NOT NULL DEFAULT 'General',
  `OverallRating` int(11) NOT NULL,
  `FoodTasteRating` int(11) DEFAULT NULL,
  `PortionSizeRating` int(11) DEFAULT NULL,
  `ServiceRating` int(11) DEFAULT NULL,
  `AmbienceRating` int(11) DEFAULT NULL,
  `CleanlinessRating` int(11) DEFAULT NULL,
  `FoodTasteComment` text DEFAULT NULL,
  `PortionSizeComment` text DEFAULT NULL,
  `ServiceComment` text DEFAULT NULL,
  `AmbienceComment` text DEFAULT NULL,
  `CleanlinessComment` text DEFAULT NULL,
  `ReviewMessage` text DEFAULT NULL,
  `IsAnonymous` tinyint(1) NOT NULL DEFAULT 0,
  `Status` enum('Pending','Approved','Rejected') NOT NULL DEFAULT 'Pending',
  `ApprovedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer_feedback`
--

INSERT INTO `customer_feedback` (`FeedbackID`, `CustomerID`, `OrderID`, `ReservationID`, `FeedbackType`, `OverallRating`, `FoodTasteRating`, `PortionSizeRating`, `ServiceRating`, `AmbienceRating`, `CleanlinessRating`, `FoodTasteComment`, `PortionSizeComment`, `ServiceComment`, `AmbienceComment`, `CleanlinessComment`, `ReviewMessage`, `IsAnonymous`, `Status`, `ApprovedDate`, `UpdatedDate`, `CreatedDate`) VALUES
(1, 16, NULL, NULL, 'General', 4, 4, NULL, NULL, NULL, NULL, 'Masarap', 'Malaki', 'Mabait', 'Maayos', 'Malinis', 'Ayos naman', 0, 'Approved', NULL, '2026-05-11 10:02:49', '2026-05-07 12:24:06'),
(2, 17, 22, NULL, 'Order', 5, 5, 4, 5, NULL, NULL, 'Sobrang sarap ng burger!', 'Sapat lang ang serving size', 'Napakabilis ng service', NULL, NULL, 'Overall satisfied with my order. Will definitely order again!', 0, 'Approved', '2026-05-09 12:00:00', '2026-05-09 12:00:00', '2026-05-09 11:25:20'),
(3, 18, 18, NULL, 'Order', 4, 4, 4, 3, NULL, NULL, 'Masarap ang pagkain', 'Okay ang laki ng serving', 'Medyo matagal ang delivery', NULL, NULL, 'Good food but delivery could be faster. Would still recommend.', 0, 'Approved', '2026-05-09 13:00:00', '2026-05-09 13:00:00', '2026-05-09 12:00:00'),
(4, 1, NULL, 1, 'Reservation', 5, 5, 5, 5, 5, 5, 'Lahat ng pagkain ay masarap', 'Malaki at sulit ang serving', 'Napaka-friendly ng staff', 'Maganda ang ambiance', 'Malinis ang lugar', 'Perfect na perfect ang lahat! Highly recommended para sa events!', 0, 'Approved', '2026-05-09 14:00:00', '2026-05-09 14:00:00', '2026-05-09 13:30:00'),
(5, 3, NULL, 3, 'Reservation', 3, 3, 3, 4, 3, 4, 'Pwede na ang lasa', 'Konti lang ang serving para sa presyo', 'Okay naman ang staff', 'Pwede pa mapaganda ang ambiance', 'Medyo malinis', 'Average lang ang experience. May room for improvement.', 0, 'Rejected', NULL, '2026-05-11 16:30:39', '2026-05-09 14:30:00'),
(6, 7, 7, NULL, 'General', 4, 4, 3, 4, 5, 4, 'Masarap ang pagkain lalo na ang burgers', 'Sana mas malaki pa ang serving', 'Magaling ang mga staff', 'Maganda ang lugar para mag-date', 'Malinis at maayos', 'Great place to dine! Especially love the ambiance. Will come back!', 1, 'Approved', '2026-05-10 09:00:00', '2026-05-10 09:00:00', '2026-05-09 19:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `customer_logs`
--

CREATE TABLE `customer_logs` (
  `LogID` int(10) NOT NULL,
  `CustomerID` int(10) DEFAULT NULL,
  `TransactionType` varchar(50) NOT NULL,
  `Details` text DEFAULT NULL,
  `LogDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer_logs`
--

INSERT INTO `customer_logs` (`LogID`, `CustomerID`, `TransactionType`, `Details`, `LogDate`) VALUES
(1, 1, 'Login', 'Customer logged in from mobile device', '2026-05-08 10:00:00'),
(2, 2, 'Order Placed', 'Customer placed online order #ORD-2026-001 worth ₱308.00', '2026-05-08 11:30:00'),
(3, 3, 'Reservation Made', 'Customer made reservation for 5 guests on 2026-05-15', '2026-05-08 13:00:00'),
(4, 4, 'Password Changed', 'Customer changed account password successfully', '2026-05-09 09:00:00'),
(5, 5, 'Feedback Submitted', 'Customer submitted feedback with rating 4/5', '2026-05-09 14:00:00');

-- --------------------------------------------------------

--
-- Stand-in structure for view `customer_statistics`
-- (See below for the actual view)
--
CREATE TABLE `customer_statistics` (
`total_customers` bigint(21)
,`active_customers` decimal(22,0)
,`suspended_customers` decimal(22,0)
,`online_customers` decimal(22,0)
,`average_satisfaction` decimal(7,6)
,`total_orders` decimal(32,0)
,`total_reservations` decimal(32,0)
);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `EmployeeID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Gender` enum('Male','Female','Other') DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `ContactNumber` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `HireDate` date NOT NULL,
  `Position` varchar(50) NOT NULL,
  `MaritalStatus` enum('Single','Married','Separated','Divorced','Widowed') NOT NULL DEFAULT 'Single',
  `EmploymentStatus` enum('Active','On Leave','Resigned') NOT NULL DEFAULT 'Active',
  `EmploymentType` enum('Full-time','Part-time','Contract') NOT NULL DEFAULT 'Full-time',
  `EmergencyContact` varchar(100) DEFAULT NULL,
  `WorkShift` enum('Morning','Evening','Split') DEFAULT NULL,
  `Salary` decimal(10,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`EmployeeID`, `FirstName`, `LastName`, `Gender`, `DateOfBirth`, `ContactNumber`, `Email`, `Address`, `HireDate`, `Position`, `MaritalStatus`, `EmploymentStatus`, `EmploymentType`, `EmergencyContact`, `WorkShift`, `Salary`) VALUES
(1, 'Kenneth', 'Villagen', 'Male', '1998-03-12', '09171110001', 'kenneth.villagen@djsburger.com', 'Blk 1 Lot 5 Bayan St., Quezon City', '2022-01-10', 'Administrator', 'Single', 'Active', 'Full-time', 'Ivan Villagen - 09171110099', 'Morning', 0.00),
(2, 'Sarah', 'Manalo', 'Female', '2000-06-25', '09281110002', 'sarah.manalo@djsburger.com', '23 Laging Handa St., Quezon City', '2022-03-15', 'Cashier', 'Single', 'Active', 'Full-time', 'Mark Manalo - 09281110088', 'Morning', 0.00),
(3, 'Jason', 'Ocampo', 'Male', '1999-11-08', '09391110003', 'jason.ocampo@djsburger.com', '10 Bohol Ave., Quezon City', '2022-05-20', 'Cook', 'Single', 'Active', 'Full-time', 'Linda Ocampo - 09391110077', 'Morning', 0.00),
(4, 'Maricel', 'Espinosa', 'Female', '2001-02-14', '09501110004', 'maricel.espinosa@djsburger.com', '88 P. Tuazon Blvd., Cubao, Quezon City', '2023-01-05', 'Waitstaff', 'Single', 'Active', 'Part-time', 'Juan Espinosa - 09501110066', 'Evening', 0.00),
(5, 'Ronaldo', 'Delos Reyes', 'Male', '1997-08-30', '09611110005', 'ronaldo.delosreyes@djsburger.com', '45 Gen. Luna St., Pasig City', '2021-11-01', 'Cook', 'Married', 'Active', 'Full-time', 'Cynthia Delos Reyes - 09611110055', 'Morning', 0.00),
(6, 'Ann Dominique', 'Estrada', 'Female', '2002-05-19', '09721110000', 'ann.dominique@djsburger.com', '7 Kamias Rd., Daet City', '2023-06-10', 'Waitstaff', 'Single', 'Resigned', 'Part-time', 'Raul Fernandez - 09721110044', 'Split', 1000.00),
(7, 'Marco', 'Lim', 'Male', '1995-12-01', '09831110007', 'marco.lim@djsburger.com', '200 Scout Tuason St., Quezon City', '2020-08-15', 'Supervisor', 'Married', 'Active', 'Full-time', 'Teresa Lim - 09831110033', 'Morning', 0.00),
(8, 'Clarissa', 'Tan', 'Female', '2000-09-22', '09941110008', 'clarissa.tan@djsburger.com', '11 Maginhawa St., Quezon City', '2023-09-01', 'Cashier', 'Single', 'Active', 'Full-time', 'Benito Tan - 09941110022', 'Evening', 0.00),
(9, 'Eduardo', 'Pascua', 'Male', '1996-04-17', '09051110009', 'eduardo.pascua@djsburger.com', '56 Maliksi St., Caloocan City', '2022-07-20', 'Delivery Rider', 'Single', 'On Leave', 'Full-time', 'Nena Pascua - 09051110011', 'Evening', 0.00),
(10, 'Sophia', 'Aguilar', 'Female', '2003-01-30', '09161110010', 'sophia.aguilar@djsburger.com', '3 Sikatuna Village, Quezon City', '2024-02-01', 'Waitstaff', 'Single', 'Active', 'Part-time', 'Renato Aguilar - 09161110000', 'Split', 0.00),
(11, 'Dylan', 'Harper', 'Male', '2000-02-02', '09997878654', 'dylan@gmail.com', NULL, '2026-05-11', 'Staff', 'Single', 'On Leave', 'Full-time', NULL, 'Morning', 0.00);

-- --------------------------------------------------------

--
-- Table structure for table `employeeattendance`
--

CREATE TABLE `employeeattendance` (
  `AttendanceID` int(11) NOT NULL,
  `EmployeeID` int(11) NOT NULL,
  `Date` date NOT NULL,
  `TimeIn` time DEFAULT NULL,
  `TimeOut` time DEFAULT NULL,
  `Status` enum('Present','Absent','Late','On Leave') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employeeattendance`
--

INSERT INTO `employeeattendance` (`AttendanceID`, `EmployeeID`, `Date`, `TimeIn`, `TimeOut`, `Status`) VALUES
(1, 1, '2025-04-28', '08:02:00', '17:05:00', 'Present'),
(2, 2, '2025-04-28', '07:58:00', '17:00:00', 'Present'),
(3, 3, '2025-04-28', '08:10:00', '17:15:00', 'Present'),
(4, 4, '2025-04-28', '14:00:00', '22:00:00', 'Present'),
(5, 5, '2025-04-28', '08:00:00', '17:00:00', 'Present'),
(6, 6, '2025-04-28', '08:30:00', '17:00:00', 'Late'),
(7, 7, '2025-04-28', '07:55:00', '17:00:00', 'Present'),
(8, 8, '2025-04-28', '14:05:00', '22:00:00', 'Present'),
(9, 9, '2025-04-28', NULL, NULL, 'On Leave'),
(10, 10, '2025-04-28', '07:50:00', '14:30:00', 'Present'),
(11, 1, '2025-04-29', '08:01:00', '17:03:00', 'Present'),
(12, 2, '2025-04-29', '08:00:00', '17:00:00', 'Present'),
(13, 3, '2025-04-29', '08:05:00', '17:10:00', 'Present'),
(14, 4, '2025-04-29', '14:00:00', '22:00:00', 'Present'),
(15, 5, '2025-04-29', NULL, NULL, 'Absent'),
(16, 6, '2025-04-29', '08:00:00', '17:00:00', 'Present'),
(17, 7, '2025-04-29', '07:58:00', '17:00:00', 'Present'),
(18, 8, '2025-04-29', '14:00:00', '22:05:00', 'Present'),
(19, 9, '2025-04-29', NULL, NULL, 'On Leave'),
(20, 10, '2025-04-29', '09:00:00', '15:00:00', 'Late'),
(21, 1, '2026-05-08', '13:41:58', NULL, 'Present'),
(22, 1, '2026-05-09', '00:04:41', NULL, 'Present'),
(23, 1, '2026-05-10', '22:33:09', NULL, 'Present'),
(24, 1, '2026-05-11', '22:51:58', '22:53:41', 'Present');

-- --------------------------------------------------------

--
-- Table structure for table `gcash_receipts`
--

CREATE TABLE `gcash_receipts` (
  `ReceiptID` int(11) NOT NULL,
  `ReservationPaymentID` int(11) DEFAULT NULL,
  `ReceiptFileName` varchar(255) DEFAULT NULL,
  `ReceiptFilePath` varchar(255) DEFAULT NULL,
  `FileSize` int(11) DEFAULT NULL,
  `MimeType` varchar(50) DEFAULT NULL,
  `UploadedDate` datetime NOT NULL DEFAULT current_timestamp(),
  `VerificationStatus` enum('Pending','Verified','Rejected') NOT NULL DEFAULT 'Pending',
  `VerificationNotes` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `gcash_receipts`
--

INSERT INTO `gcash_receipts` (`ReceiptID`, `ReservationPaymentID`, `ReceiptFileName`, `ReceiptFilePath`, `FileSize`, `MimeType`, `UploadedDate`, `VerificationStatus`, `VerificationNotes`) VALUES
(1, 9, 'gcash_res11_20260507.jpg', 'uploads/gcash_receipts/2026/05/gcash_res11_20260507.jpg', 245678, 'image/jpeg', '2026-05-07 15:33:10', 'Pending', 'Awaiting admin verification'),
(2, 10, 'gcash_res12_20260507.jpg', 'uploads/gcash_receipts/2026/05/gcash_res12_20260507.jpg', 312456, 'image/jpeg', '2026-05-07 16:27:10', 'Verified', 'Payment confirmed — ₱696.00 received'),
(3, 11, 'gcash_res13_20260507.jpg', 'uploads/gcash_receipts/2026/05/gcash_res13_20260507.jpg', 198234, 'image/jpeg', '2026-05-07 20:01:59', 'Pending', 'Awaiting admin verification'),
(4, 9, 'gcash_res11_retry_20260508.jpg', 'uploads/gcash_receipts/2026/05/gcash_res11_retry_20260508.jpg', 267890, 'image/jpeg', '2026-05-08 09:00:00', 'Rejected', 'Receipt unclear — please resubmit'),
(5, 10, 'gcash_res12_20260508.jpg', 'uploads/gcash_receipts/2026/05/gcash_res12_20260508.jpg', 334512, 'image/jpeg', '2026-05-08 10:00:00', 'Verified', 'Duplicate submission — already verified');

-- --------------------------------------------------------

--
-- Table structure for table `ingredients`
--

CREATE TABLE `ingredients` (
  `IngredientID` int(11) NOT NULL,
  `IngredientName` varchar(100) NOT NULL,
  `Category` varchar(50) DEFAULT NULL,
  `CategoryID` int(11) DEFAULT NULL,
  `UnitType` varchar(20) NOT NULL,
  `StockQuantity` decimal(12,3) NOT NULL DEFAULT 0.000,
  `ReorderLevel` decimal(12,3) NOT NULL DEFAULT 0.000,
  `MinStockLevel` decimal(12,3) NOT NULL DEFAULT 0.000,
  `MaxStockLevel` decimal(12,3) NOT NULL DEFAULT 0.000,
  `UnitCost` decimal(12,2) NOT NULL DEFAULT 0.00,
  `Status` enum('Active','Inactive') NOT NULL DEFAULT 'Active',
  `IsActive` tinyint(1) NOT NULL DEFAULT 1,
  `IsPerishable` tinyint(1) NOT NULL DEFAULT 0,
  `LastRestockedDate` datetime DEFAULT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `ingredients`
--

INSERT INTO `ingredients` (`IngredientID`, `IngredientName`, `Category`, `CategoryID`, `UnitType`, `StockQuantity`, `ReorderLevel`, `MinStockLevel`, `MaxStockLevel`, `UnitCost`, `Status`, `IsActive`, `IsPerishable`, `LastRestockedDate`, `CreatedDate`) VALUES
(1, 'Beef Patty', 'Meat', 1, 'pcs', 150.000, 30.000, 0.000, 0.000, 45.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(2, 'Chicken Breast', 'Meat', 1, 'pcs', 120.000, 25.000, 0.000, 0.000, 38.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(3, 'Bacon', 'Meat', 1, 'pcs', 80.000, 20.000, 0.000, 0.000, 25.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(4, 'Cheddar Cheese', 'Dairy', 2, 'pcs', 100.000, 20.000, 0.000, 0.000, 12.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(5, 'Swiss Cheese', 'Dairy', 2, 'pcs', 60.000, 15.000, 0.000, 0.000, 14.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(6, 'Brioche Bun', 'Bread', 3, 'pcs', 200.000, 50.000, 0.000, 0.000, 8.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(7, 'Lettuce', 'Vegetables', 4, 'pcs', 90.000, 20.000, 0.000, 0.000, 3.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(8, 'Tomato', 'Vegetables', 4, 'pcs', 80.000, 20.000, 0.000, 0.000, 4.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(9, 'Caramelized Onions', 'Vegetables', 4, 'kg', 10.000, 2.000, 0.000, 0.000, 15.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(10, 'Sauteed Mushrooms', 'Vegetables', 4, 'kg', 8.000, 2.000, 0.000, 0.000, 20.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(11, 'House Sauce', 'Condiments', 5, 'ml', 5000.000, 500.000, 0.000, 0.000, 0.05, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(12, 'BBQ Sauce', 'Condiments', 5, 'ml', 4000.000, 500.000, 0.000, 0.000, 0.04, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(13, 'Ghost Pepper Sauce', 'Condiments', 5, 'ml', 2000.000, 300.000, 0.000, 0.000, 0.08, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(14, 'Tortilla Chips', 'Dry Goods', 6, 'kg', 15.000, 3.000, 0.000, 0.000, 30.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(15, 'Mozzarella', 'Dairy', 2, 'kg', 10.000, 2.000, 0.000, 0.000, 55.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(16, 'Onion Rings', 'Vegetables', 4, 'pcs', 200.000, 50.000, 0.000, 0.000, 5.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(17, 'Buffalo Sauce', 'Condiments', 5, 'ml', 3000.000, 400.000, 0.000, 0.000, 0.06, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(18, 'Garlic Rice', 'Rice', 9, 'cups', 100.000, 20.000, 0.000, 0.000, 10.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(19, 'Egg', 'Dairy', 2, 'pcs', 150.000, 30.000, 0.000, 0.000, 6.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(20, 'Beef Tapa', 'Meat', 1, 'pcs', 80.000, 15.000, 0.000, 0.000, 50.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(21, 'Longganisa', 'Meat', 1, 'pcs', 70.000, 15.000, 0.000, 0.000, 35.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(22, 'Iced Tea Powder', 'Beverages', 7, 'kg', 5.000, 1.000, 0.000, 0.000, 80.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(23, 'Lemon', 'Fruits', 8, 'pcs', 100.000, 20.000, 0.000, 0.000, 5.00, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(24, 'Caramel Syrup', 'Condiments', 5, 'ml', 3000.000, 500.000, 0.000, 0.000, 0.07, 'Active', 1, 0, NULL, '2026-05-08 17:07:40'),
(25, 'Milk', 'Dairy', 2, 'ml', 10000.000, 1000.000, 0.000, 0.000, 0.03, 'Active', 1, 0, NULL, '2026-05-08 17:07:40');

-- --------------------------------------------------------

--
-- Table structure for table `ingredients_backup`
--

CREATE TABLE `ingredients_backup` (
  `IngredientID` int(10) NOT NULL,
  `IngredientName` varchar(100) NOT NULL,
  `CategoryID` int(10) DEFAULT NULL,
  `UnitType` varchar(50) NOT NULL,
  `StockQuantity` decimal(10,2) NOT NULL DEFAULT 0.00,
  `LastRestockedDate` datetime DEFAULT NULL,
  `ExpirationDate` date DEFAULT NULL,
  `Remarks` varchar(255) DEFAULT NULL,
  `MinStockLevel` decimal(10,2) NOT NULL DEFAULT 0.00,
  `MaxStockLevel` decimal(10,2) NOT NULL DEFAULT 0.00,
  `IsActive` tinyint(1) NOT NULL DEFAULT 1,
  `BackupDate` datetime NOT NULL DEFAULT current_timestamp(),
  `BackupReason` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ingredients_backup`
--

INSERT INTO `ingredients_backup` (`IngredientID`, `IngredientName`, `CategoryID`, `UnitType`, `StockQuantity`, `LastRestockedDate`, `ExpirationDate`, `Remarks`, `MinStockLevel`, `MaxStockLevel`, `IsActive`, `BackupDate`, `BackupReason`) VALUES
(1, 'Beef Patty', 1, 'pcs', 150.00, '2026-05-01 08:00:00', '2026-05-15', 'Pre-migration backup', 30.00, 200.00, 1, '2026-05-01 00:00:00', 'Monthly backup'),
(2, 'Chicken Breast', 1, 'pcs', 120.00, '2026-05-01 08:00:00', '2026-05-15', 'Pre-migration backup', 25.00, 150.00, 1, '2026-05-01 00:00:00', 'Monthly backup'),
(3, 'Bacon', 1, 'pcs', 80.00, '2026-05-01 08:00:00', '2026-05-10', 'Pre-migration backup', 20.00, 100.00, 1, '2026-05-01 00:00:00', 'Monthly backup'),
(4, 'Cheddar Cheese', 2, 'pcs', 100.00, '2026-05-01 08:00:00', '2026-05-20', 'Pre-migration backup', 20.00, 120.00, 1, '2026-05-01 00:00:00', 'Monthly backup'),
(5, 'Swiss Cheese', 2, 'pcs', 60.00, '2026-05-01 08:00:00', '2026-05-20', 'Pre-migration backup', 15.00, 80.00, 1, '2026-05-01 00:00:00', 'Monthly backup');

-- --------------------------------------------------------

--
-- Table structure for table `ingredient_categories`
--

CREATE TABLE `ingredient_categories` (
  `CategoryID` int(11) NOT NULL,
  `CategoryName` varchar(100) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `createddate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `ingredient_categories`
--

INSERT INTO `ingredient_categories` (`CategoryID`, `CategoryName`, `description`, `createddate`) VALUES
(1, 'Meat', NULL, '2026-05-11 10:02:49'),
(2, 'Dairy', NULL, '2026-05-11 10:02:49'),
(3, 'Bread', NULL, '2026-05-11 10:02:49'),
(4, 'Vegetables', NULL, '2026-05-11 10:02:49'),
(5, 'Condiments', NULL, '2026-05-11 10:02:49'),
(6, 'Dry Goods', NULL, '2026-05-11 10:02:49'),
(7, 'Beverages', NULL, '2026-05-11 10:02:49'),
(8, 'Fruits', NULL, '2026-05-11 10:02:49'),
(9, 'Rice', NULL, '2026-05-11 10:02:49');

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `InventoryID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `StockQuantity` int(11) NOT NULL DEFAULT 0,
  `ReorderLevel` int(11) NOT NULL DEFAULT 10,
  `UnitType` varchar(50) DEFAULT NULL,
  `LastRestockedDate` datetime DEFAULT NULL,
  `ExpirationDate` date DEFAULT NULL,
  `SupplierID` int(11) DEFAULT NULL,
  `Remarks` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`InventoryID`, `ProductID`, `StockQuantity`, `ReorderLevel`, `UnitType`, `LastRestockedDate`, `ExpirationDate`, `SupplierID`, `Remarks`) VALUES
(1, 1, 85, 20, 'piece', '2025-04-28 08:00:00', '2025-05-05', 1, NULL),
(2, 2, 60, 15, 'piece', '2025-04-28 08:00:00', '2025-05-05', 1, NULL),
(3, 3, 70, 20, 'piece', '2025-04-28 08:00:00', '2025-05-05', 1, 'Check spice sauce stock weekly'),
(4, 4, 55, 15, 'piece', '2025-04-27 08:00:00', '2025-05-04', 1, NULL),
(5, 5, 40, 10, 'piece', '2025-04-27 08:00:00', '2025-05-04', 1, NULL),
(6, 6, 75, 20, 'piece', '2025-04-28 08:00:00', '2025-05-05', 1, NULL),
(7, 7, 50, 15, 'pack', '2025-04-26 08:00:00', '2025-05-10', 3, NULL),
(8, 8, 30, 10, 'piece', '2025-04-26 08:00:00', '2025-05-08', 3, NULL),
(9, 9, 45, 15, 'piece', '2025-04-26 08:00:00', '2025-05-08', 3, NULL),
(10, 10, 25, 10, 'piece', '2025-04-25 08:00:00', '2025-05-03', 3, 'Made to order — do not pre-bake'),
(11, 11, 100, 30, 'scoop', '2025-04-25 08:00:00', '2025-05-15', 3, NULL),
(12, 12, 200, 50, 'liter', '2025-04-29 08:00:00', '2025-05-06', 4, 'Bottomless — monitor daily usage'),
(13, 13, 90, 25, 'liter', '2025-04-29 08:00:00', '2025-05-06', 4, NULL),
(14, 14, 60, 20, 'cup', '2025-04-28 08:00:00', '2025-05-04', 4, NULL),
(15, 15, 80, 20, 'piece', '2025-04-27 08:00:00', '2025-05-05', 5, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `inventory_alerts`
--

CREATE TABLE `inventory_alerts` (
  `AlertID` int(11) NOT NULL,
  `AlertType` enum('Low Stock','Expiring Soon','Expired','Out of Stock','Overstocked') NOT NULL,
  `IngredientID` int(11) DEFAULT NULL,
  `BatchID` int(11) DEFAULT NULL,
  `AlertMessage` text DEFAULT NULL,
  `Severity` enum('Critical','Warning','Info') NOT NULL DEFAULT 'Warning',
  `IsResolved` tinyint(1) NOT NULL DEFAULT 0,
  `ResolvedDate` datetime DEFAULT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory_alerts`
--

INSERT INTO `inventory_alerts` (`AlertID`, `AlertType`, `IngredientID`, `BatchID`, `AlertMessage`, `Severity`, `IsResolved`, `ResolvedDate`, `CreatedDate`) VALUES
(1, 'Low Stock', 10, 1, 'Sauteed Mushrooms stock is below reorder level — only 8kg remaining', 'Warning', 0, NULL, '2026-05-09 08:00:00'),
(2, 'Expiring Soon', 6, 6, 'Brioche Bun batch BATCH-006 expires in 2 days on 2026-05-10', 'Critical', 0, NULL, '2026-05-09 08:00:00'),
(3, 'Low Stock', 9, 1, 'Caramelized Onions stock is critically low — only 10kg remaining', 'Warning', 1, '2026-05-09 10:00:00', '2026-05-08 08:00:00'),
(4, 'Expired', 3, 3, 'Bacon batch BATCH-003 has expired as of 2026-05-10', 'Critical', 0, NULL, '2026-05-10 00:00:00'),
(5, 'Out of Stock', 15, 1, 'Mozzarella is completely out of stock', 'Critical', 0, NULL, '2026-05-10 09:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `inventory_backup`
--

CREATE TABLE `inventory_backup` (
  `InventoryID` int(10) NOT NULL,
  `IngredientID` int(10) NOT NULL,
  `StockQuantity` decimal(10,2) NOT NULL DEFAULT 0.00,
  `UnitType` varchar(50) NOT NULL,
  `LastRestockedDate` datetime DEFAULT NULL,
  `ExpirationDate` date DEFAULT NULL,
  `Remarks` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp(),
  `UpdatedDate` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `BackupDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory_backup`
--

INSERT INTO `inventory_backup` (`InventoryID`, `IngredientID`, `StockQuantity`, `UnitType`, `LastRestockedDate`, `ExpirationDate`, `Remarks`, `CreatedDate`, `UpdatedDate`, `BackupDate`) VALUES
(1, 1, 150.00, 'pcs', '2026-05-01 08:00:00', '2026-05-15', 'Beef patty stock backup', '2026-05-01 08:00:00', '2026-05-01 08:00:00', '2026-05-01 00:00:00'),
(2, 2, 120.00, 'pcs', '2026-05-01 08:00:00', '2026-05-15', 'Chicken breast stock backup', '2026-05-01 08:00:00', '2026-05-01 08:00:00', '2026-05-01 00:00:00'),
(3, 3, 80.00, 'pcs', '2026-05-01 08:00:00', '2026-05-10', 'Bacon stock backup', '2026-05-01 08:00:00', '2026-05-01 08:00:00', '2026-05-01 00:00:00'),
(4, 4, 100.00, 'pcs', '2026-05-01 08:00:00', '2026-05-20', 'Cheddar cheese stock backup', '2026-05-01 08:00:00', '2026-05-01 08:00:00', '2026-05-01 00:00:00'),
(5, 5, 60.00, 'pcs', '2026-05-01 08:00:00', '2026-05-20', 'Swiss cheese stock backup', '2026-05-01 08:00:00', '2026-05-01 08:00:00', '2026-05-01 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `inventory_batches`
--

CREATE TABLE `inventory_batches` (
  `BatchID` int(11) NOT NULL,
  `IngredientID` int(11) NOT NULL,
  `BatchNumber` varchar(50) NOT NULL,
  `StockQuantity` decimal(12,3) NOT NULL DEFAULT 0.000,
  `OriginalQuantity` decimal(12,3) NOT NULL DEFAULT 0.000,
  `UnitType` varchar(20) NOT NULL,
  `CostPerUnit` decimal(12,2) NOT NULL DEFAULT 0.00,
  `TotalCost` decimal(10,2) DEFAULT 0.00,
  `PurchaseDate` date NOT NULL DEFAULT curdate(),
  `ExpirationDate` date DEFAULT NULL,
  `StorageLocation` varchar(100) DEFAULT NULL,
  `BatchStatus` enum('Active','Depleted','Expired','Discarded') NOT NULL DEFAULT 'Active',
  `Notes` text DEFAULT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp(),
  `UpdatedDate` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `inventory_batches`
--

INSERT INTO `inventory_batches` (`BatchID`, `IngredientID`, `BatchNumber`, `StockQuantity`, `OriginalQuantity`, `UnitType`, `CostPerUnit`, `TotalCost`, `PurchaseDate`, `ExpirationDate`, `StorageLocation`, `BatchStatus`, `Notes`, `CreatedDate`, `UpdatedDate`) VALUES
(1, 1, 'BATCH-001', 150.000, 150.000, 'pcs', 45.00, 0.00, '2026-05-01', '2026-05-15', 'Freezer A', 'Active', 'Beef patty stock', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(2, 2, 'BATCH-002', 120.000, 120.000, 'pcs', 38.00, 0.00, '2026-05-01', '2026-05-15', 'Freezer A', 'Active', 'Chicken breast stock', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(3, 3, 'BATCH-003', 80.000, 80.000, 'pcs', 25.00, 0.00, '2026-05-01', '2026-05-10', 'Freezer B', 'Active', 'Bacon stock', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(4, 4, 'BATCH-004', 100.000, 100.000, 'pcs', 12.00, 0.00, '2026-05-01', '2026-05-20', 'Chiller A', 'Active', 'Cheddar stock', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(5, 5, 'BATCH-005', 60.000, 60.000, 'pcs', 14.00, 0.00, '2026-05-01', '2026-05-20', 'Chiller A', 'Active', 'Swiss cheese stock', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(6, 6, 'BATCH-006', 200.000, 200.000, 'pcs', 8.00, 0.00, '2026-05-03', '2026-05-10', 'Dry Storage', 'Active', 'Brioche buns', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(7, 7, 'BATCH-007', 90.000, 90.000, 'pcs', 3.00, 0.00, '2026-05-05', '2026-05-12', 'Chiller B', 'Active', 'Fresh lettuce', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(8, 8, 'BATCH-008', 80.000, 80.000, 'pcs', 4.00, 0.00, '2026-05-05', '2026-05-12', 'Chiller B', 'Active', 'Fresh tomatoes', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(9, 18, 'BATCH-009', 86.000, 86.000, 'cups', 10.00, 0.00, '2026-05-04', NULL, 'Dry Storage', 'Active', 'Garlic rice supply', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(10, 19, 'BATCH-010', 136.000, 136.000, 'pcs', 6.00, 0.00, '2026-05-06', '2026-05-13', 'Chiller A', 'Active', 'Eggs', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(11, 20, 'BATCH-011', 75.000, 75.000, 'pcs', 50.00, 0.00, '2026-05-01', '2026-05-10', 'Freezer B', 'Active', 'Beef tapa', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(12, 21, 'BATCH-012', 52.000, 52.000, 'pcs', 35.00, 0.00, '2026-05-01', '2026-05-10', 'Freezer B', 'Active', 'Longganisa', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(13, 22, 'BATCH-013', 4.970, 4.970, 'kg', 80.00, 0.00, '2026-05-01', '2026-12-31', 'Dry Storage', 'Active', 'Iced tea powder', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(14, 23, 'BATCH-014', 98.000, 98.000, 'pcs', 5.00, 0.00, '2026-05-05', '2026-05-15', 'Chiller B', 'Active', 'Fresh lemons', '2026-05-08 17:08:34', '2026-05-11 10:01:29'),
(15, 25, 'BATCH-015', 10000.000, 10000.000, 'ml', 0.03, 0.00, '2026-05-06', '2026-05-20', 'Chiller A', 'Active', 'Fresh milk', '2026-05-08 17:08:34', '2026-05-11 10:01:29');

-- --------------------------------------------------------

--
-- Table structure for table `inventory_movement`
--

CREATE TABLE `inventory_movement` (
  `MovementID` int(11) NOT NULL,
  `MovementDate` datetime NOT NULL DEFAULT current_timestamp(),
  `IngredientID` int(11) NOT NULL,
  `BatchID` int(11) NOT NULL,
  `ChangeType` enum('ADD','DEDUCT','ADJUST','DISCARD','TRANSFER') NOT NULL,
  `QuantityChanged` decimal(12,3) NOT NULL,
  `StockBefore` decimal(12,3) NOT NULL,
  `StockAfter` decimal(12,3) NOT NULL,
  `UnitType` varchar(20) DEFAULT NULL,
  `Reason` varchar(255) DEFAULT NULL,
  `Source` enum('POS','WEBSITE','ADMIN','SYSTEM') NOT NULL,
  `SourceName` varchar(100) DEFAULT NULL,
  `ReferenceID` int(11) DEFAULT NULL,
  `ReferenceTable` varchar(100) DEFAULT NULL,
  `ReferenceNumber` varchar(50) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `ReservationID` int(11) DEFAULT NULL,
  `Notes` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory_movement`
--

INSERT INTO `inventory_movement` (`MovementID`, `MovementDate`, `IngredientID`, `BatchID`, `ChangeType`, `QuantityChanged`, `StockBefore`, `StockAfter`, `UnitType`, `Reason`, `Source`, `SourceName`, `ReferenceID`, `ReferenceTable`, `ReferenceNumber`, `OrderID`, `ReservationID`, `Notes`) VALUES
(1, '2026-05-08 11:30:00', 1, 1, 'DEDUCT', 2.000, 150.000, 148.000, 'pcs', 'Order', 'POS', 'Juan dela Cruz', 20, 'orders', 'VT-2026-000020-366', 20, NULL, 'Deducted 2 beef patties for Order #20'),
(2, '2026-05-08 21:19:00', 19, 10, 'DEDUCT', 4.000, 136.000, 132.000, 'pcs', 'Order', 'POS', 'Juan dela Cruz', 21, 'orders', 'VT-2026-000021-682', 21, NULL, 'Deducted 4 eggs for Order #21'),
(3, '2026-05-09 00:05:00', 20, 11, 'DEDUCT', 1.000, 75.000, 74.000, 'pcs', 'Reservation', 'POS', 'Juan dela Cruz', 18, 'reservation', NULL, NULL, 18, 'Deducted beef tapa for Reservation #18'),
(4, '2026-05-09 08:00:00', 6, 6, 'ADD', 50.000, 150.000, 200.000, 'pcs', 'Restock', 'ADMIN', 'Rico Bautista', NULL, NULL, 'PO-2026-001', NULL, NULL, 'Restocked brioche buns from supplier'),
(5, '2026-05-09 14:00:00', 3, 3, 'DISCARD', 5.000, 80.000, 75.000, 'pcs', 'Spoilage', 'ADMIN', 'Rico Bautista', NULL, NULL, 'DISC-2026-001', NULL, NULL, 'Discarded expired bacon strips');

-- --------------------------------------------------------

--
-- Stand-in structure for view `inventory_movement_summary`
-- (See below for the actual view)
--
CREATE TABLE `inventory_movement_summary` (
`movementday` date
,`ingredientid` int(11)
,`ingredientname` varchar(100)
,`stockquantity` decimal(12,3)
,`unittype` varchar(20)
,`expirationdate` date
,`status` varchar(12)
,`daysuntilexpiration` int(7)
,`lastrestockeddate` datetime
,`remarks` text
);

-- --------------------------------------------------------

--
-- Table structure for table `inventory_transactions_backup`
--

CREATE TABLE `inventory_transactions_backup` (
  `TransactionID` int(10) NOT NULL,
  `InventoryID` int(10) NOT NULL,
  `TransactionType` enum('Restock','Usage','Adjustment') NOT NULL,
  `QuantityChanged` decimal(10,2) NOT NULL,
  `StockBefore` decimal(10,2) NOT NULL,
  `StockAfter` decimal(10,2) NOT NULL,
  `ReferenceID` varchar(50) DEFAULT NULL,
  `Notes` text DEFAULT NULL,
  `TransactionDate` datetime NOT NULL DEFAULT current_timestamp(),
  `BackupDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory_transactions_backup`
--

INSERT INTO `inventory_transactions_backup` (`TransactionID`, `InventoryID`, `TransactionType`, `QuantityChanged`, `StockBefore`, `StockAfter`, `ReferenceID`, `Notes`, `TransactionDate`, `BackupDate`) VALUES
(1, 1, 'Restock', 50.00, 100.00, 150.00, 'PO-2026-001', 'Regular restock order', '2026-05-01 08:00:00', '2026-05-01 00:00:00'),
(2, 2, 'Usage', 10.00, 120.00, 110.00, 'ORD-2026-001', 'Used for order fulfillment', '2026-05-02 10:00:00', '2026-05-02 00:00:00'),
(3, 3, 'Adjustment', 5.00, 80.00, 75.00, 'ADJ-2026-001', 'Stock count adjustment', '2026-05-03 09:00:00', '2026-05-03 00:00:00'),
(4, 4, 'Restock', 30.00, 70.00, 100.00, 'PO-2026-002', 'Emergency restock', '2026-05-04 11:00:00', '2026-05-04 00:00:00'),
(5, 5, 'Usage', 15.00, 60.00, 45.00, 'ORD-2026-002', 'Used for reservation order', '2026-05-05 14:00:00', '2026-05-05 00:00:00');

-- --------------------------------------------------------

--
-- Stand-in structure for view `inventory_transaction_history`
-- (See below for the actual view)
--
CREATE TABLE `inventory_transaction_history` (
`transactionid` int(11)
,`inventoryid` int(11)
,`ingredientname` varchar(100)
,`transactiontype` enum('ADD','DEDUCT','ADJUST','DISCARD','TRANSFER')
,`quantitychanged` decimal(12,3)
,`stockbefore` decimal(12,3)
,`stockafter` decimal(12,3)
,`unittype` varchar(20)
,`notes` text
,`transactiondate` datetime
);

-- --------------------------------------------------------

--
-- Table structure for table `logs`
--

CREATE TABLE `logs` (
  `id` int(11) NOT NULL,
  `dt` datetime NOT NULL DEFAULT current_timestamp(),
  `user_accounts_id` int(11) DEFAULT NULL,
  `event` varchar(100) NOT NULL,
  `transactions` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `logs`
--

INSERT INTO `logs` (`id`, `dt`, `user_accounts_id`, `event`, `transactions`) VALUES
(1, '2026-05-08 10:00:00', 29, 'User Login', 'juan.delacruz logged into the Admin panel'),
(2, '2026-05-08 11:00:00', 29, 'Product Updated', 'Updated price of DJ Classic Burger from ₱139 to ₱149'),
(3, '2026-05-08 13:00:00', 33, 'User Created', 'New user account created for employee ID 8'),
(4, '2026-05-09 09:00:00', 29, 'Inventory Restocked', 'Restocked Beef Patty — added 50 pcs to inventory'),
(5, '2026-05-09 14:00:00', 33, 'Reservation Confirmed', 'Reservation ID 12 confirmed for Keldon Johnson Jr.');

-- --------------------------------------------------------

--
-- Table structure for table `orderdetails`
--

CREATE TABLE `orderdetails` (
  `OrderDetailID` int(11) NOT NULL,
  `OrderID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Quantity` int(4) NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL,
  `TotalPrice` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `orderdetails`
--

INSERT INTO `orderdetails` (`OrderDetailID`, `OrderID`, `ProductID`, `Quantity`, `UnitPrice`, `TotalPrice`) VALUES
(1, 1, 1, 2, 149.00, 298.00),
(2, 1, 12, 2, 69.00, 138.00),
(3, 1, 7, 1, 99.00, 99.00),
(4, 1, 10, 1, 89.00, 89.00),
(5, 2, 6, 1, 159.00, 159.00),
(6, 2, 13, 1, 59.00, 59.00),
(7, 3, 2, 2, 199.00, 398.00),
(8, 3, 12, 2, 69.00, 138.00),
(9, 3, 7, 1, 99.00, 99.00),
(10, 3, 8, 1, 89.00, 89.00),
(11, 3, 11, 1, 59.00, 59.00),
(12, 3, 13, 1, 59.00, 59.00),
(13, 4, 1, 1, 149.00, 149.00),
(14, 5, 3, 1, 169.00, 169.00),
(15, 5, 12, 2, 69.00, 138.00),
(16, 5, 9, 1, 79.00, 79.00),
(17, 6, 4, 1, 179.00, 179.00),
(18, 6, 13, 1, 59.00, 59.00),
(19, 7, 1, 1, 149.00, 149.00),
(20, 7, 6, 1, 159.00, 159.00),
(21, 7, 15, 1, 119.00, 119.00),
(22, 7, 12, 2, 69.00, 138.00),
(23, 7, 10, 1, 89.00, 89.00),
(24, 8, 2, 1, 199.00, 199.00),
(25, 8, 12, 1, 69.00, 69.00),
(26, 8, 10, 1, 89.00, 89.00),
(27, 9, 3, 1, 169.00, 169.00),
(28, 9, 13, 1, 59.00, 59.00),
(29, 10, 5, 1, 189.00, 189.00),
(30, 10, 7, 1, 99.00, 99.00),
(31, 10, 12, 2, 69.00, 138.00),
(32, 10, 11, 1, 59.00, 59.00),
(33, 11, 3, 1, 169.00, 169.00),
(34, 12, 1, 1, 149.00, 149.00),
(35, 12, 14, 1, 99.00, 99.00),
(36, 13, 2, 2, 199.00, 398.00),
(37, 13, 1, 2, 149.00, 298.00),
(38, 13, 15, 1, 119.00, 119.00),
(39, 13, 12, 3, 69.00, 207.00),
(40, 13, 7, 1, 99.00, 99.00),
(41, 14, 6, 1, 159.00, 159.00),
(42, 14, 13, 1, 59.00, 59.00),
(43, 15, 4, 1, 179.00, 179.00),
(44, 15, 12, 2, 69.00, 138.00),
(45, 15, 9, 1, 79.00, 79.00),
(49, 17, 1, 1, 149.00, 149.00),
(50, 17, 6, 1, 159.00, 159.00),
(51, 17, 12, 2, 69.00, 138.00),
(52, 18, 1, 1, 149.00, 149.00),
(53, 18, 6, 1, 159.00, 159.00),
(54, 20, 11, 1, 59.00, 59.00),
(55, 20, 10, 1, 89.00, 89.00),
(56, 21, 10, 1, 89.00, 89.00),
(57, 21, 11, 1, 59.00, 59.00),
(58, 21, 14, 1, 99.00, 99.00),
(59, 21, 13, 1, 59.00, 59.00),
(60, 22, 1, 1, 149.00, 149.00),
(61, 22, 12, 1, 69.00, 69.00),
(62, 23, 1, 1, 149.00, 149.00),
(63, 23, 12, 1, 69.00, 69.00),
(64, 24, 10, 1, 89.00, 89.00),
(65, 25, 11, 1, 59.00, 59.00),
(66, 26, 6, 1, 159.00, 159.00),
(67, 27, 6, 1, 159.00, 159.00),
(68, 27, 12, 1, 69.00, 69.00),
(69, 28, 11, 3, 59.00, 177.00),
(70, 28, 10, 1, 89.00, 89.00);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `OrderID` int(11) NOT NULL,
  `CustomerID` int(11) DEFAULT NULL,
  `OrderType` enum('Dine-in','Take out','Online') NOT NULL DEFAULT 'Dine-in',
  `OrderSource` varchar(50) DEFAULT 'POS',
  `WebsiteStatus` enum('Pending','Confirmed','Cancelled') DEFAULT NULL,
  `ReceiptNumber` varchar(20) DEFAULT NULL,
  `NumberOfDiners` int(3) DEFAULT NULL,
  `OrderDate` date NOT NULL,
  `OrderTime` time NOT NULL,
  `EmployeeID` int(11) DEFAULT NULL,
  `ItemsOrderedCount` int(4) NOT NULL,
  `TotalAmount` decimal(10,2) NOT NULL,
  `PaymentMethod` varchar(50) DEFAULT NULL,
  `OrderStatus` enum('Preparing','Served','Completed','Cancelled') NOT NULL DEFAULT 'Preparing',
  `Remarks` text DEFAULT NULL,
  `DeliveryAddress` text DEFAULT NULL,
  `SpecialRequests` text DEFAULT NULL,
  `OrderPriority` enum('Normal','Rush') NOT NULL DEFAULT 'Normal',
  `PreparationTimeEstimate` int(4) DEFAULT NULL,
  `SpecialRequestFlag` tinyint(1) NOT NULL DEFAULT 0,
  `CreatedDate` datetime DEFAULT current_timestamp(),
  `UpdatedDate` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`OrderID`, `CustomerID`, `OrderType`, `OrderSource`, `WebsiteStatus`, `ReceiptNumber`, `NumberOfDiners`, `OrderDate`, `OrderTime`, `EmployeeID`, `ItemsOrderedCount`, `TotalAmount`, `PaymentMethod`, `OrderStatus`, `Remarks`, `DeliveryAddress`, `SpecialRequests`, `OrderPriority`, `PreparationTimeEstimate`, `SpecialRequestFlag`, `CreatedDate`, `UpdatedDate`) VALUES
(1, 1, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250401-001', 3, '2025-04-01', '11:30:00', 2, 4, 556.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 15, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(2, 2, 'Take out', 'POS', 'Confirmed', 'RCP-20250401-002', NULL, '2025-04-01', '12:00:00', 2, 2, 268.00, 'Cash', 'Completed', 'Extra sauce on the side', NULL, 'No special requests', 'Normal', 10, 1, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(3, 3, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250402-001', 5, '2025-04-02', '13:15:00', 8, 6, 847.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 20, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(4, 4, 'Take out', 'POS', 'Confirmed', 'RCP-20250403-001', NULL, '2025-04-03', '10:45:00', 2, 1, 149.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 8, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(5, 5, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250403-002', 2, '2025-04-03', '19:00:00', 8, 3, 417.00, 'Cash', 'Completed', 'No onions please', NULL, 'No special requests', 'Normal', 12, 1, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(6, 6, 'Take out', 'POS', 'Confirmed', 'RCP-20250405-001', NULL, '2025-04-05', '14:30:00', 2, 2, 288.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Rush', 10, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(7, 7, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250407-001', 4, '2025-04-07', '12:00:00', 8, 5, 685.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 18, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(8, 8, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250410-001', 2, '2025-04-10', '20:00:00', 8, 3, 407.00, 'Cash', 'Completed', 'Celebrate birthday — candle', NULL, 'No special requests', 'Normal', 15, 1, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(9, 9, 'Take out', 'POS', 'Confirmed', 'RCP-20250412-001', NULL, '2025-04-12', '09:30:00', 2, 2, 228.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 8, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(10, 10, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250415-001', 3, '2025-04-15', '18:30:00', 8, 4, 606.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 15, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(11, 11, 'Take out', 'POS', 'Confirmed', 'RCP-20250418-001', NULL, '2025-04-18', '11:00:00', 2, 1, 169.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Rush', 8, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(12, 12, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250420-001', 1, '2025-04-20', '13:00:00', 8, 2, 248.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 10, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(13, 13, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250425-001', 6, '2025-04-25', '19:30:00', 8, 7, 978.00, 'Cash', 'Completed', 'Company dinner — split bill', NULL, 'No special requests', 'Normal', 25, 1, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(14, NULL, 'Take out', 'POS', 'Confirmed', 'RCP-20250428-001', NULL, '2025-04-28', '10:00:00', 2, 2, 268.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 10, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(15, 1, 'Dine-in', 'POS', 'Confirmed', 'RCP-20250430-001', 2, '2025-04-30', '12:30:00', 8, 3, 407.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 12, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(17, 18, 'Take out', 'POS', 'Confirmed', 'AUTO-17', NULL, '2026-05-07', '20:13:48', 1, 3, 446.00, 'Cash', 'Preparing', 'Source: Website | PICKUP | Requests: ', 'Pickup Order', 'No special requests', 'Normal', 15, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(18, 18, 'Take out', 'POS', 'Confirmed', 'AUTO-18', NULL, '2026-05-08', '18:36:23', 1, 2, 308.00, 'Cash', 'Completed', 'Source: Website | PICKUP | Requests: Testing', 'Pickup Order', 'No special requests', 'Normal', 15, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(20, NULL, 'Dine-in', 'POS', 'Confirmed', 'VT-2026-000020-366', 1, '2026-05-08', '21:02:26', 1, 2, 148.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 15, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(21, NULL, 'Dine-in', 'POS', 'Confirmed', 'VT-2026-000021-682', 1, '2026-05-08', '21:19:06', 1, 4, 306.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 15, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(22, 17, 'Take out', 'POS', 'Confirmed', 'AUTO-22', NULL, '2026-05-09', '11:25:20', 1, 2, 218.00, 'Cash', 'Completed', 'Source: Website | PICKUP | Requests: ', 'Pickup Order', 'No special requests', 'Normal', 15, 0, '2026-05-09 13:53:15', '2026-05-11 20:11:40'),
(23, 17, 'Take out', 'POS', 'Confirmed', 'AUTO-23', NULL, '2026-05-09', '13:55:40', 1, 2, 218.00, 'Cash', 'Served', 'Source: Website | PICKUP | Requests: Hi po', 'Pickup Order', 'No special requests', 'Normal', 15, 0, '2026-05-09 13:55:40', '2026-05-11 20:11:40'),
(24, NULL, 'Take out', 'POS', 'Confirmed', 'VT-2026-000024-471', NULL, '2026-05-09', '13:56:12', 1, 1, 89.00, 'Cash', 'Completed', 'N/A', NULL, 'No special requests', 'Normal', 15, 0, '2026-05-09 13:56:12', '2026-05-11 20:11:40'),
(25, NULL, 'Dine-in', 'POS', 'Confirmed', 'VT-2026-000025-302', 1, '2026-05-09', '14:27:19', 1, 1, 59.00, 'Cash', 'Preparing', 'N/A', NULL, 'No special requests', 'Normal', 15, 0, '2026-05-09 14:27:19', '2026-05-11 20:11:40'),
(26, 17, 'Take out', 'POS', 'Confirmed', 'AUTO-26', NULL, '2026-05-09', '14:27:59', 1, 1, 159.00, 'Cash', 'Preparing', 'Source: Website | PICKUP | Requests: ', 'Pickup Order', 'No special requests', 'Normal', 15, 0, '2026-05-09 14:27:59', '2026-05-11 20:11:40'),
(27, 17, 'Take out', 'POS', 'Confirmed', 'AUTO-27', NULL, '2026-05-09', '14:40:54', 1, 2, 228.00, 'Cash', 'Cancelled', 'Source: Website | PICKUP | Requests: ', 'Pickup Order', 'No special requests', 'Normal', 15, 0, '2026-05-09 14:40:54', '2026-05-11 20:11:40'),
(28, NULL, 'Dine-in', 'POS', 'Confirmed', 'VT-2026-000028-694', 1, '2026-05-09', '15:48:43', 1, 4, 266.00, 'Cash', 'Served', 'N/A', NULL, 'No special requests', 'Normal', 15, 0, '2026-05-09 15:48:43', '2026-05-11 20:11:40');

-- --------------------------------------------------------

--
-- Table structure for table `order_item_price_snapshot`
--

CREATE TABLE `order_item_price_snapshot` (
  `snapshot_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `price_at_order` decimal(10,2) NOT NULL,
  `quantity` int(11) NOT NULL DEFAULT 1,
  `date_recorded` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `order_item_price_snapshot`
--

INSERT INTO `order_item_price_snapshot` (`snapshot_id`, `order_id`, `product_id`, `price_at_order`, `quantity`, `date_recorded`) VALUES
(1, 1, 1, 149.00, 2, '2025-04-01 11:30:00'),
(2, 1, 12, 69.00, 2, '2025-04-01 11:30:00'),
(3, 2, 6, 159.00, 1, '2025-04-01 12:00:00'),
(4, 3, 2, 199.00, 2, '2025-04-02 13:15:00'),
(5, 3, 7, 99.00, 1, '2025-04-02 13:15:00');

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `PaymentID` int(11) NOT NULL,
  `OrderID` int(11) NOT NULL,
  `PaymentDate` datetime NOT NULL DEFAULT current_timestamp(),
  `PaymentMethod` enum('Cash','GCash') NOT NULL DEFAULT 'Cash',
  `PaymentStatus` enum('Pending','Completed','Refunded','Failed') NOT NULL DEFAULT 'Pending',
  `ReferenceNumber` varchar(100) DEFAULT NULL,
  `AmountPaid` decimal(10,2) NOT NULL,
  `PaymentSource` varchar(50) DEFAULT 'Website',
  `ProofOfPayment` varchar(255) DEFAULT NULL,
  `ReceiptFileName` varchar(255) DEFAULT NULL,
  `Notes` text DEFAULT NULL,
  `TransactionID` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payment`
--

INSERT INTO `payment` (`PaymentID`, `OrderID`, `PaymentDate`, `PaymentMethod`, `PaymentStatus`, `ReferenceNumber`, `AmountPaid`, `PaymentSource`, `ProofOfPayment`, `ReceiptFileName`, `Notes`, `TransactionID`) VALUES
(1, 1, '2025-04-01 12:15:00', 'Cash', 'Completed', NULL, 556.00, 'Website', NULL, NULL, NULL, NULL),
(2, 2, '2025-04-01 12:30:00', 'Cash', 'Completed', NULL, 268.00, 'Website', NULL, NULL, NULL, NULL),
(3, 3, '2025-04-02 14:00:00', 'Cash', 'Completed', NULL, 847.00, 'Website', NULL, NULL, NULL, NULL),
(4, 4, '2025-04-03 11:00:00', 'Cash', 'Completed', NULL, 149.00, 'Website', NULL, NULL, NULL, NULL),
(5, 5, '2025-04-03 19:45:00', 'Cash', 'Completed', NULL, 417.00, 'Website', NULL, NULL, NULL, NULL),
(6, 6, '2025-04-05 14:50:00', 'Cash', 'Completed', NULL, 288.00, 'Website', NULL, NULL, NULL, NULL),
(7, 7, '2025-04-07 13:00:00', 'Cash', 'Completed', NULL, 685.00, 'Website', NULL, NULL, NULL, NULL),
(8, 8, '2025-04-10 20:45:00', 'Cash', 'Completed', NULL, 407.00, 'Website', NULL, NULL, NULL, NULL),
(9, 9, '2025-04-12 09:50:00', 'Cash', 'Completed', NULL, 228.00, 'Website', NULL, NULL, NULL, NULL),
(10, 10, '2025-04-15 19:15:00', 'Cash', 'Completed', NULL, 606.00, 'Website', NULL, NULL, NULL, NULL),
(11, 11, '2025-04-18 11:15:00', 'Cash', 'Completed', NULL, 169.00, 'Website', NULL, NULL, NULL, NULL),
(12, 12, '2025-04-20 13:30:00', 'Cash', 'Completed', NULL, 248.00, 'Website', NULL, NULL, NULL, NULL),
(13, 13, '2025-04-25 20:30:00', 'Cash', 'Completed', NULL, 978.00, 'Website', NULL, NULL, NULL, NULL),
(14, 14, '2025-04-28 10:20:00', 'Cash', 'Completed', NULL, 268.00, 'Website', NULL, NULL, NULL, NULL),
(15, 15, '2025-04-30 13:00:00', 'Cash', 'Completed', NULL, 407.00, 'Website', NULL, NULL, NULL, NULL),
(16, 17, '2026-05-07 20:13:48', 'GCash', 'Pending', NULL, 446.00, 'Website', 'uploads/order_receipts/2026/05/order_18_1778156028_4778.jpg', 'order_18_1778156028_4778.jpg', 'GCash receipt uploaded - awaiting verification', NULL),
(17, 18, '2026-05-08 18:36:23', 'GCash', 'Pending', NULL, 308.00, 'Website', 'uploads/order_receipts/2026/05/order_18_1778236583_8441.jpg', 'order_18_1778236583_8441.jpg', 'GCash receipt uploaded - awaiting verification', NULL),
(18, 20, '2026-05-08 21:02:26', 'Cash', 'Completed', NULL, 148.00, 'POS', NULL, NULL, NULL, 'POS-20260508-000020'),
(19, 21, '2026-05-08 21:19:06', 'Cash', 'Completed', NULL, 306.00, 'POS', NULL, NULL, NULL, 'POS-20260508-000021'),
(20, 22, '2026-05-09 11:25:20', 'GCash', 'Pending', NULL, 218.00, 'Website', 'uploads/order_receipts/2026/05/order_17_1778297120_6226.jpg', 'order_17_1778297120_6226.jpg', 'GCash receipt uploaded - awaiting verification', NULL),
(21, 23, '2026-05-09 13:55:40', 'GCash', 'Pending', NULL, 218.00, 'Website', 'uploads/order_receipts/2026/05/order_17_1778306140_9112.jpg', 'order_17_1778306140_9112.jpg', 'GCash receipt uploaded - awaiting verification', NULL),
(22, 24, '2026-05-09 13:56:12', 'Cash', 'Completed', NULL, 89.00, 'POS', NULL, NULL, NULL, 'POS-20260509-000024'),
(23, 25, '2026-05-11 12:17:33', 'Cash', 'Completed', NULL, 59.00, 'POS', NULL, NULL, NULL, 'POS-20260509-000025'),
(24, 26, '2026-05-09 14:27:59', 'GCash', 'Pending', NULL, 159.00, 'Website', 'uploads/order_receipts/2026/05/order_17_1778308079_2596.jpg', 'order_17_1778308079_2596.jpg', 'GCash receipt uploaded - awaiting verification', NULL),
(25, 27, '2026-05-09 14:40:54', 'GCash', '', NULL, 228.00, 'Website', 'uploads/order_receipts/2026/05/order_17_1778308854_3986.jpg', 'order_17_1778308854_3986.jpg', 'GCash receipt uploaded - awaiting verification', NULL),
(26, 28, '2026-05-11 12:17:18', 'Cash', 'Completed', NULL, 266.00, 'POS', NULL, NULL, NULL, 'POS-20260509-000028');

-- --------------------------------------------------------

--
-- Table structure for table `payroll`
--

CREATE TABLE `payroll` (
  `PayrollID` int(11) NOT NULL,
  `EmployeeID` int(11) NOT NULL,
  `PayPeriodStart` date NOT NULL,
  `PayPeriodEnd` date NOT NULL,
  `BasicSalary` decimal(10,2) NOT NULL DEFAULT 0.00,
  `Overtime` decimal(10,2) NOT NULL DEFAULT 0.00,
  `Bonuses` decimal(10,2) DEFAULT 0.00,
  `processedby` int(11) DEFAULT NULL,
  `ProcessedDate` datetime DEFAULT NULL,
  `notes` text DEFAULT NULL,
  `CreatedDate` datetime DEFAULT current_timestamp(),
  `Deductions` decimal(10,2) NOT NULL DEFAULT 0.00,
  `NetPay` decimal(10,2) NOT NULL,
  `HoursWorked` decimal(10,2) DEFAULT 0.00,
  `HourlyRate` decimal(10,2) DEFAULT 0.00,
  `PaymentDate` date NOT NULL DEFAULT curdate(),
  `Status` enum('No Record','Pending','Approved','Paid','Unpaid') NOT NULL DEFAULT 'No Record'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payroll`
--

INSERT INTO `payroll` (`PayrollID`, `EmployeeID`, `PayPeriodStart`, `PayPeriodEnd`, `BasicSalary`, `Overtime`, `Bonuses`, `processedby`, `ProcessedDate`, `notes`, `CreatedDate`, `Deductions`, `NetPay`, `HoursWorked`, `HourlyRate`, `PaymentDate`, `Status`) VALUES
(1, 1, '2025-04-01', '2025-04-30', 25000.00, 500.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 1500.00, 24000.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(2, 2, '2025-04-01', '2025-04-30', 18000.00, 200.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 1100.00, 17100.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(3, 3, '2025-04-01', '2025-04-30', 20000.00, 750.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 1300.00, 19450.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(4, 4, '2025-04-01', '2025-04-30', 12000.00, 0.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 800.00, 11200.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(5, 5, '2025-04-01', '2025-04-30', 20000.00, 1000.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 1300.00, 19700.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(6, 6, '2025-04-01', '2025-04-30', 12000.00, 0.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 800.00, 11200.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(7, 7, '2025-04-01', '2025-04-30', 22000.00, 300.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 1400.00, 20900.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(8, 8, '2025-04-01', '2025-04-30', 18000.00, 0.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 1100.00, 16900.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(9, 9, '2025-04-01', '2025-04-30', 18000.00, 0.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 1100.00, 16900.00, 12.00, 0.00, '2025-04-30', 'Pending'),
(10, 10, '2025-04-01', '2025-04-30', 12000.00, 0.00, 0.00, NULL, NULL, NULL, '2026-05-11 09:36:58', 800.00, 11200.00, 0.00, 0.00, '2025-04-30', 'Paid'),
(11, 1, '0000-00-00', '0000-00-00', 15000.00, 1200.00, 500.00, NULL, '2026-05-01 08:00:00', NULL, '2026-05-11 22:16:31', 0.00, 0.00, 160.00, 93.75, '2026-05-11', 'Pending'),
(12, 2, '0000-00-00', '0000-00-00', 18000.00, 1500.00, 800.00, NULL, '2026-05-02 08:30:00', NULL, '2026-05-11 22:16:31', 0.00, 0.00, 170.00, 105.88, '2026-05-11', 'Approved'),
(13, 3, '0000-00-00', '0000-00-00', 20000.00, 1800.00, 1000.00, NULL, '2026-05-03 09:00:00', NULL, '2026-05-11 22:16:31', 0.00, 0.00, 175.00, 114.29, '2026-05-11', 'Paid'),
(14, 4, '0000-00-00', '0000-00-00', 17000.00, 900.00, 300.00, NULL, '2026-05-04 09:30:00', NULL, '2026-05-11 22:16:31', 0.00, 0.00, 165.00, 103.03, '2026-05-11', 'Unpaid'),
(15, 5, '0000-00-00', '0000-00-00', 16000.00, 1000.00, 400.00, NULL, '2026-05-05 10:00:00', NULL, '2026-05-11 22:16:31', 0.00, 0.00, 168.00, 95.24, '2026-05-11', 'No Record');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductID` int(11) NOT NULL,
  `ProductName` varchar(100) NOT NULL,
  `ProductCode` varchar(50) DEFAULT NULL,
  `Category` enum('Burgers','Sides','Silog Meals','Drinks') NOT NULL,
  `CategoryID` int(11) DEFAULT NULL,
  `Description` text DEFAULT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Availability` enum('Available','Not Available') NOT NULL DEFAULT 'Available',
  `ServingSize` enum('Regular','Large') DEFAULT NULL,
  `DateAdded` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdated` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Notes` varchar(255) DEFAULT NULL,
  `PopularityTag` enum('Best Seller','Regular') NOT NULL DEFAULT 'Regular',
  `MealTime` enum('Breakfast','Lunch','Dinner','All Day') DEFAULT NULL,
  `OrderCount` int(10) NOT NULL DEFAULT 0,
  `PrepTime` int(11) DEFAULT NULL COMMENT 'Preparation time in minutes',
  `Image` varchar(255) DEFAULT NULL,
  `SpicyLevel` enum('Mild','Medium','Hot','None') NOT NULL DEFAULT 'None'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ProductID`, `ProductName`, `ProductCode`, `Category`, `CategoryID`, `Description`, `Price`, `Availability`, `ServingSize`, `DateAdded`, `LastUpdated`, `Notes`, `PopularityTag`, `MealTime`, `OrderCount`, `PrepTime`, `Image`, `SpicyLevel`) VALUES
(1, 'DJ Classic Burger', '', '', NULL, 'Juicy beef patty with lettuce, tomato, and house beef sauce', 200.00, 'Available', 'Large', '2024-01-10 08:00:00', '2026-05-11 02:04:46', NULL, 'Best Seller', 'All Day', 320, 15, NULL, 'None'),
(2, 'Double Smash Burger', NULL, 'Burgers', NULL, 'Two smashed beef patties with cheddar and caramelized onions', 199.00, 'Available', 'Large', '2024-01-10 08:00:00', '2026-05-08 09:38:40', 'Customer favorite', 'Best Seller', 'All Day', 210, NULL, 'doublesmash.jpg', 'None'),
(3, 'Spicy Inferno Burger', NULL, 'Burgers', NULL, 'Crispy fried chicken with ghost pepper sauce', 169.00, 'Available', 'Regular', '2024-01-15 08:00:00', '2026-05-08 09:38:40', 'Very spicy — diner advisory', 'Best Seller', 'All Day', 180, NULL, 'spicyinferno.jpg', 'Hot'),
(4, 'BBQ Bacon Burger', NULL, 'Burgers', NULL, 'Beef patty with crispy bacon, BBQ sauce, and pickles', 179.00, 'Available', 'Regular', '2024-01-15 08:00:00', '2026-05-08 09:38:40', NULL, 'Regular', 'Lunch', 145, NULL, 'bbqbacon.jpg', 'Mild'),
(5, 'Mushroom Swiss Burger', NULL, 'Burgers', NULL, 'Beef patty topped with sautéed mushrooms and Swiss cheese', 189.00, 'Available', 'Regular', '2024-02-01 08:00:00', '2026-05-08 09:38:40', NULL, 'Regular', 'All Day', 90, NULL, 'mushroomswiss.jpg', 'None'),
(6, 'Crispy Chicken Sandwich', NULL, 'Sides', NULL, 'Crispy fried chicken breast in a toasted brioche bun', 159.00, 'Available', 'Regular', '2024-02-01 08:00:00', '2026-05-08 09:38:41', NULL, 'Best Seller', 'All Day', 260, NULL, 'crispychicken.jpg', 'None'),
(7, 'Loaded Nachos', NULL, 'Sides', NULL, 'Tortilla chips topped with cheese sauce, jalapeños, and salsa', 99.00, 'Available', 'Regular', '2024-02-10 08:00:00', '2026-05-08 09:38:41', 'Good for sharing', 'Best Seller', 'All Day', 195, NULL, 'loadednachos.jpg', 'Medium'),
(8, 'Mozzarella Sticks', NULL, 'Sides', NULL, 'Fried mozzarella sticks served with marinara dipping sauce', 89.00, 'Available', 'Regular', '2024-02-10 08:00:00', '2026-05-08 09:38:41', NULL, 'Regular', 'All Day', 120, NULL, 'mozzarella.jpg', 'None'),
(9, 'Onion Rings', NULL, 'Sides', NULL, 'Golden fried onion rings with ranch dipping sauce', 79.00, 'Available', 'Regular', '2024-02-15 08:00:00', '2026-05-08 09:38:41', NULL, 'Regular', 'All Day', 98, NULL, 'onionrings.jpg', 'None'),
(10, 'Tapsilog', NULL, 'Silog Meals', NULL, 'Tapsi with itlog', 89.00, 'Available', 'Regular', '2024-03-01 08:00:00', '2026-05-08 09:39:27', 'Made to order — 10 min wait', 'Best Seller', 'All Day', 150, NULL, 'lavacake.jpg', 'None'),
(11, 'Porksilog', NULL, 'Silog Meals', NULL, 'Two scoops of creamy vanilla ice cream', 59.00, 'Available', 'Regular', '2024-03-01 08:00:00', '2026-05-08 09:39:42', NULL, 'Regular', 'All Day', 80, NULL, 'icecream.jpg', 'None'),
(12, 'Chicksilog', NULL, 'Silog Meals', NULL, 'Chicken with Itlog', 69.00, 'Available', 'Large', '2024-01-10 08:00:00', '2026-05-08 09:40:05', 'Bottomless for dine-in only', 'Best Seller', 'All Day', 410, NULL, 'icedtea.jpg', 'None'),
(13, 'Fresh Lemonade', NULL, 'Drinks', NULL, 'Freshly squeezed lemonade with a hint of mint', 59.00, 'Available', 'Regular', '2024-01-10 08:00:00', '2026-05-08 09:38:41', NULL, 'Regular', 'All Day', 175, NULL, 'lemonade.jpg', 'None'),
(14, 'Salted Caramel Shake', NULL, 'Drinks', NULL, 'Thick milkshake with salted caramel drizzle', 99.00, 'Available', 'Large', '2024-03-15 08:00:00', '2026-05-08 09:38:41', NULL, 'Regular', 'All Day', 110, NULL, 'caramelshake.jpg', 'None'),
(15, 'Buffalo Wings (6pcs)', NULL, 'Drinks', NULL, '6-piece crispy chicken wings tossed in buffalo sauce', 119.00, 'Available', 'Regular', '2024-04-01 08:00:00', '2026-05-08 09:38:41', NULL, 'Best Seller', 'All Day', 230, NULL, 'buffalowings.jpg', 'Medium'),
(16, 'DJ Fire Fries', NULL, '', NULL, 'Masarap', 59.00, 'Available', '', '2026-05-11 01:28:33', '2026-05-11 01:28:33', NULL, 'Regular', 'All Day', 0, 15, 'uploads/products/product_16_20260511012833.jpg', 'None');

-- --------------------------------------------------------

--
-- Table structure for table `product_ingredients`
--

CREATE TABLE `product_ingredients` (
  `ProductIngredientID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `IngredientID` int(11) NOT NULL,
  `QuantityUsed` decimal(12,3) NOT NULL DEFAULT 0.000,
  `UnitType` varchar(20) NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp(),
  `UpdatedDate` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `product_ingredients`
--

INSERT INTO `product_ingredients` (`ProductIngredientID`, `ProductID`, `IngredientID`, `QuantityUsed`, `UnitType`, `CreatedDate`, `UpdatedDate`) VALUES
(1, 1, 1, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(2, 1, 6, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(3, 1, 7, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(4, 1, 8, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(5, 1, 11, 30.000, 'ml', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(6, 2, 1, 2.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(7, 2, 6, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(8, 2, 4, 2.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(9, 2, 9, 0.050, 'kg', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(10, 3, 2, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(11, 3, 6, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(12, 3, 13, 40.000, 'ml', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(13, 4, 1, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(14, 4, 3, 2.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(15, 4, 6, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(16, 4, 12, 30.000, 'ml', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(17, 5, 1, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(18, 5, 6, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(19, 5, 5, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(20, 5, 10, 0.050, 'kg', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(21, 6, 14, 0.150, 'kg', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(22, 6, 4, 2.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(23, 7, 15, 0.100, 'kg', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(24, 8, 16, 5.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(25, 9, 2, 6.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(26, 9, 17, 50.000, 'ml', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(27, 10, 20, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(28, 10, 18, 1.000, 'cups', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(29, 10, 19, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(30, 11, 21, 2.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(31, 11, 18, 1.000, 'cups', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(32, 11, 19, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(33, 12, 2, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(34, 12, 18, 1.000, 'cups', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(35, 12, 19, 1.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(36, 13, 22, 0.030, 'kg', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(37, 14, 23, 2.000, 'pcs', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(38, 15, 24, 30.000, 'ml', '2026-05-10 19:36:39', '2026-05-10 19:36:39'),
(39, 15, 25, 200.000, 'ml', '2026-05-10 19:36:39', '2026-05-10 19:36:39');

-- --------------------------------------------------------

--
-- Table structure for table `receipt_items`
--

CREATE TABLE `receipt_items` (
  `ReceiptItemID` int(10) NOT NULL COMMENT 'Unique receipt item identifier',
  `ReceiptID` int(10) NOT NULL COMMENT 'Reference to sales_receipts table',
  `ItemName` varchar(200) NOT NULL COMMENT 'Name of the product/item',
  `ProductID` int(10) DEFAULT NULL COMMENT 'Reference to products table if exists',
  `Quantity` int(10) NOT NULL COMMENT 'Quantity ordered',
  `UnitPrice` decimal(10,2) NOT NULL COMMENT 'Price per unit',
  `LineTotal` decimal(10,2) NOT NULL COMMENT 'Total for this line (Quantity × UnitPrice)',
  `BatchNumber` varchar(50) DEFAULT NULL COMMENT 'Batch number deducted from inventory',
  `QtyDeducted` int(10) NOT NULL COMMENT 'Quantity deducted from inventory',
  `ItemCategory` varchar(100) DEFAULT NULL COMMENT 'Category of item (e.g., Food, Beverage, Combo)',
  `ItemType` enum('Single','Combo','Add-on') DEFAULT 'Single' COMMENT 'Type of item',
  `CreatedDate` datetime DEFAULT current_timestamp() COMMENT 'Record creation timestamp',
  `Notes` text DEFAULT NULL COMMENT 'Additional notes about this item'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Line items for each sales receipt';

--
-- Dumping data for table `receipt_items`
--

INSERT INTO `receipt_items` (`ReceiptItemID`, `ReceiptID`, `ItemName`, `ProductID`, `Quantity`, `UnitPrice`, `LineTotal`, `BatchNumber`, `QtyDeducted`, `ItemCategory`, `ItemType`, `CreatedDate`, `Notes`) VALUES
(1, 1, 'Coca-Cola (1.5L)', NULL, 1, 45.00, 45.00, 'BATCH-CC01', 1, 'Beverage', 'Single', '2025-11-27 11:32:00', NULL),
(2, 1, 'Nissin Cup Noodles', NULL, 2, 15.00, 30.00, 'BATCH-NISSIN03', 2, 'Food', 'Single', '2025-11-27 11:32:00', NULL),
(3, 1, 'Tender Juicy Hotdog (Pack)', NULL, 1, 120.00, 120.00, 'BATCH-TJ02', 1, 'Food', 'Single', '2025-11-27 11:32:00', NULL),
(4, 2, 'Porksilog', 11, 1, 59.00, 59.00, 'N/A', 1, 'Silog Meals', 'Single', '2026-05-08 21:02:26', NULL),
(5, 2, 'Tapsilog', 10, 1, 89.00, 89.00, 'N/A', 1, 'Silog Meals', 'Single', '2026-05-08 21:02:26', NULL),
(6, 3, 'Tapsilog', 10, 1, 89.00, 89.00, 'N/A', 1, 'Silog Meals', 'Single', '2026-05-08 21:19:06', NULL),
(7, 3, 'Porksilog', 11, 1, 59.00, 59.00, 'N/A', 1, 'Silog Meals', 'Single', '2026-05-08 21:19:06', NULL),
(8, 3, 'Salted Caramel Shake', 14, 1, 99.00, 99.00, 'N/A', 1, 'Drinks', 'Single', '2026-05-08 21:19:06', NULL),
(9, 3, 'Fresh Lemonade', 13, 1, 59.00, 59.00, 'N/A', 1, 'Drinks', 'Single', '2026-05-08 21:19:06', NULL),
(10, 4, 'Tapsilog', 10, 1, 89.00, 89.00, 'N/A', 1, 'Silog Meals', 'Single', '2026-05-09 13:56:12', NULL),
(11, 5, 'Porksilog', 11, 1, 59.00, 59.00, 'N/A', 1, 'Silog Meals', 'Single', '2026-05-09 14:27:19', NULL),
(12, 6, 'Porksilog', 11, 3, 59.00, 177.00, 'N/A', 3, 'Silog Meals', 'Single', '2026-05-09 15:48:43', NULL),
(13, 6, 'Tapsilog', 10, 1, 89.00, 89.00, 'N/A', 1, 'Silog Meals', 'Single', '2026-05-09 15:48:43', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `ReservationID` int(11) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `FullName` varchar(255) DEFAULT NULL,
  `ContactNumber` varchar(50) DEFAULT NULL,
  `ReservationType` varchar(50) DEFAULT 'Walk-in',
  `EventType` varchar(50) DEFAULT 'General',
  `ReservationCode` varchar(20) DEFAULT NULL,
  `ReservationDate` date NOT NULL,
  `EventDate` date DEFAULT NULL COMMENT 'Actual event date',
  `ReservationTime` time NOT NULL,
  `EndTime` time DEFAULT NULL,
  `NumberOfGuests` int(11) DEFAULT 1,
  `ProductSelection` text DEFAULT NULL,
  `DeliveryAddress` text DEFAULT NULL,
  `DeliveryOption` varchar(50) DEFAULT 'Pickup',
  `NumberOfCustomers` int(4) NOT NULL,
  `SpecialRequests` text DEFAULT NULL,
  `DepositAmount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `SubTotal` decimal(10,2) NOT NULL DEFAULT 0.00,
  `CateringFee` decimal(10,2) NOT NULL DEFAULT 0.00,
  `EquipmentRentalFee` decimal(10,2) NOT NULL DEFAULT 0.00,
  `TotalPrice` decimal(10,2) NOT NULL DEFAULT 0.00,
  `ReservationStatus` enum('Pending','Confirmed','Cancelled','Completed') NOT NULL DEFAULT 'Pending',
  `CreatedAt` datetime NOT NULL DEFAULT current_timestamp(),
  `AssignedStaffID` int(11) DEFAULT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `SeatType` enum('Indoor','Outdoor') DEFAULT 'Indoor',
  `UpdatedAt` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `TableNumber` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reservation`
--

INSERT INTO `reservation` (`ReservationID`, `CustomerID`, `FullName`, `ContactNumber`, `ReservationType`, `EventType`, `ReservationCode`, `ReservationDate`, `EventDate`, `ReservationTime`, `EndTime`, `NumberOfGuests`, `ProductSelection`, `DeliveryAddress`, `DeliveryOption`, `NumberOfCustomers`, `SpecialRequests`, `DepositAmount`, `SubTotal`, `CateringFee`, `EquipmentRentalFee`, `TotalPrice`, `ReservationStatus`, `CreatedAt`, `AssignedStaffID`, `Notes`, `SeatType`, `UpdatedAt`, `TableNumber`) VALUES
(1, 3, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0001', '2025-05-10', NULL, '12:00:00', NULL, 1, NULL, NULL, 'Pickup', 30, 'Vegetarian option for 2 guests', 0.00, 0.00, 0.00, 0.00, 0.00, 'Confirmed', '2025-04-20 09:00:00', 4, 'Deposit received — ₱2,000', 'Indoor', '2025-04-22 10:00:00', 'T-01'),
(2, 5, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0002', '2025-05-15', NULL, '18:00:00', NULL, 1, NULL, NULL, 'Pickup', 50, 'Birthday celebration — request for cake table', 0.00, 0.00, 0.00, 0.00, 0.00, 'Confirmed', '2025-04-22 10:30:00', 6, 'Coordinate with florist for table setup', 'Indoor', '2025-04-23 08:00:00', 'T-02'),
(3, 7, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0003', '2025-05-18', NULL, '11:00:00', NULL, 1, NULL, NULL, 'Pickup', 15, NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 'Confirmed', '2025-04-25 14:00:00', 4, NULL, 'Outdoor', '2025-04-25 14:00:00', 'T-05'),
(4, 10, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0004', '2025-05-20', NULL, '19:30:00', NULL, 1, NULL, NULL, 'Pickup', 20, 'Allergy note: 2 guests are lactose intolerant', 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2025-04-27 11:00:00', NULL, 'Awaiting staff assignment', 'Indoor', '2025-04-27 11:00:00', NULL),
(5, 13, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0005', '2025-05-22', NULL, '12:00:00', NULL, 1, NULL, NULL, 'Pickup', 60, 'Company anniversary — need projector setup area', 0.00, 0.00, 0.00, 0.00, 0.00, 'Confirmed', '2025-04-28 08:00:00', 7, 'VIP guests — prepare extra seating', 'Indoor', '2025-04-29 09:00:00', 'T-01'),
(6, 15, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0006', '2025-05-25', NULL, '17:00:00', NULL, 1, NULL, NULL, 'Pickup', 10, 'Request for outdoor garden area', 0.00, 0.00, 0.00, 0.00, 0.00, 'Confirmed', '2025-04-28 15:00:00', 6, NULL, 'Outdoor', '2025-04-28 15:00:00', 'T-06'),
(7, 1, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0007', '2025-06-01', NULL, '13:00:00', NULL, 1, NULL, NULL, 'Pickup', 8, NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2025-04-30 10:00:00', NULL, NULL, 'Indoor', '2025-04-30 10:00:00', NULL),
(8, 9, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0008', '2025-06-05', NULL, '18:30:00', NULL, 1, NULL, NULL, 'Pickup', 25, 'Debut celebration — request for photo wall backdrop', 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2025-04-30 11:00:00', NULL, 'Customer will visit for Ocular', 'Indoor', '2025-04-30 11:00:00', NULL),
(9, 4, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0009', '2025-04-15', NULL, '12:00:00', NULL, 1, NULL, NULL, 'Pickup', 5, NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 'Completed', '2025-04-10 09:00:00', 4, NULL, 'Outdoor', '2025-04-15 14:00:00', 'T-04'),
(10, 2, NULL, NULL, 'Walk-in', 'General', 'RES-2025-0010', '2025-04-20', NULL, '19:00:00', NULL, 1, NULL, NULL, 'Pickup', 12, 'Need separate table for kids', 0.00, 0.00, 0.00, 0.00, 0.00, 'Cancelled', '2025-04-12 10:00:00', 6, 'Cancelled by customer — full refund', 'Indoor', '2025-04-14 09:00:00', NULL),
(11, 16, NULL, NULL, 'Walk-in', 'General', NULL, '2026-05-07', NULL, '10:00:00', NULL, 1, NULL, NULL, 'Pickup', 50, 'No Spice', 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2026-05-07 15:33:10', NULL, 'Event: birthday | Phone: 09886545589 | Delivery: Pickup | Address: ', 'Indoor', '2026-05-07 15:33:10', NULL),
(12, 17, NULL, NULL, 'Walk-in', 'General', NULL, '2026-05-08', NULL, '19:00:00', NULL, 1, NULL, NULL, 'Pickup', 10, 'Masarap sana yan', 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2026-05-07 16:27:10', NULL, 'Event: indoor | Phone: 09886545555 | Delivery: Pickup | Address: ', 'Indoor', '2026-05-07 16:27:10', NULL),
(13, 17, NULL, NULL, 'Walk-in', 'General', NULL, '2026-05-08', NULL, '19:00:00', NULL, 1, NULL, NULL, 'Pickup', 3, 'No kiss pls', 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2026-05-07 20:01:59', NULL, 'Event: outdoor | Phone: 09886545555 | Delivery: Pickup | Address: ', 'Indoor', '2026-05-07 20:01:59', NULL),
(14, 19, NULL, '09887865555', 'Walk-in', 'Indoor', NULL, '2026-05-09', NULL, '23:08:29', NULL, 3, 'Tapsilog (1), Porksilog (1)', NULL, NULL, 0, NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 'Completed', '2026-05-08 23:08:57', NULL, NULL, 'Indoor', '2026-05-09 12:35:56', NULL),
(15, 19, NULL, '09887865555', 'Walk-in', 'Indoor', NULL, '2026-05-09', NULL, '23:08:29', NULL, 3, 'Tapsilog (1), Porksilog (1)', NULL, NULL, 0, 'No kiss', 0.00, 0.00, 0.00, 0.00, 0.00, 'Completed', '2026-05-08 23:09:09', NULL, NULL, 'Indoor', '2026-05-09 12:36:03', NULL),
(16, 20, NULL, '09876665453', 'Walk-in', 'Indoor', NULL, '2026-05-09', NULL, '23:45:05', NULL, 4, 'Porksilog (1)', NULL, NULL, 0, 'I canoot', 0.00, 0.00, 0.00, 0.00, 0.00, 'Cancelled', '2026-05-08 23:45:43', NULL, NULL, 'Indoor', '2026-05-09 12:44:50', NULL),
(17, 20, NULL, '09876665453', 'Walk-in', 'Indoor', NULL, '2026-05-09', NULL, '23:45:05', NULL, 4, 'Porksilog (1), Salted Caramel Shake (1)', NULL, NULL, 0, 'I canoot', 0.00, 0.00, 0.00, 0.00, 0.00, 'Cancelled', '2026-05-08 23:53:05', NULL, NULL, 'Indoor', '2026-05-09 16:04:18', NULL),
(19, 22, NULL, '09887775643', 'Walk-in', 'Indoor', NULL, '2026-05-09', NULL, '23:32:19', NULL, 1, 'Porksilog (1)', NULL, NULL, 0, 'Washington', 0.00, 0.00, 0.00, 0.00, 0.00, 'Completed', '2026-05-09 11:33:04', NULL, NULL, 'Indoor', '2026-05-09 12:44:47', NULL),
(20, 23, NULL, '09999888767', 'Walk-in', 'Indoor', NULL, '2026-05-09', NULL, '15:06:19', NULL, 9, 'Porksilog (2), Tapsilog (1)', NULL, NULL, 0, 'No', 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2026-05-09 13:07:01', NULL, NULL, 'Indoor', '2026-05-11 13:16:09', NULL),
(21, 17, NULL, NULL, 'Walk-in', 'General', NULL, '2026-05-12', NULL, '11:00:00', NULL, 1, NULL, NULL, 'Pickup', 12, 'Crush ko si ann', 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2026-05-11 22:23:33', NULL, 'Event: indoor | Phone: 09886545555 | Delivery: Pickup | Address: ', 'Indoor', '2026-05-11 22:23:33', NULL),
(22, 24, NULL, '09888786565', 'Walk-in', 'Indoor', NULL, '2026-05-12', NULL, '22:52:27', NULL, 2, 'Chicksilog (1), Porksilog (1)', NULL, NULL, 0, 'I love you Boss Madam ko', 0.00, 0.00, 0.00, 0.00, 0.00, 'Pending', '2026-05-11 22:53:22', NULL, NULL, 'Indoor', '2026-05-11 22:53:22', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `reservationpayment`
--

CREATE TABLE `reservationpayment` (
  `ReservationPaymentID` int(11) NOT NULL,
  `ReservationID` int(11) NOT NULL,
  `PaymentDate` datetime NOT NULL DEFAULT current_timestamp(),
  `PaymentMethod` enum('Cash') NOT NULL DEFAULT 'Cash',
  `PaymentStatus` enum('Pending','Completed','Refunded','Failed') NOT NULL DEFAULT 'Pending',
  `AmountPaid` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reservationpayment`
--

INSERT INTO `reservationpayment` (`ReservationPaymentID`, `ReservationID`, `PaymentDate`, `PaymentMethod`, `PaymentStatus`, `AmountPaid`) VALUES
(1, 1, '2025-04-20 09:30:00', 'Cash', 'Completed', 2000.00),
(2, 2, '2025-04-22 11:00:00', 'Cash', 'Completed', 3000.00),
(3, 3, '2025-04-25 14:30:00', 'Cash', 'Completed', 1500.00),
(4, 5, '2025-04-28 08:30:00', 'Cash', 'Completed', 5000.00),
(5, 6, '2025-04-28 15:30:00', 'Cash', 'Completed', 1000.00),
(6, 9, '2025-04-10 09:15:00', 'Cash', 'Completed', 750.00),
(7, 10, '2025-04-12 10:30:00', 'Cash', 'Refunded', 500.00),
(8, 7, '2025-04-30 10:30:00', 'Cash', 'Pending', 0.00),
(9, 11, '2026-05-07 15:33:10', 'Cash', 'Pending', 368.00),
(10, 12, '2026-05-07 16:27:10', 'Cash', 'Pending', 696.00),
(11, 13, '2026-05-07 20:01:59', 'Cash', 'Pending', 457.00),
(12, 21, '2026-05-11 22:23:33', 'Cash', 'Pending', 527.00);

-- --------------------------------------------------------

--
-- Table structure for table `reservation_items`
--

CREATE TABLE `reservation_items` (
  `ReservationItemID` int(11) NOT NULL,
  `ReservationID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `ProductName` varchar(100) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL,
  `TotalPrice` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reservation_items`
--

INSERT INTO `reservation_items` (`ReservationItemID`, `ReservationID`, `ProductID`, `ProductName`, `Quantity`, `UnitPrice`, `TotalPrice`) VALUES
(1, 11, 2, 'Double Smash Burger', 1, 199.00, 199.00),
(2, 11, 3, 'Spicy Inferno Burger', 1, 169.00, 169.00),
(3, 12, 2, 'Double Smash Burger', 1, 199.00, 199.00),
(4, 12, 3, 'Spicy Inferno Burger', 2, 169.00, 338.00),
(5, 12, 6, 'Crispy Chicken Sandwich', 1, 159.00, 159.00),
(6, 13, 2, 'Double Smash Burger', 1, 199.00, 199.00),
(7, 13, 3, 'Spicy Inferno Burger', 1, 169.00, 169.00),
(8, 13, 8, 'Mozzarella Sticks', 1, 89.00, 89.00),
(14, 19, 11, 'Porksilog', 1, 59.00, 59.00),
(15, 20, 11, 'Porksilog', 2, 59.00, 118.00),
(16, 20, 10, 'Tapsilog', 1, 89.00, 89.00),
(17, 21, 3, 'Spicy Inferno Burger', 1, 169.00, 169.00),
(18, 21, 4, 'BBQ Bacon Burger', 2, 179.00, 358.00),
(19, 22, 12, 'Chicksilog', 1, 69.00, 69.00),
(20, 22, 11, 'Porksilog', 1, 59.00, 59.00);

-- --------------------------------------------------------

--
-- Stand-in structure for view `review_statistics`
-- (See below for the actual view)
--
CREATE TABLE `review_statistics` (
`total_reviews` bigint(21)
,`approved_reviews` decimal(22,0)
,`pending_reviews` decimal(22,0)
,`rejected_reviews` decimal(22,0)
,`avg_overall_rating` decimal(13,2)
,`avg_food_taste` decimal(13,2)
,`avg_portion_size` decimal(13,2)
,`avg_customer_service` decimal(13,2)
,`avg_ambience` decimal(13,2)
,`avg_cleanliness` decimal(13,2)
,`five_star_count` decimal(22,0)
,`four_star_count` decimal(22,0)
,`three_star_count` decimal(22,0)
,`two_star_count` decimal(22,0)
,`one_star_count` decimal(22,0)
);

-- --------------------------------------------------------

--
-- Table structure for table `sales_receipts`
--

CREATE TABLE `sales_receipts` (
  `ReceiptID` int(10) NOT NULL COMMENT 'Unique receipt identifier',
  `OrderNumber` varchar(50) NOT NULL COMMENT 'Unique order/receipt number (e.g., VT-2025-001238)',
  `ReceiptDate` date NOT NULL COMMENT 'Date of transaction',
  `ReceiptTime` time NOT NULL COMMENT 'Time of transaction',
  `EmployeeID` int(10) DEFAULT NULL COMMENT 'Reference to employee table',
  `CashierName` varchar(100) DEFAULT NULL COMMENT 'Name of cashier/employee',
  `CustomerID` int(10) DEFAULT NULL COMMENT 'Reference to customers table',
  `CustomerName` varchar(200) DEFAULT 'Walk-in Customer' COMMENT 'Customer name',
  `CustomerType` enum('Walk-in','Online','Reservation') DEFAULT 'Walk-in' COMMENT 'Type of customer',
  `Subtotal` decimal(10,2) NOT NULL COMMENT 'Subtotal before tax/discount',
  `TaxAmount` decimal(10,2) DEFAULT 0.00 COMMENT 'Tax amount applied',
  `DiscountAmount` decimal(10,2) DEFAULT 0.00 COMMENT 'Discount amount applied',
  `TotalAmount` decimal(10,2) NOT NULL COMMENT 'Final total amount',
  `PaymentMethod` enum('CASH','CARD','GCASH','PAYMAYA','BANK_TRANSFER') NOT NULL COMMENT 'Method of payment',
  `AmountGiven` decimal(10,2) DEFAULT NULL COMMENT 'Amount given by customer',
  `ChangeAmount` decimal(10,2) DEFAULT NULL COMMENT 'Change returned to customer',
  `TransactionStatus` enum('Completed','Cancelled','Refunded') DEFAULT 'Completed' COMMENT 'Status of transaction',
  `OrderSource` enum('POS','WEBSITE','RESERVATION') DEFAULT 'POS' COMMENT 'Source of order',
  `CreatedDate` datetime DEFAULT current_timestamp() COMMENT 'Record creation timestamp',
  `UpdatedDate` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp() COMMENT 'Last update timestamp',
  `Notes` text DEFAULT NULL COMMENT 'Additional notes about transaction'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Main sales receipt/invoice records';

--
-- Dumping data for table `sales_receipts`
--

INSERT INTO `sales_receipts` (`ReceiptID`, `OrderNumber`, `ReceiptDate`, `ReceiptTime`, `EmployeeID`, `CashierName`, `CustomerID`, `CustomerName`, `CustomerType`, `Subtotal`, `TaxAmount`, `DiscountAmount`, `TotalAmount`, `PaymentMethod`, `AmountGiven`, `ChangeAmount`, `TransactionStatus`, `OrderSource`, `CreatedDate`, `UpdatedDate`, `Notes`) VALUES
(1, 'VT-2025-001238', '2025-11-27', '11:32:00', NULL, 'Staff 01', NULL, 'Walk-in Customer', 'Walk-in', 225.00, 27.00, 0.00, 252.00, 'CASH', 300.00, 48.00, 'Completed', 'POS', '2025-11-27 11:32:00', '2026-05-08 17:20:05', NULL),
(2, 'VT-2026-000020-366', '2026-05-08', '21:02:26', NULL, 'POS Cashier', NULL, 'Walk-in Customer', 'Walk-in', 148.00, 0.00, 0.00, 148.00, 'CASH', 200.00, 52.00, 'Completed', 'POS', '2026-05-08 21:02:26', '2026-05-08 21:02:26', NULL),
(3, 'VT-2026-000021-682', '2026-05-08', '21:19:06', NULL, 'POS Cashier', NULL, 'Walk-in Customer', 'Walk-in', 306.00, 0.00, 0.00, 306.00, 'CASH', 320.00, 14.00, 'Completed', 'POS', '2026-05-08 21:19:06', '2026-05-08 21:19:06', NULL),
(4, 'VT-2026-000024-471', '2026-05-09', '13:56:12', NULL, 'POS Cashier', NULL, 'Walk-in Customer', 'Walk-in', 89.00, 0.00, 0.00, 89.00, 'CASH', 100.00, 11.00, 'Completed', 'POS', '2026-05-09 13:56:12', '2026-05-09 13:56:12', NULL),
(5, 'VT-2026-000025-302', '2026-05-09', '14:27:19', NULL, 'POS Cashier', NULL, 'Walk-in Customer', 'Walk-in', 59.00, 0.00, 0.00, 59.00, 'CASH', 100.00, 41.00, 'Completed', 'POS', '2026-05-09 14:27:19', '2026-05-09 14:27:19', NULL),
(6, 'VT-2026-000028-694', '2026-05-09', '15:48:43', NULL, 'POS Cashier', NULL, 'Walk-in Customer', 'Walk-in', 266.00, 0.00, 0.00, 266.00, 'CASH', 300.00, 34.00, 'Completed', 'POS', '2026-05-09 15:48:43', '2026-05-09 15:48:43', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `SupplierID` int(11) NOT NULL,
  `SupplierName` varchar(100) NOT NULL,
  `ContactNumber` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`SupplierID`, `SupplierName`, `ContactNumber`, `Email`) VALUES
(1, 'Prime Meat Distributors', '02-8123-4567', 'sales@primemeat.ph'),
(2, 'Fresh Bun Bakery Supply', '02-8234-5678', 'orders@freshbun.ph'),
(3, 'QC Veggie & Produce', '02-8345-6789', 'supply@qcveggie.ph'),
(4, 'Beverages Central Corp.', '02-8456-7890', 'info@beveragescentral.ph'),
(5, 'Golden Fryer Ingredients', '02-8567-8901', 'orders@goldenfryer.ph');

-- --------------------------------------------------------

--
-- Table structure for table `user_accounts`
--

CREATE TABLE `user_accounts` (
  `id` int(11) NOT NULL,
  `employee_id` int(11) DEFAULT NULL,
  `name` varchar(100) NOT NULL,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `type` int(11) NOT NULL DEFAULT 1,
  `UserRole` varchar(50) DEFAULT NULL COMMENT 'Admin or Staff',
  `position` varchar(100) DEFAULT NULL,
  `status` varchar(50) DEFAULT 'Active',
  `IsActive` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user_accounts`
--

INSERT INTO `user_accounts` (`id`, `employee_id`, `name`, `FirstName`, `LastName`, `username`, `password`, `type`, `UserRole`, `position`, `status`, `IsActive`, `created_at`) VALUES
(29, 1, 'Juan dela Cruz', 'Juan', 'Cruz', 'juan.delacruz', 'Wj7VoVOy/+7ytLNAvim/Yw==', 1, 'Admin', 'Manager', 'Active', 1, '2026-05-08 10:36:31'),
(30, 2, 'Maria Santos', 'Maria', 'Santos', 'maria.santos', '1234', 2, 'Staff', 'Cashier', 'Active', 1, '2026-05-08 10:36:31'),
(31, 3, 'Carlo Reyes', 'Carlo', 'Reyes', 'carlo.reyes', '1234', 2, 'Staff', 'Waiter', 'Active', 1, '2026-05-08 10:36:31'),
(32, 4, 'Anna Villanueva', 'Anna', 'Villanueva', 'anna.villanueva', '1234', 2, 'Staff', 'Kitchen Crew', 'Active', 1, '2026-05-08 10:36:31'),
(33, 5, 'Rico Bautista', 'Rico', 'Bautista', 'rico.bautista', '1234', 1, 'Admin', 'Supervisor', 'Active', 1, '2026-05-08 10:36:31'),
(34, 6, 'Liza Mendoza', 'Liza', 'Mendoza', 'liza.mendoza', '1234', 2, 'Staff', 'Waiter', 'Inactive', 0, '2026-05-08 10:36:31'),
(36, 8, 'Clarissa Tan', NULL, NULL, 'clarissa.tan@djsburger.com', '1234', 2, NULL, 'Staff', 'Active', 1, '2026-05-11 14:31:04');

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_cashier_performance`
-- (See below for the actual view)
--
CREATE TABLE `v_cashier_performance` (
`EmployeeID` int(10)
,`CashierName` varchar(100)
,`ReceiptDate` date
,`TransactionCount` bigint(21)
,`TotalSales` decimal(32,2)
,`AverageTransaction` decimal(14,6)
,`MinTransaction` decimal(10,2)
,`MaxTransaction` decimal(10,2)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_daily_sales_summary`
-- (See below for the actual view)
--
CREATE TABLE `v_daily_sales_summary` (
`SalesDate` date
,`TotalReceipts` bigint(21)
,`TotalSubtotal` decimal(32,2)
,`TotalTax` decimal(32,2)
,`TotalDiscounts` decimal(32,2)
,`TotalSales` decimal(32,2)
,`AverageSale` decimal(14,6)
,`ActiveCashiers` bigint(21)
,`CashTransactions` decimal(22,0)
,`CardTransactions` decimal(22,0)
,`GCashTransactions` decimal(22,0)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_receipt_details`
-- (See below for the actual view)
--
CREATE TABLE `v_receipt_details` (
`ReceiptID` int(10)
,`OrderNumber` varchar(50)
,`ReceiptDate` date
,`ReceiptTime` time
,`CashierName` varchar(100)
,`CustomerName` varchar(200)
,`CustomerType` enum('Walk-in','Online','Reservation')
,`ItemName` varchar(200)
,`Quantity` int(10)
,`UnitPrice` decimal(10,2)
,`LineTotal` decimal(10,2)
,`BatchNumber` varchar(50)
,`QtyDeducted` int(10)
,`Subtotal` decimal(10,2)
,`TaxAmount` decimal(10,2)
,`DiscountAmount` decimal(10,2)
,`TotalAmount` decimal(10,2)
,`PaymentMethod` enum('CASH','CARD','GCASH','PAYMAYA','BANK_TRANSFER')
,`AmountGiven` decimal(10,2)
,`ChangeAmount` decimal(10,2)
,`TransactionStatus` enum('Completed','Cancelled','Refunded')
);

-- --------------------------------------------------------

--
-- Structure for view `approved_customer_reviews`
--
DROP TABLE IF EXISTS `approved_customer_reviews`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `approved_customer_reviews`  AS SELECT `cf`.`FeedbackID` AS `reviewid`, `cf`.`CustomerID` AS `customerid`, concat(`c`.`FirstName`,' ',`c`.`LastName`) AS `displayname`, `c`.`FirstName` AS `firstname`, round(`cf`.`OverallRating`,1) AS `overallrating`, `cf`.`FoodTasteRating` AS `foodtasterating`, `cf`.`PortionSizeRating` AS `portionsizerating`, `cf`.`ServiceRating` AS `customerservicerating`, `cf`.`AmbienceRating` AS `ambiencerating`, `cf`.`CleanlinessRating` AS `cleanlinessrating`, `cf`.`FoodTasteComment` AS `foodtastecomment`, `cf`.`PortionSizeComment` AS `portionsizecomment`, `cf`.`ServiceComment` AS `customerservicecomment`, `cf`.`AmbienceComment` AS `ambiencecomment`, `cf`.`CleanlinessComment` AS `cleanlinesscomment`, `cf`.`ReviewMessage` AS `generalcomment`, `cf`.`CreatedDate` AS `createddate`, `cf`.`ApprovedDate` AS `approveddate` FROM (`customer_feedback` `cf` left join `customer` `c` on(`cf`.`CustomerID` = `c`.`CustomerID`)) WHERE `cf`.`Status` = 'Approved' ;

-- --------------------------------------------------------

--
-- Structure for view `customer_statistics`
--
DROP TABLE IF EXISTS `customer_statistics`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customer_statistics`  AS SELECT count(0) AS `total_customers`, sum(case when `customer`.`AccountStatus` = 'Active' then 1 else 0 end) AS `active_customers`, sum(case when `customer`.`AccountStatus` = 'Suspended' then 1 else 0 end) AS `suspended_customers`, sum(case when `customer`.`CustomerType` = 'Online' then 1 else 0 end) AS `online_customers`, round(avg(`customer`.`SatisfactionRating`),6) AS `average_satisfaction`, sum(`customer`.`TotalOrdersCount`) AS `total_orders`, sum(`customer`.`ReservationCount`) AS `total_reservations` FROM `customer` ;

-- --------------------------------------------------------

--
-- Structure for view `inventory_movement_summary`
--
DROP TABLE IF EXISTS `inventory_movement_summary`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `inventory_movement_summary`  AS SELECT cast(`im`.`MovementDate` as date) AS `movementday`, `i`.`IngredientID` AS `ingredientid`, `i`.`IngredientName` AS `ingredientname`, `i`.`StockQuantity` AS `stockquantity`, `i`.`UnitType` AS `unittype`, `ib`.`ExpirationDate` AS `expirationdate`, CASE WHEN `i`.`StockQuantity` <= 0 THEN 'Out of Stock' WHEN `i`.`StockQuantity` <= `i`.`ReorderLevel` THEN 'Low Stock' ELSE 'Sufficient' END AS `status`, to_days(`ib`.`ExpirationDate`) - to_days(curdate()) AS `daysuntilexpiration`, `ib`.`CreatedDate` AS `lastrestockeddate`, `im`.`Notes` AS `remarks` FROM ((`inventory_movement` `im` left join `ingredients` `i` on(`im`.`IngredientID` = `i`.`IngredientID`)) left join `inventory_batches` `ib` on(`im`.`BatchID` = `ib`.`BatchID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `inventory_transaction_history`
--
DROP TABLE IF EXISTS `inventory_transaction_history`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `inventory_transaction_history`  AS SELECT `im`.`MovementID` AS `transactionid`, `ib`.`BatchID` AS `inventoryid`, `i`.`IngredientName` AS `ingredientname`, `im`.`ChangeType` AS `transactiontype`, `im`.`QuantityChanged` AS `quantitychanged`, `im`.`StockBefore` AS `stockbefore`, `im`.`StockAfter` AS `stockafter`, `im`.`UnitType` AS `unittype`, `im`.`Notes` AS `notes`, `im`.`MovementDate` AS `transactiondate` FROM ((`inventory_movement` `im` left join `ingredients` `i` on(`im`.`IngredientID` = `i`.`IngredientID`)) left join `inventory_batches` `ib` on(`im`.`BatchID` = `ib`.`BatchID`)) ORDER BY `im`.`MovementDate` DESC ;

-- --------------------------------------------------------

--
-- Structure for view `review_statistics`
--
DROP TABLE IF EXISTS `review_statistics`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `review_statistics`  AS SELECT count(0) AS `total_reviews`, sum(case when `customer_feedback`.`Status` = 'Approved' then 1 else 0 end) AS `approved_reviews`, sum(case when `customer_feedback`.`Status` = 'Pending' then 1 else 0 end) AS `pending_reviews`, sum(case when `customer_feedback`.`Status` = 'Rejected' then 1 else 0 end) AS `rejected_reviews`, round(avg(`customer_feedback`.`OverallRating`),2) AS `avg_overall_rating`, round(avg(`customer_feedback`.`FoodTasteRating`),2) AS `avg_food_taste`, round(avg(`customer_feedback`.`PortionSizeRating`),2) AS `avg_portion_size`, round(avg(`customer_feedback`.`ServiceRating`),2) AS `avg_customer_service`, round(avg(`customer_feedback`.`AmbienceRating`),2) AS `avg_ambience`, round(avg(`customer_feedback`.`CleanlinessRating`),2) AS `avg_cleanliness`, sum(case when `customer_feedback`.`OverallRating` = 5 then 1 else 0 end) AS `five_star_count`, sum(case when `customer_feedback`.`OverallRating` = 4 then 1 else 0 end) AS `four_star_count`, sum(case when `customer_feedback`.`OverallRating` = 3 then 1 else 0 end) AS `three_star_count`, sum(case when `customer_feedback`.`OverallRating` = 2 then 1 else 0 end) AS `two_star_count`, sum(case when `customer_feedback`.`OverallRating` = 1 then 1 else 0 end) AS `one_star_count` FROM `customer_feedback` ;

-- --------------------------------------------------------

--
-- Structure for view `v_cashier_performance`
--
DROP TABLE IF EXISTS `v_cashier_performance`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_cashier_performance`  AS SELECT `sales_receipts`.`EmployeeID` AS `EmployeeID`, `sales_receipts`.`CashierName` AS `CashierName`, `sales_receipts`.`ReceiptDate` AS `ReceiptDate`, count(0) AS `TransactionCount`, sum(`sales_receipts`.`TotalAmount`) AS `TotalSales`, avg(`sales_receipts`.`TotalAmount`) AS `AverageTransaction`, min(`sales_receipts`.`TotalAmount`) AS `MinTransaction`, max(`sales_receipts`.`TotalAmount`) AS `MaxTransaction` FROM `sales_receipts` WHERE `sales_receipts`.`TransactionStatus` = 'Completed' GROUP BY `sales_receipts`.`EmployeeID`, `sales_receipts`.`CashierName`, `sales_receipts`.`ReceiptDate` ORDER BY `sales_receipts`.`ReceiptDate` DESC, sum(`sales_receipts`.`TotalAmount`) DESC ;

-- --------------------------------------------------------

--
-- Structure for view `v_daily_sales_summary`
--
DROP TABLE IF EXISTS `v_daily_sales_summary`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_daily_sales_summary`  AS SELECT `sales_receipts`.`ReceiptDate` AS `SalesDate`, count(0) AS `TotalReceipts`, sum(`sales_receipts`.`Subtotal`) AS `TotalSubtotal`, sum(`sales_receipts`.`TaxAmount`) AS `TotalTax`, sum(`sales_receipts`.`DiscountAmount`) AS `TotalDiscounts`, sum(`sales_receipts`.`TotalAmount`) AS `TotalSales`, avg(`sales_receipts`.`TotalAmount`) AS `AverageSale`, count(distinct `sales_receipts`.`EmployeeID`) AS `ActiveCashiers`, sum(case when `sales_receipts`.`PaymentMethod` = 'CASH' then 1 else 0 end) AS `CashTransactions`, sum(case when `sales_receipts`.`PaymentMethod` = 'CARD' then 1 else 0 end) AS `CardTransactions`, sum(case when `sales_receipts`.`PaymentMethod` = 'GCASH' then 1 else 0 end) AS `GCashTransactions` FROM `sales_receipts` WHERE `sales_receipts`.`TransactionStatus` = 'Completed' GROUP BY `sales_receipts`.`ReceiptDate` ORDER BY `sales_receipts`.`ReceiptDate` DESC ;

-- --------------------------------------------------------

--
-- Structure for view `v_receipt_details`
--
DROP TABLE IF EXISTS `v_receipt_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_receipt_details`  AS SELECT `sr`.`ReceiptID` AS `ReceiptID`, `sr`.`OrderNumber` AS `OrderNumber`, `sr`.`ReceiptDate` AS `ReceiptDate`, `sr`.`ReceiptTime` AS `ReceiptTime`, `sr`.`CashierName` AS `CashierName`, `sr`.`CustomerName` AS `CustomerName`, `sr`.`CustomerType` AS `CustomerType`, `ri`.`ItemName` AS `ItemName`, `ri`.`Quantity` AS `Quantity`, `ri`.`UnitPrice` AS `UnitPrice`, `ri`.`LineTotal` AS `LineTotal`, `ri`.`BatchNumber` AS `BatchNumber`, `ri`.`QtyDeducted` AS `QtyDeducted`, `sr`.`Subtotal` AS `Subtotal`, `sr`.`TaxAmount` AS `TaxAmount`, `sr`.`DiscountAmount` AS `DiscountAmount`, `sr`.`TotalAmount` AS `TotalAmount`, `sr`.`PaymentMethod` AS `PaymentMethod`, `sr`.`AmountGiven` AS `AmountGiven`, `sr`.`ChangeAmount` AS `ChangeAmount`, `sr`.`TransactionStatus` AS `TransactionStatus` FROM (`sales_receipts` `sr` left join `receipt_items` `ri` on(`sr`.`ReceiptID` = `ri`.`ReceiptID`)) ORDER BY `sr`.`ReceiptDate` DESC, `sr`.`ReceiptTime` DESC ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `activity_logs`
--
ALTER TABLE `activity_logs`
  ADD PRIMARY KEY (`LogID`),
  ADD KEY `idx_user_type` (`UserType`),
  ADD KEY `idx_action_category` (`ActionCategory`),
  ADD KEY `idx_timestamp` (`Timestamp`),
  ADD KEY `idx_user_id` (`UserID`),
  ADD KEY `idx_source_system` (`SourceSystem`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`CustomerID`);

--
-- Indexes for table `customers_archive`
--
ALTER TABLE `customers_archive`
  ADD PRIMARY KEY (`CustomerID`);

--
-- Indexes for table `customer_feedback`
--
ALTER TABLE `customer_feedback`
  ADD PRIMARY KEY (`FeedbackID`),
  ADD KEY `fk_feedback_customer` (`CustomerID`);

--
-- Indexes for table `customer_logs`
--
ALTER TABLE `customer_logs`
  ADD PRIMARY KEY (`LogID`),
  ADD KEY `fk_custlog_customer` (`CustomerID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`EmployeeID`),
  ADD UNIQUE KEY `uq_employee_email` (`Email`);

--
-- Indexes for table `employeeattendance`
--
ALTER TABLE `employeeattendance`
  ADD PRIMARY KEY (`AttendanceID`),
  ADD KEY `fk_attendance_employee` (`EmployeeID`);

--
-- Indexes for table `gcash_receipts`
--
ALTER TABLE `gcash_receipts`
  ADD PRIMARY KEY (`ReceiptID`),
  ADD KEY `fk_gcash_respayment` (`ReservationPaymentID`);

--
-- Indexes for table `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`IngredientID`),
  ADD KEY `fk_ingredient_category` (`CategoryID`);

--
-- Indexes for table `ingredients_backup`
--
ALTER TABLE `ingredients_backup`
  ADD PRIMARY KEY (`IngredientID`);

--
-- Indexes for table `ingredient_categories`
--
ALTER TABLE `ingredient_categories`
  ADD PRIMARY KEY (`CategoryID`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`InventoryID`),
  ADD KEY `fk_inventory_product` (`ProductID`),
  ADD KEY `fk_inventory_supplier` (`SupplierID`);

--
-- Indexes for table `inventory_alerts`
--
ALTER TABLE `inventory_alerts`
  ADD PRIMARY KEY (`AlertID`),
  ADD KEY `fk_alert_ingredient` (`IngredientID`);

--
-- Indexes for table `inventory_backup`
--
ALTER TABLE `inventory_backup`
  ADD PRIMARY KEY (`InventoryID`);

--
-- Indexes for table `inventory_batches`
--
ALTER TABLE `inventory_batches`
  ADD PRIMARY KEY (`BatchID`),
  ADD UNIQUE KEY `uq_inventory_batches_batchnumber` (`BatchNumber`),
  ADD KEY `idx_inventory_batches_status` (`IngredientID`,`BatchStatus`);

--
-- Indexes for table `inventory_movement`
--
ALTER TABLE `inventory_movement`
  ADD PRIMARY KEY (`MovementID`),
  ADD KEY `IngredientID` (`IngredientID`),
  ADD KEY `BatchID` (`BatchID`);

--
-- Indexes for table `inventory_transactions_backup`
--
ALTER TABLE `inventory_transactions_backup`
  ADD PRIMARY KEY (`TransactionID`);

--
-- Indexes for table `logs`
--
ALTER TABLE `logs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_logs_user` (`user_accounts_id`);

--
-- Indexes for table `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD PRIMARY KEY (`OrderDetailID`),
  ADD KEY `fk_orderdetails_order` (`OrderID`),
  ADD KEY `fk_orderdetails_product` (`ProductID`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`OrderID`),
  ADD UNIQUE KEY `uq_orders_receipt` (`ReceiptNumber`),
  ADD KEY `fk_orders_customer` (`CustomerID`),
  ADD KEY `fk_orders_employee` (`EmployeeID`),
  ADD KEY `idx_order_source` (`OrderSource`),
  ADD KEY `idx_order_type` (`OrderType`);

--
-- Indexes for table `order_item_price_snapshot`
--
ALTER TABLE `order_item_price_snapshot`
  ADD PRIMARY KEY (`snapshot_id`),
  ADD KEY `fk_snapshot_order` (`order_id`),
  ADD KEY `fk_snapshot_product` (`product_id`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`PaymentID`),
  ADD KEY `fk_payment_order` (`OrderID`);

--
-- Indexes for table `payroll`
--
ALTER TABLE `payroll`
  ADD PRIMARY KEY (`PayrollID`),
  ADD KEY `fk_payroll_employee` (`EmployeeID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`);

--
-- Indexes for table `product_ingredients`
--
ALTER TABLE `product_ingredients`
  ADD PRIMARY KEY (`ProductIngredientID`),
  ADD KEY `idx_prod_ing_product` (`ProductID`),
  ADD KEY `idx_prod_ing_ingredient` (`IngredientID`);

--
-- Indexes for table `receipt_items`
--
ALTER TABLE `receipt_items`
  ADD PRIMARY KEY (`ReceiptItemID`),
  ADD KEY `IDX_ReceiptID` (`ReceiptID`),
  ADD KEY `IDX_ProductID` (`ProductID`),
  ADD KEY `IDX_BatchNumber` (`BatchNumber`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`ReservationID`),
  ADD UNIQUE KEY `uq_reservation_code` (`ReservationCode`),
  ADD KEY `fk_reservation_customer` (`CustomerID`),
  ADD KEY `fk_reservation_staff` (`AssignedStaffID`),
  ADD KEY `idx_reservation_date` (`ReservationDate`),
  ADD KEY `idx_reservation_status` (`ReservationStatus`);

--
-- Indexes for table `reservationpayment`
--
ALTER TABLE `reservationpayment`
  ADD PRIMARY KEY (`ReservationPaymentID`),
  ADD KEY `fk_respayment_reservation` (`ReservationID`);

--
-- Indexes for table `reservation_items`
--
ALTER TABLE `reservation_items`
  ADD PRIMARY KEY (`ReservationItemID`),
  ADD KEY `fk_resitems_reservation` (`ReservationID`),
  ADD KEY `fk_resitems_product` (`ProductID`);

--
-- Indexes for table `sales_receipts`
--
ALTER TABLE `sales_receipts`
  ADD PRIMARY KEY (`ReceiptID`),
  ADD UNIQUE KEY `UQ_OrderNumber` (`OrderNumber`),
  ADD KEY `IDX_ReceiptDate` (`ReceiptDate`),
  ADD KEY `IDX_EmployeeID` (`EmployeeID`),
  ADD KEY `IDX_CustomerID` (`CustomerID`),
  ADD KEY `IDX_TransactionStatus` (`TransactionStatus`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`SupplierID`);

--
-- Indexes for table `user_accounts`
--
ALTER TABLE `user_accounts`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `activity_logs`
--
ALTER TABLE `activity_logs`
  MODIFY `LogID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `customers_archive`
--
ALTER TABLE `customers_archive`
  MODIFY `CustomerID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `customer_feedback`
--
ALTER TABLE `customer_feedback`
  MODIFY `FeedbackID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `customer_logs`
--
ALTER TABLE `customer_logs`
  MODIFY `LogID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `EmployeeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `employeeattendance`
--
ALTER TABLE `employeeattendance`
  MODIFY `AttendanceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `gcash_receipts`
--
ALTER TABLE `gcash_receipts`
  MODIFY `ReceiptID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `ingredients`
--
ALTER TABLE `ingredients`
  MODIFY `IngredientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `ingredients_backup`
--
ALTER TABLE `ingredients_backup`
  MODIFY `IngredientID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `ingredient_categories`
--
ALTER TABLE `ingredient_categories`
  MODIFY `CategoryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `InventoryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `inventory_alerts`
--
ALTER TABLE `inventory_alerts`
  MODIFY `AlertID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `inventory_backup`
--
ALTER TABLE `inventory_backup`
  MODIFY `InventoryID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `inventory_batches`
--
ALTER TABLE `inventory_batches`
  MODIFY `BatchID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `inventory_movement`
--
ALTER TABLE `inventory_movement`
  MODIFY `MovementID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `inventory_transactions_backup`
--
ALTER TABLE `inventory_transactions_backup`
  MODIFY `TransactionID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `logs`
--
ALTER TABLE `logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `orderdetails`
--
ALTER TABLE `orderdetails`
  MODIFY `OrderDetailID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=71;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `OrderID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `order_item_price_snapshot`
--
ALTER TABLE `order_item_price_snapshot`
  MODIFY `snapshot_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `payment`
--
ALTER TABLE `payment`
  MODIFY `PaymentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `payroll`
--
ALTER TABLE `payroll`
  MODIFY `PayrollID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `product_ingredients`
--
ALTER TABLE `product_ingredients`
  MODIFY `ProductIngredientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `receipt_items`
--
ALTER TABLE `receipt_items`
  MODIFY `ReceiptItemID` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Unique receipt item identifier', AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `reservation`
--
ALTER TABLE `reservation`
  MODIFY `ReservationID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `reservationpayment`
--
ALTER TABLE `reservationpayment`
  MODIFY `ReservationPaymentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `reservation_items`
--
ALTER TABLE `reservation_items`
  MODIFY `ReservationItemID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `sales_receipts`
--
ALTER TABLE `sales_receipts`
  MODIFY `ReceiptID` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Unique receipt identifier', AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `SupplierID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `user_accounts`
--
ALTER TABLE `user_accounts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `customer_feedback`
--
ALTER TABLE `customer_feedback`
  ADD CONSTRAINT `fk_feedback_customer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE CASCADE;

--
-- Constraints for table `customer_logs`
--
ALTER TABLE `customer_logs`
  ADD CONSTRAINT `fk_custlog_customer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `employeeattendance`
--
ALTER TABLE `employeeattendance`
  ADD CONSTRAINT `fk_attendance_employee` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`EmployeeID`);

--
-- Constraints for table `gcash_receipts`
--
ALTER TABLE `gcash_receipts`
  ADD CONSTRAINT `fk_gcash_respayment` FOREIGN KEY (`ReservationPaymentID`) REFERENCES `reservationpayment` (`ReservationPaymentID`) ON UPDATE CASCADE;

--
-- Constraints for table `ingredients`
--
ALTER TABLE `ingredients`
  ADD CONSTRAINT `fk_ingredient_category` FOREIGN KEY (`CategoryID`) REFERENCES `ingredient_categories` (`CategoryID`) ON UPDATE CASCADE;

--
-- Constraints for table `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `fk_inventory_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`),
  ADD CONSTRAINT `fk_inventory_supplier` FOREIGN KEY (`SupplierID`) REFERENCES `supplier` (`SupplierID`);

--
-- Constraints for table `inventory_alerts`
--
ALTER TABLE `inventory_alerts`
  ADD CONSTRAINT `fk_alert_ingredient` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`IngredientID`) ON UPDATE CASCADE;

--
-- Constraints for table `inventory_batches`
--
ALTER TABLE `inventory_batches`
  ADD CONSTRAINT `fk_inventory_batches_ingredient` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`IngredientID`) ON UPDATE CASCADE;

--
-- Constraints for table `inventory_movement`
--
ALTER TABLE `inventory_movement`
  ADD CONSTRAINT `inventory_movement_ibfk_1` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`IngredientID`),
  ADD CONSTRAINT `inventory_movement_ibfk_2` FOREIGN KEY (`BatchID`) REFERENCES `inventory_batches` (`BatchID`);

--
-- Constraints for table `logs`
--
ALTER TABLE `logs`
  ADD CONSTRAINT `fk_logs_user` FOREIGN KEY (`user_accounts_id`) REFERENCES `user_accounts` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD CONSTRAINT `fk_orderdetails_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`OrderID`),
  ADD CONSTRAINT `fk_orderdetails_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`);

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `fk_orders_customer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`),
  ADD CONSTRAINT `fk_orders_employee` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`EmployeeID`);

--
-- Constraints for table `order_item_price_snapshot`
--
ALTER TABLE `order_item_price_snapshot`
  ADD CONSTRAINT `fk_snapshot_order` FOREIGN KEY (`order_id`) REFERENCES `orders` (`OrderID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_snapshot_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`ProductID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `fk_payment_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`OrderID`);

--
-- Constraints for table `payroll`
--
ALTER TABLE `payroll`
  ADD CONSTRAINT `fk_payroll_employee` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`EmployeeID`);

--
-- Constraints for table `product_ingredients`
--
ALTER TABLE `product_ingredients`
  ADD CONSTRAINT `fk_product_ingredients_ingredient` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`IngredientID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_product_ingredients_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `fk_reservation_customer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`),
  ADD CONSTRAINT `fk_reservation_staff` FOREIGN KEY (`AssignedStaffID`) REFERENCES `employee` (`EmployeeID`);

--
-- Constraints for table `reservationpayment`
--
ALTER TABLE `reservationpayment`
  ADD CONSTRAINT `fk_respayment_reservation` FOREIGN KEY (`ReservationID`) REFERENCES `reservation` (`ReservationID`);

--
-- Constraints for table `reservation_items`
--
ALTER TABLE `reservation_items`
  ADD CONSTRAINT `fk_resitems_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_resitems_reservation` FOREIGN KEY (`ReservationID`) REFERENCES `reservation` (`ReservationID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
