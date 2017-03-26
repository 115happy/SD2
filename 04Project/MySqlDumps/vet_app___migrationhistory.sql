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
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__migrationhistory`
--

LOCK TABLES `__migrationhistory` WRITE;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` VALUES ('201703150141213_InitialModels','VetTrainer.Migrations.Configuration','‹\0\0\0\0\0\0\í=\ÙnÉ‘\ïö\Zýh\Èljd{g\Ò‡”aÍ‘ R‚÷‰(v\'©‚««\ÚU\ÕZ™ö“ö6«²Ž<\"òª³\É\Æ`fØ•™‘qe\ä™ÿ÷¯ÿ=ûóm´øN\Ò,L\âó\å\ë“\Ó\å‚\Ä\ëdÆ\ç\Ë}þð»Ÿ—þÓ¿ý\æ\ì\Ýfûcñµ®÷¦¨G[\Æ\Ùùò[ž\ïÞ®V\Ùú\Ù\Ù\É6\\§I–<\ä\'\ëd»\n6\É\ê§\Ó\ÓÿX½~½\"Ä’\ÂZ,\Î>\ï\ã<Ü’òýy™\Äk²\Ë÷AtlH”U\ßi\ÉM	uñk°%\Ù.X“ó\åW’ß¦A“ô„U^..¢0 ˆÜ\èa¹\â8Éƒœ¢ùöKFnò4‰ovôC\Ý>\í­÷D©\Ð\ÛV·¥\äô§‚’UÛ°µ\Þgy²uøúMÅš•\ÜÜ‹ÁË†u”y\ï(“ó§‚ê’\çË‹8ˆž²²L\î\ì\íe”þžÔ­^-Ú²W.P•)þyµ¸\ÜGù>%\ç1\Ù\çi½Z|\Ú\ßG\áú?\É\ÓmòwŸ\Çû(\âÑ£\Ò2\áýô)Mv$ÍŸ>“‡\n\é›\åb%¶[\É\r›f\\FÎ‡8ó\Órñ+\í<¸H#}Žô›<I\É_¥*\È\É\æS\ç$¤\äŸÒ»\ÔWñßº7ªnt\à,\×Á¿’ø1ÿv¾üý–‹÷\á²©?T|‰C:\Ìh›<\Ý\0A}§Û„¡º\Û+²·A´\\|J\é_\ÕPþy¹¸YDˆ~	ü¯Á÷ð±d‡\Ô\ÑU˜‘ #—ô\ß\Û\àžj\Îg•õ²oáŽ¹±\Î\ÓB\ë¾O“\í\ç$RÀ4U\înƒô‘t$úz7\É>]KhŸ­Z×ª½\ÔMùÅ¶\Ç!\0÷o\È\Í 18Ù˜©µUøV{û\ÕôZƒMš^jBùN\Ì \Úr5\Ý U\êBU‹~º´\âuUetYn\â2«\ä\Ê\âO\áº\ÖVh¶uQL\ë*&d›z®øÞ’¹²UEÓ²Ü„&«\äŠ\ã\×pC+$\ëš(–¬‚	Íª„§\ÏD\â=‹§°¯IVQT,\ë4Ü±\Õ6\Ú÷›\Ó\ÓS«\Þmuÿò[¡„Fk]Wƒ4+\Õi}]¥ÃŒb³\äóUt˜c3#	Z\ÜùN ¤…rl+uZ¥\Ö\âv±+¬\ÍÑ¤\ÌÇ¤ô½1“›Lb±\\™VfK·¤”,[—™\Úk–>§ù§J$E¯ýmñD\Ã\ß\×\Ìgð4\âˆjA·Ó¢ü®ôL…rlð‰•ú~m!X‡\á„Ã°\Ó\Ê\ÊM‘q«¬Ÿ6\Ò]¿£\Z\ÒGý›Pÿ\ä˜4\\“yžvÛKÎ¹\Å\Ã+/%¯N‹\Üô¼jtTõù¨ú—4\êce?«}…\ÔY9¨\È\æ2\ni+E ¶cU€ŽTV\ÉJE\Êø”\Ë]µ+\ä<\ì‰\Ë²Áªt\ÅþCœQqn\é`1o\ËA¬bc¨Ž\'¶Ÿ?}&\ë$\ÝÀ¸Ö¥ ¦J¡‚§Z£\ÛYO¥´Ng=e›£©ž©\Õh~J²°\è\éoö\Ë ;€ÿ\å\r‘&\ÃQYW¡šb›¹Re\0T\éÕ©\ç0s ¨y;\ï\n(ˆ	£%w¼h½¸\ïª\á\â]-+\îH¬¨TˆüwŒ5½;+¸ª£P(À\Ð\é\Ã1\Ø*¢›Mo\Û\íúµ\ë¥&ô´\è·v@\ÖF¤ÛŒ,!óÝ‹möXu\Ê#_·2\ín9\èŠ}”\Ët¨õn\'9Øª­T\nu¨õa3òÜ¬e\Ñ\âh\'\çc\'/“8\'­³ó\Ù\èW5ˆ½‡óð\çv±[†‚NH;˜\í \æ`\0G\Ò\ÚÖ”ö\Ê\ÍØ”MŽ\Öf>\Öf˜5\Ò:5\í\Ã&­†·l¶Ÿ\Û\Ö\ro\ãf³–Ò˜·nxZžzª8JEø‰§?kû[s3Áu«‰¬pÁ\ÕƒU\Û!\ìj¶\ëNœ\"[À\í\\W(…–i\ìV£‚u@{+#%\ïU\äò^O}	(n\Îõ˜±\Z\0V\åy ŠQY\Ú\ãŽ\ÓÁþ 8õ±\×d\ìp²=´\Åqõöõü\Ï\ä\n\á\ÓÁ9£S9«³eAŽ¯ñó%#©\Ûø)Z\Ç\Ï|\ÆÏ§ \Ëþ»\\¡ÿqÈ’‹}þ-IK¶T=ú\\¨W\âóCFUœl\Éöž¤\×\r/I¨¾±\Z®óû­¤ñ‚²÷Qð\Ø^\à:\ZP}Œ	*‘\rI£\'*@^gE–]—\Ü\Æ\ï\× \Ú\Ó§\n{…º›m7•_\ë+\ß\ì©\\\Ä?©üfœ\å?^dY²KÖ¡wmj­\Øù»x³°Ì³m•M\Îÿ¾¦Lw”­T\ç\Ë\ß*š;i6Km\'\Í\Ý\nZðg+ŽtkŽ\ÔIx*‰a d,U1kô\×i&¸\ÔN“´0”At™»`:rÕ¨‡ñ:\Ü‘‘>©¥\å„PÈ¡\éC.¹\";¶\ÜH¿\çM\Ò<eâŽ§úÈ§06¢FóõzU(4\×\Üøv\Ö0„ò‘U\r\áŒ\r\Ò\ÅSªŸ˜Cc\Ð$¡FQŽdsZ\érg.&D0E²#LYró¨CR<x\ÜeœDŽ7À@&8Œ¬:mj\Ã\Þ& X®`¤[2X#Iù\\eN_#ŠÁ0Ô†„´òA\\ö\äk£œ[\àMz\Æ\0`\ÞU¥“I—œ¸-d\å\Ñ\Ñò‰0†z<\Ü\"Öº$\ì	\ÆN•ùepuT-\Ûe\ÙP|Œ¯HDr²¸X\çe¤-?\ë`£n}\éöiÓƒ\ÝEPÁ\ä\"²°\és«Œdh\Õs~£b\è\ìK\'Õ¶§(j\à\Ñ#Gny\æ\î@*\Æl\ZY=Ø’Q£\0D\ÇIORü-\Þ\ÍÈ†ðhiAx\Øô‹zpGµ•\ïË¨²#¬\'“ýû-\Ø**j€‰dM¬ik’\ÑB¦1ôt¹-Ž¦\Î Ûš¥\î\Ä§H4o\ÆDö\éÉ‰n[‹frºÎ¾V!l»ˆne\åÐ³IL¤ok0ºw\é¢5]¶-õE g<e(>8M1\Ì+H¾W?º\Òm:\é¨-\"Iã©‹Hô\á\è–Toyˆ¥›¥z;)uKfX\"Šš\Þ\ÞX1\Òñhl‰#nUzc\Ã@+VðPd\ë”au\Ø\É/v»«_\Ê,0\ëÅŒ…5dUð‡LG÷†\äu\ä@svb¡x\Ç^ˆ0”xq”\Ìm{€hFP\ÌùA©\ßv¸hð°Q\n\Ã|C&P\ì\æ\"FyPohÜ†¾*\í\ÛebgÎ¦²³š¦\r\0„}¿\Ù1\0ªÒ“\Ìú\Z×¡­J\ëj\Ì\Zšsü\n„v\ßo\Â.\rP”\çH†\ÆEpÔ˜\rI9ƒ\rZ\îZ|®¶\á}y‘`\èÓe\ía\ÚÃm\é‘\Ï\ÕDn¸qª¹(U\Ë$0ò#DŽýYc\Í9Ú‡×˜\Â^9¢\ÈO\Ï\ZmTJ\×Ò•YX$‹½~úsOº©e›&\Z¢Ž\ÇP	²ba\ÉuÖˆ±8k41\Z5p”†JM5Q›\Ù\ÇeXðºÛ˜\ã®04\Zk \Ò@gR\ÅXƒ~Ì´]À\Ãd4tf\rx»„\Êcøv(­\ì,9\Z„õŒ†\'º\\‹Ÿ\\©\ÖJZ–\0»KŒ\0qoÙ\â.’ƒU\áÜ™\rJBš\Êm„ì ‘b8¼¹µ¡†XT?]\×K\íþX \Ç9Œ½nd82b¤Q!&\å\0l@\Ý\è\"Ú#\'ž-\îu„C®óa\Å\Ïv\ZÑ«^uXV‚_\Ý_\ä‚\'\ÝÄ¼.„\×\Û=\r\éÐ¹’•\Ë×Ÿ|\é\äˆT\ã\Û\ç€óÀ\à¶ôw›F\àtI–\Ê“_\Ø\Ö3lÉ¶¾`;\Æú3D7)h\ÅV®b?>Œ4ˆw¡ä›–F ·ÓðÁ—CÒ½\"(\ÍFK\0û\íü¨aô£76wP\ÊoòDõ³\ZiPÀwV\Ùd\Z$ZÿT?\Z|ð —\ÞycLz·U?\Ü\éq\Õù¸{ª);[±×¿«g+\ä™ð³\ë`·\ãG\î\Ùð\ê\Ëâ†½~ù»÷×´·\ÆJ\\»\ËÎ´¦§<IƒG\"•w\äm\Èû0\Íò« \îK\Ï\åf«T“qÈ‰}Ý›\äoS\åV\å\×\rŠ¿·ò¾7\àÞ¯š¿§¤+…’J¢œŒCM\Å\Û\íA¤@¢ýe\í·1ûxk–:Ï·\Ë/ö\ê÷\ÙxAõM…r¶’8 \Ä2(¬–ô^•`\Í\Û.ò•¦\îR6F\ÖÕ£\Ò\0ö\É†”\É\Ã\ÚÐ¢»uq.\r£5½\è{”{7¡\Î\è¾\ât¤M²ÝŒ¤\\»Ïº	v\rZ\Èk8W±ºmT9\Èa(‡\Æ	\å1üý‡þ\áè‡”•«˜ù¼ð­\Í\Ñ\Ì3\ï`/r.C~¼e\r·žZ\ÞS	ñs:I¥¢ò\Ølj9`ªgùx;öi6²Ôœ¸¸ˆ³Žis—(\Úr®B-o½\ã\ì‹N³ %’œ¶f§}³2ê¸«\ÏiU:ŽmVuHÃ¹*ZoŠ\Â=%˜¢$»s\Ú-r/b\Ép”Ký˜šL¢fz’‹ªq!²\î\ê¦kü\ìU®}µ‡‡²-¾\Þ!ör\"mÁ\Î\Ò]ô\äV9’´\Ò¸\Ù\\u£y\ÍD˜f\ê\Ïx\ÚB=\n.*Â‚\Ý\Ýui7W%9.Ž|µ¬\rh\é¦hMN„»®\áMQ.WHð\ÌM‹H#7½óÒ¡b±¸«Ž¢B\Èl\Ä6›«E\é\Ï\"$\í¥åŠ¾î¨¢\Ík]Â²Žº)H™¡\ä® p³¹*H{s·°)i¾:£·÷Y\'\é\íg\ïœt·À¡\ì.O\îÒªt\n£\rt\ÎU.Y\ÍÞ‡\Ê5\ÒûJ1ÿxY»*¡47•…V\Ê\Úz9s\nR\Ýòr¨\ZŠ?š\è\rVhŸ1”\ÃJ|uAJŸ²P©¢\Z*\ÎZ0éª‹øû“:˜\Â\ÕY3§‘¹”ü\ä0ø«ú‘ä›‡“25\Ó!/¤`ù\âHaŒ-w0³\Ë\îtŒk€Ÿ‚!ý\0C5\é`žüˆ}\ÈZ“Z\æ‰\Ú\Ù\âŒ#\é*Z\ÓR\ÌUm\\\ÆÐ‰–ž‹†kž&“®\á(+¼ŠHÅ±e\äŸÙœhFp]\Å~ü¢)k–|t<U\è\éLÁQW\ÐdºÃ±b~žé¤¡­	(\àéœ€p\ål>O–¡:\á*J =\Ð%/ý\êo\Ð\×\Ñ\åVC¾®Œ\rxð\èY7L—°=ƒÁnº\ï\ÍJI¾@&œôm´¨ŽOû¶š‚f4\Îh\â?\\	CI—\æ@\n±>3»²^â‰šc\ÚT[Ôº\É\ÙGûÞ \Û-ô\ÐFúmºý¢Ï—7\Ó\Íú\á.\Þ\à\ÔA@6sb-\Ë\r.\áp¦’?\Ô\r’\é xl>«\Ù\Î\é\ÚtÊ™\Ê~\Æs¼’\î)Wi\\CÕ—\æw“\îY¥Z\n9 %QEFgILV¥}Ê¹—¬\ÊrAq/¨KÏ—\×O7ÿˆNŠò“òO:ƒ–\á>u\ë H–³\×W—8ù÷\å\â\"\nƒŒ%\çVY¥o\å«S­\ÒL_¿)\ÒL\Éf»’›»\'«P²l#¼—\Ì9Sk èŽ²{UYUó«\Êaó\ÜpX0\Õøn²\ã3ÀÌ“\Ê:ˆ¿\éú[*O);Â¬ÓŠ\Ô\rY‡\Û *ôþU>Õ»|ý3¥„ R>u\ëùÖ°$]†\åÁŠ§\Ê\Öd=D	Iyª#\ÑOÄ¡«\\W\\&Œž/ÿ§løvñ\áow|\ÛW‹)\Ðo§‹ ¶g\"³!†d\ÑÀ|szz\ÊCe\ïŒ{I|\'y,aXh¤¬‡‡ ¿^M\â´\êf6«ln›|Is[µ\ÐÜª¹Š/X‚ö\ÌS^0\×T˜U\Þ\â¸\Ë>ðô\é(f³\ê07Œ5\ã¨@¹S\\7«\Ù4\ÄLf—\åôL\îQ¿V…*ñ\ÐÝ–\Ø\ê¸µ\Zaþ‘£*\r­J\\F\á8+dõ@ü(d\Þ\Ê\×ù€/aö\0ŽÈ\Ê\Ðaqb£/gmg\ã\Ù)¥\ÖE\Ý\ëflºq\ãZ\Õ\Ìa<¦\Èfw(¼¿~´2[1)p9«iwG9óû&£O÷\î»].½ãˆ«/GJ\éc\î“$\Z\Æ\Ö\ÅSi\á]WxšY\Û\Ô}ýT¬}\'\Ó-P\â†\×tÀóÛŽ^3<§M§\n\Þbõ”f\×ù÷0¼ž`¢Û€£\É;°\ÚP\áˆk6„H\rYl–ó4,ªV†#\n-&ö¦G\ÇkÕ®“\àv^+ò\ër\ÜCl\Þ\Ç6.2C\Âg.´k·¾«fCˆM›q6\â¸×\Ùm¯\ÜÓ¶\Õ{×Œ£ñú\Ø	,\íx\Ø2Áa‹³™ð>†\ÎH`±ÁG3\á‚F\ËE7,\êv\Ã.)üOÿ]\Öþš4\é¢bŽ¢\Ó\ç²\Ù\É\Î\Í`’6o\â\ã\íu\Çs[\Ýamèµ³ö]ö\Íjc=·u—)\×l@yz\ï\Õf%\Ðù\íÝŒId\Ê\Ô®œ•Pg0wrYj \\õ\×\ï¡\ï\"\Ö\ï6.\×û(wQ¸¦øœ/_+©‡\ã+‘œ,.\Ö,…Œ¶\\•Eö>Ç«­\"\â÷[¥[ª‡$-üeAt™ó`ª÷6~J\Ãx\î‚\æT\Ý\Ò\ÝW\Ð\Ü\0–K®ÈŽÄ…O\Ï›žm\Ò2›\î$™˜¸#dFú©\"”\ÎÉ‰6&\Þ¢~N\âŸNñ4\Î\Çñu\îÌ¡eŒ	V\Õ6YšÜ³Í¬7RýIrzr¢\Â\éj”\ÆPô™>ÛžF–¿öõ\Ñ\áÁ{*\íª\Z\ß\\8\ÎOS\ë‰ùŽZU°DÇ–\n«\Ñ\Û~UlDõrUjÍ…ÁSi—a\Ù\ãe…^‚–lÈ¼4mÆ¬Q­r\ÆÙ®L>\ÄÊ¾;\Ïv6F±_µ(O-\ìu!BibÓ…_\Ä}0›ÿ20Ç‰?\ËM?òö\ê¡løñ\ÖyY+\Ò\äù\Üõ\ÌV\Îi~\ÉýJe{\É<\'W\Îu\ÈË“ÿ<Š~©Ñˆ0:M\é Ú¥}³w3¾#\0wª¹Ÿs\"3\Ø-H¢ˆŸµv9Iy\n\ÕÂ¯üW±ð»6gm¹Jg/Œ+zV6y v\Î¿•“§\"EHv\ÏT—\ìe:ºi\î¥A‰š\ËòÁZÎ³ÁŠ\ÏFõij¬yÚƒ(\rúx}\ïj£y\Ö-¬mT•±]Š;\Én`ý–IJ\Ù \Ú\ä$cÝ£\ZŽ\Zá¬„.«ñœDsg¿ÀŸ^oG\\\Üûh\à¤K{\ãûH¼$‹›!ñ•\ÆÑ¢6gF\Æ\0ž\Åû²yð£\×ý+ú¨•›\Õ\Z_ihòe\×DŠ3\â\Ò\ËMuf3…\Í\Ì\Ä\ÖL°R\Í\Îô²†WQ4|\Ìt\Î\Ñ!Dª’—½>{yN«sÍ‹/œ¶¨ZjÇ³\ÔU{]\çt/\íŒ{(jgø\æwÚ®ª”Rö¬\Î\Û”y6\î‡`¢¦×¨\ÑÌ”2Ml¨,_Þœ\Ñ^PI\ÉV1Á­\æÁ\íM©\Îr	eùf\ê§¿9(×¸ —‚M<Vú\Õ<H\Û\ÙTyP^\ç\ïg`\\¹gbW\Ø+´C\Ý*N\á\à\Äm0YW\Ï-l\Ë%òÁ‰\Û~:µ¼]\Þ?˜|h\â@j<Ë¬—\Éež‰‡ã¢Ÿ—\æ\è®÷W¹Iö\à\Ûòm\í”Tü,\íœõªjžFnöq»sÑ³±\âw=µk\Ú^I©\ìüó¶h\ê¶\0,–6\Í~\ë0O£v¾‘ùh\Ûh>_%\ÕOò®¼áŽ¶\Éi’\ÖGÉ†¼\Ó,¿\n¨¢+‰øU«’WõÛ‹¸\Þ57\æ)wˆÝ¬¿‘m@\Ñ}!ú\êA¨û\ê\Ù’gb\'²•Tº’+ \nƒØ¥W}—\æþŒ}\ÕWW)\Ý\ÔH\ë²Øšƒ8Z\Z!±-°nX©Ž]yY\Ã\ÔW™®vR~Æ \éñF\ÈÍŽQÞ” ð\éF\Ë¾>¸S\å\\`rf1¬Fø¼\ãF\éƒ/Dú	[w–±/¶UzaŸøyy¬m‚\\M\n\è\ê;û;;F5o#\íøm\ÒEåµ‹‚§»´¬h\Ñ[\rªöT~\Öôb†\\>‹§BfŸ\È{Z\èjn5«õž’‡»ÍºX<M=;<¬\ì°\Ñ—ýf³vd\0fl€Jz\Â7e\ëŒ›\" \Ö3ób\îB3\Ñrr¨¦W|ˆ·]\æeË±ˆ“ª\ÔÀzMwtHZ\ÊGÔƒSg‹Ë®\n+°®*YRˆ™4©\\O\ÝwV\ÉZX§J\r½(\íºU#I\Î4\r×žš¢ª\ãp\Åu	©§´6\Z\Íz\×!Öµ\Õ·O†\Î\rRg½\ÃR\ç6\Ê%\Ø®ˆþ\Úl\íYJ\ÃµH\ÙCaP\ä€v\ÍY+‘!˜Um\â˜mû2A\Â0R\æÈ úNa=SÀ›‡1r0\Z´\ì·ge\ÓúS¯\äŠ<\ÍLt\ËÕ‡c€÷°ógxW,\ÎóÕ²A%6Œ0ðS\ÃÖ¾b4\æ\ÛP‡Ð)#^Ä‰sDsa\'D\n’Á\ÓpœPø\êV÷ùC¸q\Ò<y\àT>\Íòû(\0\Ò´;\ê‰=\Ös+~‡¢H˜B\n€ü\ä¬\Ð\\\åp\Âö\â?,u¹_’\Ã\Ö0\Ý\ëJ@š\ÒAX‚+‡\í=uQ)óa†™¡\ç\Ä1ˆfð»)	\Â-´?\ê\rV\n\Ç\0úÒ“‘._I¬½µJ\\$g*l‘’­\ä\ãØ²]û±?-L \ÝuKþ\èƒ-¡Ñ®”\rÀ\\\Ë\í\î\î\é\Å\èÌ„D½C¢¨¦!;\ágx—tD+M;xÀt%U#j\Ó)}Œð1\È\î\ê\Ð\é4tE7iŽeÀ\Ä`#š°¤ž—p\Þ(4ÿ\nv\'\ß\Âli¢b ¸y\é‰G\Ó\ëõ\ë[\Ù÷µ>S¡”\rÀ\n«%Úz0.ðf€–\é\Î=Xv\Ì\åÃµ\Çõ©6\àŠ`™ \Ûã ˜ˆMŠ(\Î8‹´\rpX÷ù\Èr!q\ê€\\\ÉH³Ú¹ùU%ý\áTAY=eiìºŸ¼Y\ì·\\ò\á?ž„T©1«¬\Ï)‡ß™Í†9¦£)\ë£Á5H±Pñ0\ì±VœÁŽ­fÀ\n\ã2\Ù>{cp]Q\Í0X>‹¬\Õe\È%ô°©ŸpoÜ›²³|©>ÐŸy’\ä:Ù(+¿ž­>\ïi\ë-{üý\ìŠd\ác\âŒÂŒ\ÉZ¨o\ê|ˆ’:²_Â¨®\"½kMò`\äÁEš‡Á:§\Åk’eaü¸\\|\r¢=­òn{O6\âû|·\Ï)\Éd{=ñ\Ì(òtýŸ­œ\Ï>\îŠ_Y$P4CJùÿ²£Mƒ÷û ’}žˆ\"ñ\à/„~g²\Ì\éÿ\É\ãS\é\×$¶T±¯É—¸%\Û]De\ã›\à;ñÁ\íKFþJƒõý^„E¥8³ D¶Ÿ]…Ác\Zl³\nFÛžþ¤:¼\Ùþø\Óÿ÷+°¶pm\0','6.1.3-40302');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-25  0:07:12
