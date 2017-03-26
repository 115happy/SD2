-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 25.38.191.30    Database: vet_app
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ref_rprec_pic`
--

DROP TABLE IF EXISTS `ref_rprec_pic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ref_rprec_pic` (
  `role_id` int(11) NOT NULL,
  `clinic_id` int(11) NOT NULL,
  `pic_id` int(11) NOT NULL,
  PRIMARY KEY (`role_id`,`clinic_id`,`pic_id`),
  KEY `IX_role_id_clinic_id` (`role_id`,`clinic_id`) USING HASH,
  KEY `IX_pic_id` (`pic_id`) USING HASH,
  CONSTRAINT `FK_ref_rprec_pic_tb_pics_pic_id` FOREIGN KEY (`pic_id`) REFERENCES `tb_pics` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_ref_rprec_pic_tb_role_play_records_role_id_clinic_id` FOREIGN KEY (`role_id`, `clinic_id`) REFERENCES `tb_role_play_records` (`role_id`, `clinic_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ref_rprec_pic`
--

LOCK TABLES `ref_rprec_pic` WRITE;
/*!40000 ALTER TABLE `ref_rprec_pic` DISABLE KEYS */;
INSERT INTO `ref_rprec_pic` VALUES (1,1,1),(2,1,2),(3,1,2),(1,2,11),(1,2,12);
/*!40000 ALTER TABLE `ref_rprec_pic` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-25  0:07:13
