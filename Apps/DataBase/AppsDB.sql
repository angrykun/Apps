-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.28


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema appsdb
--

CREATE DATABASE IF NOT EXISTS appsdb;
USE appsdb;

--
-- Definition of table `SysException`
--

DROP TABLE IF EXISTS `SysException`;
CREATE TABLE `SysException` (
  `ID` varchar(45) NOT NULL,
  `HelpLink` varchar(500) DEFAULT NULL COMMENT '帮助链接',
  `Message` varchar(500) DEFAULT NULL COMMENT '异常信息',
  `Source` varchar(500) DEFAULT NULL COMMENT '来源',
  `StackTrace` text COMMENT '堆栈',
  `TargetSite` varchar(500) DEFAULT NULL COMMENT '目标页',
  `Data` varchar(500) DEFAULT NULL COMMENT '程序集',
  `CreateTime` datetime DEFAULT NULL COMMENT '发生时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `SysException`
--

/*!40000 ALTER TABLE `SysException` DISABLE KEYS */;
INSERT INTO `SysException` (`ID`,`HelpLink`,`Message`,`Source`,`StackTrace`,`TargetSite`,`Data`,`CreateTime`) VALUES 
 ('201708111049499812446157ec54328',NULL,'对一个或多个实体的验证失败。有关详细信息，请参阅“EntityValidationErrors”属性。','EntityFramework','   在 System.Data.Entity.Internal.InternalContext.SaveChanges()\r\n   在 System.Data.Entity.Internal.LazyInternalContext.SaveChanges()\r\n   在 System.Data.Entity.DbContext.SaveChanges()\r\n   在 Apps.DAL.SysSampleRepository.Create(SysSample entity) 位置 E:\\AMyProject\\ProjectGit\\Apps\\Apps\\Apps.DAL\\SysSampleRepository.cs:行号 23\r\n   在 Apps.BLL.SysSampleBLL.Create(ValidationErrors& errors, SysSampleModel model) 位置 E:\\AMyProject\\ProjectGit\\Apps\\Apps\\Apps.BLL\\SysSampleBLL.cs:行号 107','Int32 SaveChanges()','System.Collections.ListDictionaryInternal','2017-08-11 10:49:49');
/*!40000 ALTER TABLE `SysException` ENABLE KEYS */;


--
-- Definition of table `SysLog`
--

DROP TABLE IF EXISTS `SysLog`;
CREATE TABLE `SysLog` (
  `ID` varchar(200) NOT NULL COMMENT 'GUID',
  `Operator` varchar(200) DEFAULT NULL COMMENT '操作者',
  `Message` text COMMENT '操作信息',
  `Result` varchar(200) DEFAULT NULL COMMENT '结果',
  `Type` varchar(200) DEFAULT NULL COMMENT '操作类型',
  `Module` varchar(200) DEFAULT NULL COMMENT '操作模块',
  `CreateTime` datetime DEFAULT NULL COMMENT '操作事件',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `SysLog`
--

/*!40000 ALTER TABLE `SysLog` DISABLE KEYS */;
INSERT INTO `SysLog` (`ID`,`Operator`,`Message`,`Result`,`Type`,`Module`,`CreateTime`) VALUES 
 ('2017081018085596548070bff18570a','虚拟用户','ID:0,Name:rose','成功','创建','样例程序','2017-08-10 18:08:55'),
 ('201708110954479862097acac91cf3f','虚拟用户','ID:0,Name:test222','成功','创建','样例程序','2017-08-11 09:54:47'),
 ('2017081110564441068340ed66701b0','虚拟用户','ID:0,Name:fgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfgfg','失败','创建','样例程序','2017-08-11 10:56:44'),
 ('2017081111315540877198edfd9968d','虚拟用户','ID:201708111027504542566b98bf5768e','成功','删除','系统异常','2017-08-11 11:31:55'),
 ('20170811113329628771938d3c7525f','虚拟用户','ID:201708111029568148914b0b2225741','成功','删除','系统异常','2017-08-11 11:33:29'),
 ('201708111134005707719f84534b56a','虚拟用户','ID:201708111033356489923aa425ceeb8','成功','删除','系统异常','2017-08-11 11:34:00'),
 ('201708111135125737719b492326799','虚拟用户','ID:201708111131328077719539ab60ec6','成功','删除','系统日志','2017-08-11 11:35:12'),
 ('20170811113534083771987f5138507','虚拟用户','ID:2017081110374443099239755dd4fac','成功','删除','系统异常','2017-08-11 11:35:34'),
 ('20170811113628412771930977afc68','虚拟用户','ID:201708111056443266750d4889e40e0','成功','删除','系统异常','2017-08-11 11:36:28'),
 ('2017081111372058577198d096836bf','虚拟用户','ID:2017081110044195142024e3aa44293','成功','删除','系统日志','2017-08-11 11:37:20'),
 ('2017081111380992077198eb5dd3d4a','虚拟用户','ID:50','成功','删除','样例程序','2017-08-11 11:38:09');
/*!40000 ALTER TABLE `SysLog` ENABLE KEYS */;


--
-- Definition of table `SysModule`
--

DROP TABLE IF EXISTS `SysModule`;
CREATE TABLE `SysModule` (
  `ID` varchar(45) NOT NULL,
  `Name` varchar(200) DEFAULT NULL COMMENT '模块名称',
  `EnglishName` varchar(45) DEFAULT NULL COMMENT '模块英文名称',
  `ParentID` varchar(45) DEFAULT NULL COMMENT '上级ID',
  `Url` varchar(200) DEFAULT NULL COMMENT '链接',
  `Iconic` varchar(200) DEFAULT NULL COMMENT '图标',
  `Sort` int(10) unsigned DEFAULT NULL COMMENT '排序',
  `Remark` varchar(4000) DEFAULT NULL COMMENT '说明',
  `State` bit(1) DEFAULT NULL COMMENT '状态',
  `CreatePerson` varchar(200) DEFAULT NULL COMMENT '创建人',
  `CreateTime` datetime DEFAULT NULL COMMENT '创建时间',
  `IsLast` bit(1) DEFAULT NULL COMMENT '是否是最后一项',
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '版本',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `SysModule`
--

/*!40000 ALTER TABLE `SysModule` DISABLE KEYS */;
INSERT INTO `SysModule` (`ID`,`Name`,`EnglishName`,`ParentID`,`Url`,`Iconic`,`Sort`,`Remark`,`State`,`CreatePerson`,`CreateTime`,`IsLast`,`Version`) VALUES 
 ('0','顶级菜单','Root','0','','',0,'',0x01,'Administrator','2017-08-10 10:10:40',0x00,'2017-08-10 11:10:21'),
 ('BaseSample','模板样例','Sample by Ajax','SampleFile','SysSample','',0,'',0x01,'Administrator','2017-08-10 10:10:40',0x01,'2017-08-10 10:10:54'),
 ('Document','我的桌面','Start','PersonDocument','Home/Doc','',0,'',0x01,'Administrator','2017-08-10 10:10:40',0x01,'2017-08-10 10:10:40'),
 ('Info','我的资料','Info','PersonDocument','Home/Info','',0,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('InfoHome','主页','Home','Information','MIS/Article','',1,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('Information','信息中心','Information','OA','','',0,'',0x01,'Administrator','2017-08-10 10:11:41',0x00,'2017-08-10 10:11:41'),
 ('ManageInfo','管理中心','Manage Article','Information','MIS/ManageArticle','',4,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('ModuleSetting','模块维护','Module Setting','RightManage','SysModule','',100,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('MyInfo','我的信息','My Article','Information','MIS/MyArticle','',2,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('PersonDocument','个人中心','Person Center','0','','',2,'',0x01,'Administrator','2017-08-10 10:11:41',0x00,'2017-08-10 10:11:41'),
 ('RightManage','权限管理','Authorities Management','0','','',4,'',0x01,'Administrator','2017-08-10 10:11:41',0x00,'2017-08-10 10:11:41'),
 ('RoleAuthorize','角色权限设置','Role Authorize','RightManage','SysRight','',6,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('RoleManage','角色管理','Role Manage','RightManage','SysRole','',2,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('SampleFile','开发指南样例','SampleFile','0','SysSample','',1,'',0x01,'Administrator',NULL,0x00,'2017-08-10 10:11:41'),
 ('SystemConfig','系统配置','System Config','SystemManage','SysConfig','',0,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('SystemExcepiton','系统异常','System Exception','SystemManage','SysException','',2,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('SystemJobs','系统任务','System Jobs','TaskScheduling','Jobs/Jobs','',0,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('SystemLog','系统日志','System Log','SystemManage','SysLog','',1,'',0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41'),
 ('SystemManage','系统管理','System Management','0','','',3,'',0x01,'Administrator','2017-08-10 10:11:41',0x00,'2017-08-10 10:11:41'),
 ('UserManage','系统管理员','User Manage','RightManage','SysUser',NULL,1,NULL,0x01,'Administrator','2017-08-10 10:11:41',0x01,'2017-08-10 10:11:41');
/*!40000 ALTER TABLE `SysModule` ENABLE KEYS */;


--
-- Definition of table `SysSample`
--

DROP TABLE IF EXISTS `SysSample`;
CREATE TABLE `SysSample` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Age` int(10) unsigned DEFAULT NULL,
  `Bir` varchar(45) DEFAULT NULL,
  `Photo` varchar(45) DEFAULT NULL,
  `Note` text,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `SysSample`
--

/*!40000 ALTER TABLE `SysSample` DISABLE KEYS */;
INSERT INTO `SysSample` (`ID`,`Name`,`Age`,`Bir`,`Photo`,`Note`,`CreateTime`) VALUES 
 (1,'张三',20,'1992-12-20 11:11:10',NULL,NULL,'2016-11-12 11:11:00'),
 (2,'李四',20,'1992-12-20 11:11:10',NULL,NULL,'2016-11-12 11:11:00'),
 (3,'王五',20,'1992-12-20 11:11:10',NULL,NULL,'2016-11-12 11:11:00'),
 (4,'tom1',20,'1992-12-20 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (5,'tom2',20,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (6,'tom3',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (7,'tom4',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (8,'tom5',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (9,'tom6',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (10,'tom7',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (11,'tom8',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (12,'tom9',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (13,'tom10',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (14,'tom11',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (15,'tom12',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (16,'tom13',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (17,'tom14',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (18,'tom15',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (19,'tom16',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (20,'tom17',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (21,'tom18',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (22,'tom8',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (23,'tom8',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (24,'tom8',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (25,'tom8',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (26,'tom7',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (27,'tom8',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (28,'tom9',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (29,'tom10',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (30,'tom11',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (31,'tom12',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (32,'tom13',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (33,'tom14',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (34,'tom15',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (35,'tom16',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (36,'tom17',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (37,'tom18',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (38,'tom19',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (39,'tom20',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (40,'tom21',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (41,'tom22',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (42,'tom23',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (43,'tom24',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (44,'tom25',21,'1992-12-21 11:11:10',NULL,NULL,'1992-12-20 11:11:10'),
 (51,'rose',18,'2017-07-01',NULL,'rose','2017-08-10 00:00:00'),
 (52,'test222',25,NULL,NULL,'test222',NULL),
 (53,'wjik',25,'1996-01-23.',NULL,'wjik',NULL);
/*!40000 ALTER TABLE `SysSample` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
