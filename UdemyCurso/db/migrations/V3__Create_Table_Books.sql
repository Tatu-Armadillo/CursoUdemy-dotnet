﻿CREATE TABLE `books` (
  `id` bigint AUTO_INCREMENT PRIMARY KEY,
  `author` varchar(100),
  `launch_date` datetime(6) NOT NULL,
  `price` decimal(65,2) NOT NULL,
  `title` varchar(100)
);
