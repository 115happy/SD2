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
-- Table structure for table `tb_dise_case_tab`
--

DROP TABLE IF EXISTS `tb_dise_case_tab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_dise_case_tab` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `index` longtext NOT NULL,
  `dise_case_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_dise_case_id` (`dise_case_id`) USING HASH,
  CONSTRAINT `FK_tb_dise_case_tab_tb_dise_case_dise_case_id` FOREIGN KEY (`dise_case_id`) REFERENCES `tb_dise_case` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_dise_case_tab`
--

LOCK TABLES `tb_dise_case_tab` WRITE;
/*!40000 ALTER TABLE `tb_dise_case_tab` DISABLE KEYS */;
INSERT INTO `tb_dise_case_tab` VALUES (1,'1',2),(2,'2',2),(3,'3',2),(4,'4',2),(5,'5',2),(6,'1',3),(7,'2',3),(8,'3',3),(9,'4',3),(10,'5',3),(11,'1',1),(12,'2',1),(13,'3',1),(14,'4',1),(15,'5',1),(26,'1',7),(27,'2',7),(28,'3',7),(29,'4',7),(30,'5',7);
/*!40000 ALTER TABLE `tb_dise_case_tab` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-25  0:07:16
