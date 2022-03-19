-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 17, 2020 at 07:15 PM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bank_management_system`
--
CREATE DATABASE IF NOT EXISTS `bank_management_system` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `bank_management_system`;

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `Accountno` varchar(50) NOT NULL,
  `Customerid` varchar(50) DEFAULT NULL,
  `Accounttype` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Balance` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`Accountno`, `Customerid`, `Accounttype`, `Description`, `Balance`) VALUES
('1', '10000', 'Saving', 'Testing project', '97279'),
('2', '10001', 'Saving', 'project test', '505920'),
('3', '10002', 'Fix', 'hello', '7000000');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `Customerid` varchar(50) NOT NULL,
  `Firstname` varchar(50) NOT NULL,
  `Lastname` varchar(40) NOT NULL,
  `Roadno` varchar(50) NOT NULL,
  `Houseno` varchar(40) NOT NULL,
  `Thana` varchar(40) NOT NULL,
  `District` varchar(40) NOT NULL,
  `Phone` varchar(50) NOT NULL,
  `Date` date NOT NULL,
  `Email` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`Customerid`, `Firstname`, `Lastname`, `Roadno`, `Houseno`, `Thana`, `District`, `Phone`, `Date`, `Email`) VALUES
('10000', 'Iqbal', 'Hasan', '09', '27', 'Rupnagar', 'Dhaka', '01872087566', '0000-00-00', 'iqbal@gmail.com'),
('10001', 'Sharial', 'Alam', '28', '29', 'Rupnagar', 'Dhaka', '01922675343', '0000-00-00', 'sunny@gmail.com'),
('10002', 'Alhaj', 'Hossen', '09', '13', 'Mirpur2', 'Dhaka', '01723659032', '0000-00-00', 'alhaj@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `loan`
--

CREATE TABLE `loan` (
  `Accountno` varchar(100) NOT NULL,
  `Date` date NOT NULL,
  `Loan_amount` int(11) NOT NULL,
  `Loan_period` int(11) NOT NULL,
  `Loan_pm` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `loan`
--

INSERT INTO `loan` (`Accountno`, `Date`, `Loan_amount`, `Loan_period`, `Loan_pm`) VALUES
('1', '2020-02-17', 7000, 10, 2),
('1', '2020-02-17', 7000, 12, 2),
('1', '2020-02-18', 7000, 12, 1000),
('1', '2020-02-18', 7000, 12, 1000);

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `txid` int(11) NOT NULL,
  `Accountno` varchar(30) DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `Balance` int(11) DEFAULT NULL,
  `Deposit` int(11) DEFAULT NULL,
  `Withdraw` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`txid`, `Accountno`, `Date`, `Balance`, `Deposit`, `Withdraw`) VALUES
(1, '1', '2020-02-17', 97301, 1, 0),
(2, '1', '2020-02-17', 97302, 2, 0),
(3, '1', '2020-02-17', 97304, 10, 0),
(4, '1', '2020-02-17', 97324, 10, 0),
(5, '1', '2020-02-17', 97330, 6, 0),
(6, '1', '2020-02-17', 97299, 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `transfer`
--

CREATE TABLE `transfer` (
  `tfid` int(11) NOT NULL,
  `Fromaccount` varchar(100) NOT NULL,
  `Toaccount` varchar(100) NOT NULL,
  `Date` date NOT NULL,
  `Amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transfer`
--

INSERT INTO `transfer` (`tfid`, `Fromaccount`, `Toaccount`, `Date`, `Amount`) VALUES
(1, '1', '2', '2020-02-17', 20);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `usertype` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `usertype`) VALUES
(1, 'iqbal', '1234', 'admin'),
(2, 'Sunny', '123', 'admin'),
(3, 'Alhaj', '4321', 'admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`Accountno`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`Customerid`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`txid`);

--
-- Indexes for table `transfer`
--
ALTER TABLE `transfer`
  ADD PRIMARY KEY (`tfid`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `txid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `transfer`
--
ALTER TABLE `transfer`
  MODIFY `tfid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
