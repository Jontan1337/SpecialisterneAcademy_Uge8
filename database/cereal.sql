-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 03, 2025 at 01:18 PM
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
-- Database: `cereal`
--

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ID` int(11) NOT NULL,
  `Name` varchar(1024) NOT NULL,
  `Manufacturer` varchar(1024) NOT NULL,
  `Type` enum('COLD','HOT') DEFAULT NULL,
  `Calories` int(11) DEFAULT NULL,
  `Protein` int(11) DEFAULT NULL,
  `Fat` int(11) DEFAULT NULL,
  `Sodium` int(11) DEFAULT NULL,
  `Fiber` float DEFAULT NULL,
  `Carbo` float DEFAULT NULL,
  `Sugars` int(11) DEFAULT NULL,
  `Potass` int(11) DEFAULT NULL,
  `Vitamins` int(11) DEFAULT NULL,
  `Shelf` int(11) DEFAULT NULL,
  `Weight` float DEFAULT NULL,
  `Cups` float DEFAULT NULL,
  `Rating` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ID`, `Name`, `Manufacturer`, `Type`, `Calories`, `Protein`, `Fat`, `Sodium`, `Fiber`, `Carbo`, `Sugars`, `Potass`, `Vitamins`, `Shelf`, `Weight`, `Cups`, `Rating`) VALUES
