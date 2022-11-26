-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 160.10.217.6:3306
-- Generation Time: Nov 25, 2022 at 05:35 PM
-- Server version: 8.0.22
-- PHP Version: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cs3230f22a`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`adecesa1`@`%` PROCEDURE `uspGetCompletedTestsForAppointment` (IN `apptId` INT)   BEGIN
 	select appointmentId, tests.testCode, name, results, isAbnormal, testDateTime 
 	from visittests, tests
    where visittests.testCode = tests.testcode and appointmentId = apptId and testDateTime is not null;
END$$

$$

CREATE DEFINER=`adecesa1`@`%` PROCEDURE `uspGetNonCompletedTestsForAppointment` (IN `apptId` INT)   BEGIN
	select appointmentId, tests.testCode, name, results, isAbnormal, testDateTime
    from visittests, tests
    where visittests.testCode = tests.testcode and appointmentId = apptId and testDateTime is null;
END$$

CREATE DEFINER=`adecesa1`@`%` PROCEDURE `uspGetPossibleTests` (IN `apptId` INT)   BEGIN
	select tests.testcode, name from tests where not exists(select visittests.testcode from visittests where appointmentId = apptId and 	tests.testcode = visittests.testCode);
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE `accounts` (
  `employeeID` int UNSIGNED NOT NULL,
  `userName` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `password` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `accountType` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`employeeID`, `userName`, `password`, `accountType`) VALUES
(1, 'JNursington', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'NURSE'),
(2, 'TEST', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'NURSE'),
(3, 'Doctor1', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'DOCTOR'),
(4, 'Doctor2', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'DOCTOR'),
(6, 'ADMINTEST', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'ADMIN'),
(7, 'NURSE3', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'NURSE'),
(8, 'NURSE4', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'NURSE'),
(9, 'NURSE5', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'NURSE'),
(10, 'ADMIN2', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'ADMIN'),
(11, 'ADMIN3', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'ADMIN'),
(12, 'ADMIN4', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'ADMIN'),
(13, 'ADMIN5', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'ADMIN'),
(14, 'DOCTOR3', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'DOCTOR'),
(15, 'DOCTOR4', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'DOCTOR'),
(16, 'DOCTOR5', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 'DOCTOR');

-- --------------------------------------------------------

--
-- Table structure for table `admins`
--

CREATE TABLE `admins` (
  `adminId` int UNSIGNED NOT NULL,
  `employeeId` int UNSIGNED NOT NULL,
  `firstName` varchar(25) NOT NULL,
  `lastName` varchar(25) NOT NULL,
  `dateOfBirth` date NOT NULL,
  `gender` varchar(6) NOT NULL,
  `phone` char(12) NOT NULL,
  `addressOne` varchar(50) NOT NULL,
  `addressTwo` varchar(50) DEFAULT NULL,
  `city` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  `zipcode` char(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `admins`
--

INSERT INTO `admins` (`adminId`, `employeeId`, `firstName`, `lastName`, `dateOfBirth`, `gender`, `phone`, `addressOne`, `addressTwo`, `city`, `state`, `zipcode`) VALUES
(1, 6, 'First Admin', 'Last Admin', '1999-10-18', 'Male', '878-784-4844', '1601 Maple Street', '', 'Carrollton', 'Georgia', '30277'),
(2, 10, 'Jay', 'Admin', '1999-10-17', 'Male', '777-777-7777', '1601 Maple Street', '', 'Senoia', 'Georgia', '30277'),
(3, 11, 'John', 'Admin', '1990-10-17', 'Male', '888-888-8888', '10 Main Street', '', 'Newnan', 'Georgia', '30265'),
(4, 12, 'Jane', 'Admin', '1995-10-17', 'Female', '757-457-7127', '755 Highway 10', 'Carrollton', '', 'Georgia', '54444'),
(5, 13, 'Jim', 'Admin', '1994-10-17', 'Male', '775-127-4757', '1601 Maple Street', 'add2', 'Carrollton', 'Georgia', '30277');

-- --------------------------------------------------------

--
-- Table structure for table `appointments`
--

CREATE TABLE `appointments` (
  `appointmentId` int UNSIGNED NOT NULL,
  `patientId` int UNSIGNED NOT NULL,
  `appointmentDateTime` datetime NOT NULL,
  `doctorId` int UNSIGNED NOT NULL,
  `reason` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `appointments`
--

INSERT INTO `appointments` (`appointmentId`, `patientId`, `appointmentDateTime`, `doctorId`, `reason`) VALUES
(1, 2, '2023-05-01 01:00:00', 2, 'Check up'),
(2, 2, '2022-10-22 01:00:00', 1, 'Check up'),
(3, 2, '2022-10-21 00:00:00', 1, 'Check up'),
(4, 2, '2020-10-21 00:00:00', 1, 'Check up'),
(5, 2, '2022-10-22 20:19:49', 1, 'New Appointment'),
(6, 2, '2022-10-22 20:29:50', 3, 'Test'),
(7, 2, '2022-12-22 20:30:00', 2, 'New Test123'),
(8, 6, '2022-10-28 20:31:10', 1, 'First Appointment'),
(11, 2, '2022-10-27 21:57:46', 2, 'ff'),
(12, 2, '2022-11-03 12:31:00', 2, 'jjjjjjj'),
(13, 2, '2022-10-23 21:58:02', 3, 'fff'),
(14, 9, '2022-10-23 21:58:38', 2, 'First Appointment'),
(15, 2, '2022-10-24 15:06:35', 2, 'fff'),
(16, 2, '2022-11-26 15:06:00', 1, 'Edit Appointment 654321'),
(17, 6, '2022-10-28 15:35:00', 2, 'New Appointment for Checkup'),
(18, 6, '2022-10-28 15:36:00', 1, 'fgffgfgfgfgggfgg'),
(19, 6, '2022-07-11 11:01:00', 2, 'New Appointment  ggggg'),
(20, 2, '2022-10-29 11:43:01', 1, 'ffff'),
(21, 10, '2022-11-01 13:00:00', 2, 'Stomach Ache'),
(22, 10, '2022-11-04 21:59:00', 1, 'Headache'),
(23, 20, '2022-11-03 12:31:00', 3, 'Checkup'),
(24, 2, '2022-11-03 12:30:00', 1, 'fffeee'),
(25, 20, '2022-11-03 12:30:00', 3, 'New Appointment'),
(26, 10, '2022-12-31 20:15:00', 2, 'Tired'),
(27, 6, '2022-11-16 13:00:00', 1, 'New appointment'),
(28, 6, '2022-11-16 13:00:00', 2, 'Other Appointment 123'),
(29, 6, '2022-11-16 14:00:00', 1, 'fff'),
(30, 6, '2022-11-16 14:00:00', 2, 'ff'),
(31, 6, '2022-11-16 15:00:00', 3, 'Doctorson Jimmy'),
(32, 6, '2022-11-16 14:59:00', 2, 'Doctor John'),
(33, 6, '2022-11-16 14:59:00', 1, 'Doctor The Good'),
(34, 6, '2022-11-16 14:59:00', 1, 'Doctor The Good'),
(35, 6, '2022-11-16 15:09:01', 1, '1'),
(36, 14, '2022-11-16 15:20:00', 1, 'The Good'),
(37, 14, '2022-11-16 15:21:00', 3, 'DJ'),
(38, 14, '2022-11-16 15:24:00', 2, 'DJONH'),
(39, 14, '2022-11-16 15:24:00', 2, 'djohn'),
(40, 14, '2022-11-16 15:24:00', 1, 'Thegood'),
(41, 14, '2022-11-16 15:25:00', 1, 'the good'),
(42, 14, '2022-11-16 15:27:00', 1, 'thegood'),
(43, 14, '2022-11-16 15:28:00', 1, 'thegood'),
(44, 14, '2022-11-16 15:33:00', 1, 'thegood'),
(45, 13, '2022-11-16 15:36:00', 1, 'The gOOD'),
(46, 13, '2022-11-16 15:36:00', 1, 'DJohn'),
(47, 13, '2022-11-16 15:36:00', 1, 'DJohn'),
(48, 13, '2022-11-16 15:41:00', 1, 'The gOOD'),
(49, 13, '2022-11-16 15:42:00', 1, 'The good '),
(50, 13, '2022-11-16 15:42:00', 2, 'DJOHN'),
(51, 13, '2022-11-16 15:42:00', 3, 'DJIMMY'),
(52, 7, '2022-11-16 18:56:00', 1, 'TheGood'),
(53, 7, '2022-11-16 18:56:00', 3, 'Jimmy'),
(54, 7, '2022-11-16 18:56:00', 2, 'John'),
(55, 2, '2022-11-20 06:50:00', 1, 'Test Appt'),
(56, 9, '2022-11-22 14:05:00', 2, 'fff'),
(57, 2, '2022-11-23 07:45:00', 1, 'gg'),
(58, 2, '2022-12-10 07:11:00', 1, 'fff'),
(59, 2, '2022-12-02 07:47:00', 1, 'New'),
(60, 2, '2022-11-24 07:52:00', 2, 'ffff'),
(61, 2, '2022-11-25 14:29:00', 1, '1'),
(62, 2, '2022-11-25 23:00:00', 3, 'New appt'),
(63, 2, '2022-11-25 23:00:00', 4, 'Apt2'),
(64, 10, '2022-11-25 23:00:00', 5, 'Yay finally no double bookings');

-- --------------------------------------------------------

--
-- Table structure for table `diagnosis`
--

CREATE TABLE `diagnosis` (
  `diagnosisId` int UNSIGNED NOT NULL,
  `appointmentId` int UNSIGNED NOT NULL,
  `diagnosisDescription` varchar(100) NOT NULL,
  `isFinal` tinyint(1) NOT NULL,
  `basedOnTestResults` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `diagnosis`
--

INSERT INTO `diagnosis` (`diagnosisId`, `appointmentId`, `diagnosisDescription`, `isFinal`, `basedOnTestResults`) VALUES
(11, 22, 'Sick', 0, 1),
(12, 22, 'broken leg', 0, 1),
(13, 22, 'broken arm', 0, 0),
(15, 22, 'broken toe', 0, 1),
(16, 22, 'broken finger', 0, 0),
(17, 22, 'Healthy', 0, 0),
(18, 21, 'broken nose', 0, 0),
(19, 21, 'Broken foot', 0, 1),
(20, 26, 'Test diagnosis', 0, 1),
(22, 4, 'New Diagnosis', 0, 0),
(23, 4, 'Based on test', 0, 1),
(24, 4, 'Final', 1, 0),
(28, 21, 'serious injury', 0, 1),
(29, 21, 'test 7:45', 1, 1),
(30, 22, 'Test 7:58', 1, 1),
(36, 3, 'New Diag', 1, 1),
(37, 3, 'ffff', 0, 0),
(38, 2, 'Final', 1, 0),
(39, 26, 'broken hand', 0, 0),
(40, 26, 'broken finger', 0, 1),
(41, 27, 'Final', 1, 0),
(43, 13, 'dddcccc', 0, 0),
(45, 26, '11/21 - 7:01', 0, 1),
(46, 26, '11/21 - 7:02', 0, 0),
(47, 16, 'gggg', 0, 1),
(48, 26, '11/22 - 8:42 PM', 0, 1),
(50, 7, 'gggg', 1, 1),
(52, 16, 'Actual Desc', 1, 0),
(55, 58, 'New 55123', 0, 0),
(60, 60, 'New Diag', 0, 0),
(61, 60, 'Edit Diag', 0, 0),
(62, 60, 'Edit Diag 2', 0, 0),
(65, 1, '65 Diag', 0, 0),
(66, 1, '66 Diag', 0, 0),
(67, 1, '67 Diag\r\n', 0, 0),
(68, 1, 'New Diag123', 0, 0),
(72, 59, 'fff', 0, 0),
(73, 59, 'd', 0, 0),
(75, 59, '4', 0, 0),
(76, 59, '6', 0, 0),
(77, 58, 'Actual Desc', 0, 0),
(78, 58, '1', 0, 0),
(79, 58, '2', 0, 0),
(80, 58, '3', 0, 1),
(81, 1, 'Now Submitted', 0, 1),
(82, 1, '123', 0, 0),
(83, 1, '1', 0, 0),
(84, 61, 'fff', 0, 0),
(85, 61, 'a', 0, 0),
(86, 61, 'b', 0, 0),
(87, 61, 'c', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `doctors`
--

CREATE TABLE `doctors` (
  `doctorId` int UNSIGNED NOT NULL,
  `employeeId` int UNSIGNED NOT NULL,
  `firstName` varchar(25) NOT NULL,
  `lastName` varchar(25) NOT NULL,
  `dateOfBirth` date NOT NULL,
  `gender` varchar(6) NOT NULL,
  `phone` char(12) NOT NULL,
  `addressOne` varchar(50) NOT NULL,
  `addressTwo` varchar(50) DEFAULT NULL,
  `city` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  `zipcode` char(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `doctors`
--

INSERT INTO `doctors` (`doctorId`, `employeeId`, `firstName`, `lastName`, `dateOfBirth`, `gender`, `phone`, `addressOne`, `addressTwo`, `city`, `state`, `zipcode`) VALUES
(1, 3, 'TheGood', 'Doctor', '2000-11-25', 'Male', '777-888-9999', '154 Maple Street', 'Apt 13', 'Newnan', 'Georgia', '30277'),
(2, 4, 'John', 'Doctor', '1980-01-01', 'Male', '887-781-4454', '454 Main Street', '', 'Newnan', 'Georgia', '78788'),
(3, 14, 'Jimmy', 'Doctorson', '1990-01-01', 'Male', '857-781-4454', '4154 Main Street', '', 'Newnan', 'Georgia', '78788'),
(4, 15, 'Jay', 'Doctor', '1999-10-17', 'Male', '777-777-7777', '1601 Maple Street', '', 'Senoia', 'Georgia', '30277'),
(5, 16, 'Jim', 'Doctor', '1959-10-17', 'Male', '457-457-7211', '18 Broad Street', '', 'Senoia', 'Georgia', '30277');

-- --------------------------------------------------------

--
-- Table structure for table `nurses`
--

CREATE TABLE `nurses` (
  `nurseId` int UNSIGNED NOT NULL,
  `employeeId` int UNSIGNED NOT NULL,
  `firstName` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `lastName` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dateOfBirth` date NOT NULL,
  `gender` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `phone` char(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `addressOne` varchar(50) NOT NULL,
  `addressTwo` varchar(50) DEFAULT NULL,
  `city` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  `zipcode` char(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `nurses`
--

INSERT INTO `nurses` (`nurseId`, `employeeId`, `firstName`, `lastName`, `dateOfBirth`, `gender`, `phone`, `addressOne`, `addressTwo`, `city`, `state`, `zipcode`) VALUES
(1, 1, 'TestFirst', 'TestLast', '2000-10-18', 'Male', '777-777-7777', '5115 Maple Street', NULL, 'Carrollton', 'Georgia', '11111'),
(2, 2, 'Jim', 'Tester', '1900-01-22', 'Male', '888-888-8888', '151 Main Street', NULL, 'Newnan', 'Georgia', '15111'),
(3, 7, 'Jay', 'Nusington', '1995-10-17', 'Male', '755-777-7777', '1601 Maple Street', '', 'Senoia', 'Georgia', '30277'),
(4, 8, 'Jane', 'Nurseson', '1959-10-17', 'Male', '457-457-7211', '108 Broad Street', '', 'Senoia', 'Georgia', '30277'),
(5, 9, 'Jimmy', 'Nurseson', '1970-10-17', 'Male', '457-488-7221', '118 Main Street', '', 'Newnan', 'Georgia', '30277');

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `patientID` int UNSIGNED NOT NULL,
  `lastName` varchar(25) NOT NULL,
  `firstName` varchar(25) NOT NULL,
  `dateOfBirth` date NOT NULL,
  `gender` varchar(6) NOT NULL,
  `phone` char(12) NOT NULL,
  `addressOne` varchar(50) NOT NULL,
  `addressTwo` varchar(50) DEFAULT NULL,
  `city` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  `zipcode` char(5) NOT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`patientID`, `lastName`, `firstName`, `dateOfBirth`, `gender`, `phone`, `addressOne`, `addressTwo`, `city`, `state`, `zipcode`, `status`) VALUES
(1, 'TEST100', 'Patient', '2022-09-29', 'male', '777-777-7777', '1601 Maple Street', '', 'Carrollton', 'GA', '30117', 1),
(2, 'ff', 'ff', '2022-09-01', 'Male', '444-444-4444', '1601 Main Street', '', 'Senoia', 'California', '33333', 1),
(3, 'Test', 'Patient', '2022-08-30', 'Male', '777-777-7777', '1601 Maple Street', '', 'Carrollton', 'Georgia', '11111', 0),
(4, 'TESTLAST', 'TESTFIRST', '2022-09-23', 'Male', '777-777-7777', '101 Address Lane', 'Room 15511A', 'Atlanta', 'Georgia', '51155', 1),
(5, 'Patient', 'New', '2022-09-28', 'Male', '777-777-7777', 'fbdfdb', 'dfdfb', 'dffd', 'Arkansas', '55555', 1),
(6, 'Alex', 'DeCesare', '2022-09-28', 'Male', '777-777-7777', 'fff', 'fff', 'fff', 'Arizona', '55555', 1),
(7, 'TTTT', 'TTTT', '2022-09-28', 'Female', '444-444-4444', 'DFF', 'FFF', 'GGFGF', 'Arizona', '55555', 1),
(8, 'LAST New', 'FIRST New', '2022-10-04', 'Female', '111-111-1111', 'dd NEW', 'ddd NEW', 'ddd NEW', 'Pennsylvania', '11111', 1),
(9, 'ff', 'ff', '2022-09-29', 'Male', '555-555-5566', 'ff', 'ff', 'ff', 'Alaska', '12345', 1),
(10, 'Mitchell', 'Kenneth', '2022-11-21', 'Male', '888-888-8888', '123 Address Way ', '', 'Carrollton', 'Georgia', '99999', 1),
(11, 'Hello Changed', 'Last Name Changed', '2022-10-03', 'Male', '777-777-7777', '', 'BIG ADDRESSBIG ADDRESSBIG ADDRESSBIG ADDRESSBIG AD', 'BIG CITYBIG CITYBIG CITYBIG CITYBIG CITYBIG CITYBI', 'Maryland', '30277', 1),
(12, 'fff', 'fff', '2022-10-05', 'Male', '777-777-7777', 'hhh', '', 'hhh', 'Arkansas', '33333', 1),
(13, 'First', 'Last', '2022-10-05', 'Male', '777-777-7777', '155 Address 1', '', 'Senoia', 'Alaska', '77777', 1),
(14, 'Last', 'First', '2022-10-05', 'Female', '122-444-4444', 'Address One Drive', '', 'Newnan', 'Illinois', '54554', 1),
(16, 'ERICSON', 'JAMES', '2022-10-09', 'Male', '777-777-7777', '4181 Main Street', '', 'Newnan', 'Arizona', '44444', 1),
(17, 'Jimmy', 'Tester', '2022-10-09', 'Male', '777-777-7777', '515 Maple Street', '', 'Senoia', 'Georgia', '30276', 1),
(18, 'Smith Changed', 'Johnny Changed', '2022-10-09', 'Male', '777-777-7777', 'eee', '', 'eee', 'Alaska', '31111', 1),
(19, 'Jim', 'Smith', '2022-10-09', 'Male', '777-777-7777', '1501 Maple Street', '', 'Harrisburg', 'Arizona', '11111', 1),
(20, 'Bob', 'Bob', '2022-09-07', 'Female', '777-777-7777', 'New Address', '', 'Senioa', 'Hawaii', '77777', 1),
(21, 'May', 'James', '2022-11-01', 'Male', '888-888-8888', 'ggg', '', 'ggg', 'Alaska', '77777', 1),
(22, 'Bean', 'Jim', '2022-09-09', 'male', '777-777-7777', '1601 Maple Street', '', 'Carrollton', 'Georgia', '30276', 1);

-- --------------------------------------------------------

--
-- Table structure for table `specialty`
--

CREATE TABLE `specialty` (
  `doctorId` int UNSIGNED NOT NULL,
  `specialtyName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `specialty`
--

INSERT INTO `specialty` (`doctorId`, `specialtyName`) VALUES
(1, 'Breathing'),
(1, 'Lung Cancer'),
(2, 'General Care'),
(2, 'Kidney Diets'),
(2, 'Kidney Disease'),
(3, 'Arthritis'),
(3, 'Feet'),
(4, 'Legs'),
(5, 'The Brain');

-- --------------------------------------------------------

--
-- Table structure for table `tests`
--

CREATE TABLE `tests` (
  `testcode` int UNSIGNED NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `tests`
--

INSERT INTO `tests` (`testcode`, `name`) VALUES
(1, 'white blood cell (WBC)'),
(2, 'Low Density Lipoproteins (LDL)'),
(3, 'hepatitis A test'),
(4, 'hepatitis B test'),
(5, 'kidney function');

-- --------------------------------------------------------

--
-- Table structure for table `visit`
--

CREATE TABLE `visit` (
  `appointmentId` int UNSIGNED NOT NULL,
  `nurseId` int UNSIGNED NOT NULL,
  `bodyTemp` decimal(5,2) NOT NULL,
  `pulse` int NOT NULL,
  `height` decimal(3,1) NOT NULL,
  `weight` decimal(5,2) NOT NULL,
  `symptoms` varchar(100) NOT NULL,
  `systolicBloodPressure` int NOT NULL,
  `diastolicBloodPressure` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `visit`
--

INSERT INTO `visit` (`appointmentId`, `nurseId`, `bodyTemp`, `pulse`, `height`, `weight`, `symptoms`, `systolicBloodPressure`, `diastolicBloodPressure`) VALUES
(1, 2, '5.00', 5, '5.0', '5.00', 'fff', 5, 5),
(2, 1, '555.00', 55, '55.0', '55.00', 'eeeffe', 55, 55),
(3, 1, '5.00', 5, '5.0', '5.00', 'New', 55, 5),
(4, 1, '88.00', 55, '6.0', '55.00', 'fff', 88, 88),
(5, 2, '12.00', 12, '12.0', '12.00', 'dddg', 210, 12),
(7, 2, '3.00', 4, '5.0', '6.00', 'vvvv New', 50, 2),
(11, 2, '150.00', 50, '5.5', '150.00', 'sick', 150, 50),
(12, 2, '444.00', 4, '5.8', '100.10', 'Test Sympt', 444, 444),
(13, 1, '5.00', 5, '5.0', '5.00', 'ggg', 5, 5),
(14, 2, '5.00', 5, '5.0', '5.00', ';;;', 5, 5),
(15, 2, '5.00', 5, '5.0', '5.00', 'fff', 5, 5),
(16, 1, '22.00', 2, '2.2', '222.00', 'zzz', 333, 222),
(18, 1, '55.00', 55, '55.0', '55.00', 'fff', 55, 55),
(19, 2, '55.00', 55, '55.0', '5.00', 'fff', 55, 55),
(21, 2, '98.50', 77, '6.1', '205.00', 'Stomach ache', 121, 81),
(22, 1, '100.00', 10, '6.0', '200.00', 'sick', 100, 10),
(23, 1, '55.70', 55, '55.0', '5.00', 'ggg', 55, 55),
(24, 1, '5.00', 5, '5.0', '5.00', 'The New Checkup123', 5, 5),
(26, 2, '55.00', 55, '5.5', '555.00', 'hurt finger', 555, 555),
(27, 1, '55.00', 55, '55.0', '55.00', 'New Symptoms', 55, 55),
(36, 1, '5.00', 5, '5.0', '5.00', 'ggg', 5, 5),
(38, 1, '50.00', 50, '50.0', '50.00', 'ddd', 50, 50),
(55, 2, '5.00', 5, '5.0', '5.00', 'New Sympt', 5, 5),
(56, 2, '55.00', 55, '55.0', '55.00', 'vff', 10, 5),
(58, 2, '5.00', 5, '5.0', '5.00', 'fff', 5, 5),
(59, 2, '10.00', 10, '10.0', '10.00', 'New TEST', 10, 10),
(60, 2, '5.00', 5, '5.0', '5.00', 'fff', 5, 5),
(61, 2, '5.00', 5, '5.0', '2.00', 'ff', 5, 5);

-- --------------------------------------------------------

--
-- Table structure for table `visittests`
--

CREATE TABLE `visittests` (
  `appointmentId` int UNSIGNED NOT NULL,
  `testCode` int UNSIGNED NOT NULL,
  `results` varchar(100) NOT NULL,
  `isAbnormal` tinyint(1) NOT NULL,
  `testDateTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `visittests`
--

INSERT INTO `visittests` (`appointmentId`, `testCode`, `results`, `isAbnormal`, `testDateTime`) VALUES
(2, 1, 'fwfw', 0, '2022-11-11 16:42:12'),
(2, 2, 'fgg', 1, '2022-11-09 16:14:08'),
(2, 3, 'fff', 0, '2022-11-11 16:41:57'),
(2, 4, '', 0, NULL),
(3, 1, '', 0, NULL),
(3, 2, 'Results', 1, '2022-11-10 20:01:16'),
(3, 3, '', 0, NULL),
(3, 4, '', 0, NULL),
(4, 1, 'Results were fine', 0, '2022-07-11 00:00:00'),
(4, 2, 'New Results', 0, '2022-11-09 15:33:01'),
(4, 3, 'Abnorm Test Results', 1, '2022-11-09 16:12:33'),
(4, 4, 'fefeffe', 1, '2022-11-09 16:21:35'),
(5, 2, 'ccc', 0, '2022-11-17 15:14:11'),
(5, 3, '', 0, NULL),
(5, 4, '', 0, NULL),
(7, 1, 'ccc', 1, '2022-11-23 07:47:02'),
(13, 1, '', 0, NULL),
(13, 2, '', 0, NULL),
(14, 1, 'ff', 0, '2022-11-19 08:47:52'),
(15, 1, '', 0, NULL),
(15, 2, '', 0, NULL),
(16, 1, 'ggg', 0, '2022-11-22 16:15:40'),
(16, 3, '', 0, NULL),
(18, 2, 'fff', 0, '2022-11-19 08:47:22'),
(18, 3, '', 0, NULL),
(19, 1, 'fff', 0, '2022-11-19 08:45:59'),
(19, 2, 'fff', 0, '2022-11-19 08:47:02'),
(21, 1, 'All clear', 0, '2022-11-09 22:05:34'),
(24, 1, '', 0, NULL),
(24, 2, '', 0, NULL),
(24, 3, '', 0, NULL),
(24, 4, '', 0, NULL),
(26, 1, 'ddd', 0, '2022-11-19 08:48:44'),
(26, 2, 'ggg', 0, '2022-11-19 08:48:50'),
(26, 3, 'sss', 0, '2022-11-19 08:48:55'),
(26, 4, 'rr', 0, '2022-11-19 08:49:00'),
(27, 2, 'New Test Results', 0, '2022-11-16 14:04:22'),
(27, 4, 'Results', 0, '2022-11-16 14:05:23'),
(36, 1, '', 0, NULL),
(36, 2, '', 0, NULL),
(36, 3, '', 0, NULL),
(36, 4, '', 0, NULL),
(38, 1, '', 0, NULL),
(38, 2, '', 0, NULL),
(38, 3, '', 0, NULL),
(38, 4, '', 0, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`employeeID`);

--
-- Indexes for table `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`adminId`),
  ADD KEY `fk_admins_accounts` (`employeeId`);

--
-- Indexes for table `appointments`
--
ALTER TABLE `appointments`
  ADD PRIMARY KEY (`appointmentId`),
  ADD KEY `fk_appointments_patients` (`patientId`),
  ADD KEY `fk_appointments_doctors` (`doctorId`);

--
-- Indexes for table `diagnosis`
--
ALTER TABLE `diagnosis`
  ADD PRIMARY KEY (`diagnosisId`),
  ADD KEY `fk_diagnosis_visit` (`appointmentId`);

--
-- Indexes for table `doctors`
--
ALTER TABLE `doctors`
  ADD PRIMARY KEY (`doctorId`),
  ADD KEY `fk_doctors_accounts` (`employeeId`);

--
-- Indexes for table `nurses`
--
ALTER TABLE `nurses`
  ADD PRIMARY KEY (`nurseId`),
  ADD KEY `fk_nurses_accounts` (`employeeId`);

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`patientID`);

--
-- Indexes for table `specialty`
--
ALTER TABLE `specialty`
  ADD PRIMARY KEY (`doctorId`,`specialtyName`);

--
-- Indexes for table `tests`
--
ALTER TABLE `tests`
  ADD PRIMARY KEY (`testcode`);

--
-- Indexes for table `visit`
--
ALTER TABLE `visit`
  ADD PRIMARY KEY (`appointmentId`),
  ADD KEY `fk_visit_nurses` (`nurseId`);

--
-- Indexes for table `visittests`
--
ALTER TABLE `visittests`
  ADD PRIMARY KEY (`appointmentId`,`testCode`),
  ADD KEY `fk_visitTests_tests` (`testCode`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `employeeID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `admins`
--
ALTER TABLE `admins`
  MODIFY `adminId` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `appointments`
--
ALTER TABLE `appointments`
  MODIFY `appointmentId` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;

--
-- AUTO_INCREMENT for table `diagnosis`
--
ALTER TABLE `diagnosis`
  MODIFY `diagnosisId` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=88;

--
-- AUTO_INCREMENT for table `doctors`
--
ALTER TABLE `doctors`
  MODIFY `doctorId` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `nurses`
--
ALTER TABLE `nurses`
  MODIFY `nurseId` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `patientID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `tests`
--
ALTER TABLE `tests`
  MODIFY `testcode` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `admins`
--
ALTER TABLE `admins`
  ADD CONSTRAINT `fk_admins_accounts` FOREIGN KEY (`employeeId`) REFERENCES `accounts` (`employeeID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `appointments`
--
ALTER TABLE `appointments`
  ADD CONSTRAINT `fk_appointments_doctors` FOREIGN KEY (`doctorId`) REFERENCES `doctors` (`doctorId`),
  ADD CONSTRAINT `fk_appointments_patients` FOREIGN KEY (`patientId`) REFERENCES `patients` (`patientID`);

--
-- Constraints for table `diagnosis`
--
ALTER TABLE `diagnosis`
  ADD CONSTRAINT `fk_diagnosis_visit` FOREIGN KEY (`appointmentId`) REFERENCES `visit` (`appointmentId`);

--
-- Constraints for table `doctors`
--
ALTER TABLE `doctors`
  ADD CONSTRAINT `fk_doctors_accounts` FOREIGN KEY (`employeeId`) REFERENCES `accounts` (`employeeID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `nurses`
--
ALTER TABLE `nurses`
  ADD CONSTRAINT `fk_nurses_accounts` FOREIGN KEY (`employeeId`) REFERENCES `accounts` (`employeeID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `specialty`
--
ALTER TABLE `specialty`
  ADD CONSTRAINT `fk_specialty_doctor` FOREIGN KEY (`doctorId`) REFERENCES `doctors` (`doctorId`);

--
-- Constraints for table `visit`
--
ALTER TABLE `visit`
  ADD CONSTRAINT `fk_visit_appointment` FOREIGN KEY (`appointmentId`) REFERENCES `appointments` (`appointmentId`),
  ADD CONSTRAINT `fk_visit_nurses` FOREIGN KEY (`nurseId`) REFERENCES `nurses` (`nurseId`);

--
-- Constraints for table `visittests`
--
ALTER TABLE `visittests`
  ADD CONSTRAINT `fk_visitTests_tests` FOREIGN KEY (`testCode`) REFERENCES `tests` (`testcode`),
  ADD CONSTRAINT `fk_visitTests_visit` FOREIGN KEY (`appointmentId`) REFERENCES `visit` (`appointmentId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