(1, '100% Bran', 'K', 'COLD', 70, 4, 1, 130, 10, 5, 6, 280, 25, 3, 1, 0.33, 68.402),
(2, '100% Natural Bran', 'Q', 'COLD', 120, 3, 5, 15, 2, 8, 8, 135, 0, 3, 1, 1, 33.983),
(3, 'All-Bran', 'K', 'COLD', 70, 4, 1, 260, 9, 7, 5, 320, 25, 3, 1, 0.33, 59.425),
(4, 'All-Bran with Extra Fiber', 'K', 'COLD', 50, 4, 0, 140, 14, 8, 0, 330, 25, 3, 1, 0.5, 93.704),
(5, 'Almond Delight', 'R', 'COLD', 110, 2, 2, 200, 1, 14, 8, -1, 25, 3, 1, 0.75, 34.384),
(6, 'Apple Cinnamon Cheerios', 'G', 'COLD', 110, 2, 2, 180, 1.5, 10.5, 10, 70, 25, 1, 1, 0.75, 29.509),
(7, 'Apple Jacks', 'K', 'COLD', 110, 2, 0, 125, 1, 11, 14, 30, 25, 2, 1, 1, 33.174),
(8, 'Basic 4', 'G', 'COLD', 130, 3, 2, 210, 2, 18, 8, 100, 25, 3, 1.33, 0.75, 37.038),
(9, 'Bran Chex', 'R', 'COLD', 90, 2, 1, 200, 4, 15, 6, 125, 25, 1, 1, 0.67, 49.12),
(10, 'Bran Flakes', 'P', 'COLD', 90, 3, 0, 210, 5, 13, 5, 190, 25, 3, 1, 0.67, 53.313),
(11, 'Cap\'n\'Crunch', 'Q', 'COLD', 120, 1, 2, 220, 0, 12, 12, 35, 25, 2, 1, 0.75, 18.042),
(12, 'Cheerios', 'G', 'COLD', 110, 6, 2, 290, 2, 17, 1, 105, 25, 1, 1, 1.25, 50.764),
(13, 'Cinnamon Toast Crunch', 'G', 'COLD', 120, 1, 3, 210, 0, 13, 9, 45, 25, 2, 1, 0.75, 19.823),
(14, 'Clusters', 'G', 'COLD', 110, 3, 2, 140, 2, 13, 7, 105, 25, 3, 1, 0.5, 40.4),
(15, 'Cocoa Puffs', 'G', 'COLD', 110, 1, 1, 180, 0, 12, 13, 55, 25, 2, 1, 1, 22.736),
(16, 'Corn Chex', 'R', 'COLD', 110, 2, 0, 280, 0, 22, 3, 25, 25, 1, 1, 1, 41.445),
(17, 'Corn Flakes', 'K', 'COLD', 100, 2, 0, 290, 1, 21, 2, 35, 25, 1, 1, 1, 45.863),
(18, 'Corn Pops', 'K', 'COLD', 110, 1, 0, 90, 1, 13, 12, 20, 25, 2, 1, 1, 35.782),
(19, 'Count Chocula', 'G', 'COLD', 110, 1, 1, 180, 0, 12, 13, 65, 25, 2, 1, 1, 22.396),
(20, 'Cracklin\' Oat Bran', 'K', 'COLD', 110, 3, 3, 140, 4, 10, 7, 160, 25, 3, 1, 0.5, 40.448),
(21, 'Cream of Wheat (Quick)', 'N', 'HOT', 100, 3, 0, 80, 1, 21, 0, -1, 0, 2, 1, 1, 64.533),
(22, 'Crispix', 'K', 'COLD', 110, 2, 0, 220, 1, 21, 3, 30, 25, 3, 1, 1, 46.895),
(23, 'Crispy Wheat & Raisins', 'G', 'COLD', 100, 2, 1, 140, 2, 11, 10, 120, 25, 3, 1, 0.75, 36.176),
(24, 'Double Chex', 'R', 'COLD', 100, 2, 0, 190, 1, 18, 5, 80, 25, 3, 1, 0.75, 44.33),
(25, 'Froot Loops', 'K', 'COLD', 110, 2, 1, 125, 1, 11, 13, 30, 25, 2, 1, 1, 32.207),
(26, 'Frosted Flakes', 'K', 'COLD', 110, 1, 0, 200, 1, 14, 11, 25, 25, 1, 1, 0.75, 31.435),
(27, 'Frosted Mini-Wheats', 'K', 'COLD', 100, 3, 0, 0, 3, 14, 7, 100, 25, 2, 1, 0.8, 58.345),
(28, 'Fruit & Fibre Dates, Walnuts, and Oats', 'P', 'COLD', 120, 3, 2, 160, 5, 12, 10, 200, 25, 3, 1.25, 0.67, 40.917),
(29, 'Fruitful Bran', 'K', 'COLD', 120, 3, 0, 240, 5, 14, 12, 190, 25, 3, 1.33, 0.67, 41.015),
(30, 'Fruity Pebbles', 'P', 'COLD', 110, 1, 1, 135, 0, 13, 12, 25, 25, 2, 1, 0.75, 28.025),
(31, 'Golden Crisp', 'P', 'COLD', 100, 2, 0, 45, 0, 11, 15, 40, 25, 1, 1, 0.88, 35.252),
(32, 'Golden Grahams', 'G', 'COLD', 110, 1, 1, 280, 0, 15, 9, 45, 25, 2, 1, 0.75, 23.804),
(33, 'Grape Nuts Flakes', 'P', 'COLD', 100, 3, 1, 140, 3, 15, 5, 85, 25, 3, 1, 0.88, 52.076),
(34, 'Grape-Nuts', 'P', 'COLD', 110, 3, 0, 170, 3, 17, 3, 90, 25, 3, 1, 0.25, 53.371),
(35, 'Great Grains Pecan', 'P', 'COLD', 120, 3, 3, 75, 3, 13, 4, 100, 25, 3, 1, 0.33, 45.811),
(36, 'Honey Graham Ohs', 'Q', 'COLD', 120, 1, 2, 220, 1, 12, 11, 45, 25, 2, 1, 1, 21.871),
(37, 'Honey Nut Cheerios', 'G', 'COLD', 110, 3, 1, 250, 1.5, 11.5, 10, 90, 25, 1, 1, 0.75, 31.072),
(38, 'Honey-comb', 'P', 'COLD', 110, 1, 0, 180, 0, 14, 11, 35, 25, 1, 1, 1.33, 28.742),
(39, 'Just Right Crunchy  Nuggets', 'K', 'COLD', 110, 2, 1, 170, 1, 17, 6, 60, 100, 3, 1, 1, 36.523),
(40, 'Just Right Fruit & Nut', 'K', 'COLD', 140, 3, 1, 170, 2, 20, 9, 95, 100, 3, 1.3, 0.75, 36.471),
(41, 'Kix', 'G', 'COLD', 110, 2, 1, 260, 0, 21, 3, 40, 25, 2, 1, 1.5, 39.241),
(42, 'Life', 'Q', 'COLD', 100, 4, 2, 150, 2, 12, 6, 95, 25, 2, 1, 0.67, 45.328),
(43, 'Lucky Charms', 'G', 'COLD', 110, 2, 1, 180, 0, 12, 12, 55, 25, 2, 1, 1, 26.734),
(44, 'Maypo', 'A', 'HOT', 100, 4, 1, 0, 0, 16, 3, 95, 25, 2, 1, 1, 54.85),
(45, 'Muesli Raisins, Dates, & Almonds', 'R', 'COLD', 150, 4, 3, 95, 3, 16, 11, 170, 25, 3, 1, 1, 37.136),
(46, 'Muesli Raisins, Peaches, & Pecans', 'R', 'COLD', 150, 4, 3, 150, 3, 16, 11, 170, 25, 3, 1, 1, 34.139),
(47, 'Mueslix Crispy Blend', 'K', 'COLD', 160, 3, 2, 150, 3, 17, 13, 160, 25, 3, 1.5, 0.67, 30.313),
(48, 'Multi-Grain Cheerios', 'G', 'COLD', 100, 2, 1, 220, 2, 15, 6, 90, 25, 1, 1, 1, 40.105),
(49, 'Nut&Honey Crunch', 'K', 'COLD', 120, 2, 1, 190, 0, 15, 9, 40, 25, 2, 1, 0.67, 29.924),
(50, 'Nutri-Grain Almond-Raisin', 'K', 'COLD', 140, 3, 2, 220, 3, 21, 7, 130, 25, 3, 1.33, 0.67, 40.692),
(51, 'Nutri-grain Wheat', 'K', 'COLD', 90, 3, 0, 170, 3, 18, 2, 90, 25, 3, 1, 1, 59.642),
(52, 'Oatmeal Raisin Crisp', 'G', 'COLD', 130, 3, 2, 170, 1.5, 13.5, 10, 120, 25, 3, 1.25, 0.5, 30.45),
(53, 'Post Nat. Raisin Bran', 'P', 'COLD', 120, 3, 1, 200, 6, 11, 14, 260, 25, 3, 1.33, 0.67, 37.84),
(54, 'Product 19', 'K', 'COLD', 100, 3, 0, 320, 1, 20, 3, 45, 100, 3, 1, 1, 41.503),
(55, 'Puffed Rice', 'Q', 'COLD', 50, 1, 0, 0, 0, 13, 0, 15, 0, 3, 0.5, 1, 60.756),
(56, 'Puffed Wheat', 'Q', 'COLD', 50, 2, 0, 0, 1, 10, 0, 50, 0, 3, 0.5, 1, 63.005),
(57, 'Quaker Oat Squares', 'Q', 'COLD', 100, 4, 1, 135, 2, 14, 6, 110, 25, 3, 1, 0.5, 49.511),
(58, 'Quaker Oatmeal', 'Q', 'HOT', 100, 5, 2, 0, 2.7, -1, -1, 110, 0, 1, 1, 0.67, 50.828),
(59, 'Raisin Bran', 'K', 'COLD', 120, 3, 1, 210, 5, 14, 12, 240, 25, 2, 1.33, 0.75, 39.259),
(60, 'Raisin Nut Bran', 'G', 'COLD', 100, 3, 2, 140, 2.5, 10.5, 8, 140, 25, 3, 1, 0.5, 39.703),
(61, 'Raisin Squares', 'K', 'COLD', 90, 2, 0, 0, 2, 15, 6, 110, 25, 3, 1, 0.5, 55.333),
(62, 'Rice Chex', 'R', 'COLD', 110, 1, 0, 240, 0, 23, 2, 30, 25, 1, 1, 1.13, 41.998),
(63, 'Rice Krispies', 'K', 'COLD', 110, 2, 0, 290, 0, 22, 3, 35, 25, 1, 1, 1, 40.56),
(64, 'Shredded Wheat', 'N', 'COLD', 80, 2, 0, 0, 3, 16, 0, 95, 0, 1, 0.83, 1, 68.235),
(65, 'Shredded Wheat \'n\'Bran', 'N', 'COLD', 90, 3, 0, 0, 4, 19, 0, 140, 0, 1, 1, 0.67, 74.472),
(66, 'Shredded Wheat spoon size', 'N', 'COLD', 90, 3, 0, 0, 3, 20, 0, 120, 0, 1, 1, 0.67, 72.801),
(67, 'Smacks', 'K', 'COLD', 110, 2, 1, 70, 1, 9, 15, 40, 25, 2, 1, 0.75, 31.23),
(68, 'Special K', 'K', 'COLD', 110, 6, 0, 230, 1, 16, 3, 55, 25, 1, 1, 1, 53.131),
(69, 'Strawberry Fruit Wheats', 'N', 'COLD', 90, 2, 0, 15, 3, 15, 5, 90, 25, 2, 1, 1, 59.363),
(70, 'Total Corn Flakes', 'G', 'COLD', 110, 2, 1, 200, 0, 21, 3, 35, 100, 3, 1, 1, 38.839),
(71, 'Total Raisin Bran', 'G', 'COLD', 140, 3, 1, 190, 4, 15, 14, 230, 100, 3, 1.5, 1, 28.592),
(72, 'Total Whole Grain', 'G', 'COLD', 100, 3, 1, 200, 3, 16, 3, 110, 100, 3, 1, 1, 46.658),
(73, 'Triples', 'G', 'COLD', 110, 2, 1, 250, 0, 21, 3, 60, 25, 3, 1, 0.75, 39.106),
(74, 'Trix', 'G', 'COLD', 110, 1, 1, 140, 0, 13, 12, 25, 25, 2, 1, 1, 27.753),
(75, 'Wheat Chex', 'R', 'COLD', 100, 3, 1, 230, 3, 17, 3, 115, 25, 1, 1, 0.67, 49.787),
(76, 'Wheaties', 'G', 'COLD', 100, 3, 1, 200, 3, 17, 3, 110, 25, 1, 1, 1, 51.592),
(77, 'Wheaties Honey Gold', 'G', 'COLD', 110, 2, 1, 200, 1, 16, 8, 60, 25, 1, 1, 0.75, 36.187);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=130;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
