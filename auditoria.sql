CREATE DATABASE  IF NOT EXISTS `auditoria` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `auditoria`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: auditoria
-- ------------------------------------------------------
-- Server version	5.6.13

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
-- Table structure for table `denuncias`
--

DROP TABLE IF EXISTS `denuncias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `denuncias` (
  `idDenuncia` int(11) NOT NULL AUTO_INCREMENT,
  `txtCNPJCPF` varchar(14) DEFAULT NULL,
  `UserNameDenuncia` varchar(255) DEFAULT NULL,
  `DataDenuncia` datetime DEFAULT NULL,
  `Texto` varchar(255) DEFAULT NULL,
  `Arquivo` varchar(255) DEFAULT NULL,
  `Situacao` char(1) DEFAULT NULL,
  `DataAuditoria` datetime DEFAULT NULL,
  `UserNameAuditoria` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idDenuncia`),
  KEY `Index_1` (`txtCNPJCPF`),
  KEY `Index_2` (`UserNameDenuncia`),
  KEY `Index_3` (`Situacao`)
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `denuncias_anexo`
--

DROP TABLE IF EXISTS `denuncias_anexo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `denuncias_anexo` (
  `idAnexo` int(11) NOT NULL AUTO_INCREMENT,
  `idDenuncia` int(11) NOT NULL,
  `UserName` varchar(255) NOT NULL,
  `Data` datetime NOT NULL,
  `Arquivo` varchar(255) NOT NULL,
  PRIMARY KEY (`idAnexo`),
  KEY `Index_1` (`idDenuncia`)
) ENGINE=MyISAM AUTO_INCREMENT=107 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `denuncias_msg`
--

DROP TABLE IF EXISTS `denuncias_msg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `denuncias_msg` (
  `idMensagem` int(11) NOT NULL AUTO_INCREMENT,
  `idDenuncia` int(11) NOT NULL,
  `UserName` varchar(255) NOT NULL,
  `Data` datetime NOT NULL,
  `Texto` varchar(255) NOT NULL,
  PRIMARY KEY (`idMensagem`),
  KEY `Index_1` (`idDenuncia`)
) ENGINE=MyISAM AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `despesas`
--

DROP TABLE IF EXISTS `despesas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `despesas` (
  `numsubcota` int(10) unsigned NOT NULL,
  `txtDescricao` varchar(100) NOT NULL,
  PRIMARY KEY (`numsubcota`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `despesas_senadores`
--

DROP TABLE IF EXISTS `despesas_senadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `despesas_senadores` (
  `CodigoDespesa` int(11) NOT NULL AUTO_INCREMENT,
  `TipoDespesa` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CodigoDespesa`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dossies`
--

DROP TABLE IF EXISTS `dossies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dossies` (
  `IdDossie` int(11) NOT NULL AUTO_INCREMENT,
  `NomeDossie` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdDossie`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dossies_parlamentar`
--

DROP TABLE IF EXISTS `dossies_parlamentar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dossies_parlamentar` (
  `IdDossie` int(11) NOT NULL,
  `IdDenuncia` int(11) NOT NULL,
  `CodigoParlamentar` int(11) NOT NULL,
  `TipoParlamentar` varchar(20) NOT NULL,
  PRIMARY KEY (`IdDossie`,`IdDenuncia`,`CodigoParlamentar`,`TipoParlamentar`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `email_pendencia`
--

DROP TABLE IF EXISTS `email_pendencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `email_pendencia` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `destinatario` varchar(255) DEFAULT NULL,
  `assunto` varchar(255) DEFAULT NULL,
  `texto` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=77 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `estatistica_pesquisa`
--

DROP TABLE IF EXISTS `estatistica_pesquisa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estatistica_pesquisa` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(45) DEFAULT NULL,
  `agrupamento` varchar(45) DEFAULT NULL,
  `periodo` varchar(45) DEFAULT NULL,
  `periodo_inicial` varchar(6) DEFAULT NULL,
  `periodo_final` varchar(6) DEFAULT NULL,
  `usuario` varchar(255) DEFAULT NULL,
  `dataPesquisa` datetime DEFAULT NULL,
  `sqlCmd` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=173 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fornecedores`
--

DROP TABLE IF EXISTS `fornecedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fornecedores` (
  `txtCNPJCPF` varchar(14) NOT NULL,
  `txtBeneficiario` varchar(255) DEFAULT NULL,
  `NomeFantasia` varchar(255) DEFAULT NULL,
  `AtividadePrincipal` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria01` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria02` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria03` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria04` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria05` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria06` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria07` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria08` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria09` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria10` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria11` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria12` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria13` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria14` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria15` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria16` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria17` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria18` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria19` varchar(255) DEFAULT NULL,
  `AtividadeSecundaria20` varchar(255) DEFAULT NULL,
  `NaturezaJuridica` varchar(100) DEFAULT NULL,
  `Logradouro` varchar(100) DEFAULT NULL,
  `Numero` varchar(10) DEFAULT NULL,
  `Complemento` varchar(100) DEFAULT NULL,
  `Cep` varchar(10) DEFAULT NULL,
  `Bairro` varchar(100) DEFAULT NULL,
  `Cidade` varchar(100) DEFAULT NULL,
  `Uf` varchar(2) DEFAULT NULL,
  `Situacao` varchar(50) DEFAULT NULL,
  `DataSituacao` varchar(10) DEFAULT NULL,
  `MotivoSituacao` varchar(255) DEFAULT NULL,
  `SituacaoEspecial` varchar(100) DEFAULT NULL,
  `DataSituacaoEspecial` varchar(10) DEFAULT NULL,
  `DataAbertura` varchar(10) DEFAULT NULL,
  `UsuarioInclusao` varchar(255) DEFAULT NULL,
  `DataInclusao` datetime DEFAULT NULL,
  `Doador` tinyint(4) DEFAULT NULL,
  `PendenteFoto` tinyint(4) DEFAULT NULL,
  `DataUltimaNotaFiscal` date DEFAULT NULL,
  PRIMARY KEY (`txtCNPJCPF`) USING BTREE,
  KEY `ix1_fornecedores` (`PendenteFoto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fornecedores_atu`
--

DROP TABLE IF EXISTS `fornecedores_atu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fornecedores_atu` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(255) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `IdKey` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ix1_fornecedores_atu` (`IdKey`)
) ENGINE=MyISAM AUTO_INCREMENT=218 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fornecedores_suspeitos`
--

DROP TABLE IF EXISTS `fornecedores_suspeitos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fornecedores_suspeitos` (
  `txtCNPJCPF` varchar(255) NOT NULL,
  `tipoSuspeita` smallint(6) NOT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`txtCNPJCPF`,`tipoSuspeita`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fornecedores_visitado`
--

DROP TABLE IF EXISTS `fornecedores_visitado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fornecedores_visitado` (
  `txtCNPJCPF` varchar(14) NOT NULL,
  `UserName` varchar(255) NOT NULL,
  PRIMARY KEY (`txtCNPJCPF`,`UserName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `lancamentos`
--

DROP TABLE IF EXISTS `lancamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lancamentos` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `ideCadastro` bigint(20) DEFAULT NULL,
  `txNomeParlamentar` varchar(100) DEFAULT NULL,
  `nuCarteiraParlamentar` int(11) DEFAULT NULL,
  `nuLegislatura` int(11) DEFAULT NULL,
  `sgUF` varchar(2) DEFAULT NULL,
  `sgPartido` varchar(10) DEFAULT NULL,
  `codLegislatura` int(11) DEFAULT NULL,
  `numSubCota` int(11) DEFAULT NULL,
  `txtDescricao` varchar(100) DEFAULT NULL,
  `numEspecificacaoSubCota` int(11) DEFAULT NULL,
  `txtDescricaoEspecificacao` varchar(100) DEFAULT NULL,
  `txtBeneficiario` varchar(100) DEFAULT NULL,
  `txtCNPJCPF` varchar(14) DEFAULT NULL,
  `txtNumero` varchar(50) DEFAULT NULL,
  `indTipoDocumento` varchar(10) DEFAULT NULL,
  `datEmissao` date DEFAULT NULL,
  `vlrDocumento` decimal(10,2) DEFAULT NULL,
  `vlrGlosa` decimal(10,2) DEFAULT NULL,
  `vlrLiquido` decimal(10,2) DEFAULT NULL,
  `numMes` decimal(2,0) DEFAULT NULL,
  `numAno` decimal(4,0) DEFAULT NULL,
  `numParcela` decimal(3,0) DEFAULT NULL,
  `txtPassageiro` varchar(100) DEFAULT NULL,
  `txtTrecho` varchar(100) DEFAULT NULL,
  `numLote` int(11) DEFAULT NULL,
  `numRessarcimento` int(11) DEFAULT NULL,
  `anomes` decimal(6,0) DEFAULT NULL,
  UNIQUE KEY `id` (`id`),
  KEY `Index_6` (`numAno`,`numMes`,`ideCadastro`),
  KEY `Index_1` (`ideCadastro`),
  KEY `Index_2` (`txtCNPJCPF`),
  KEY `Index_3` (`sgUF`),
  KEY `Index_4` (`sgPartido`),
  KEY `Index_5` (`numSubCota`),
  KEY `Index_7` (`txtNumero`),
  KEY `Index_8` (`anomes`)
) ENGINE=MyISAM AUTO_INCREMENT=1115789 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `lancamentos_senadores`
--

DROP TABLE IF EXISTS `lancamentos_senadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lancamentos_senadores` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `AnoMes` decimal(6,0) DEFAULT NULL,
  `Ano` decimal(4,0) DEFAULT NULL,
  `Mes` decimal(2,0) DEFAULT NULL,
  `CodigoParlamentar` int(11) DEFAULT NULL,
  `Senador` varchar(255) DEFAULT NULL,
  `CodigoDespesa` int(11) DEFAULT NULL,
  `TipoDespesa` varchar(255) DEFAULT NULL,
  `CnpjCpf` varchar(14) DEFAULT NULL,
  `Fornecedor` varchar(255) DEFAULT NULL,
  `Documento` varchar(50) DEFAULT NULL,
  `DataDoc` datetime DEFAULT NULL,
  `Detalhamento` text,
  `Valor` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Index_1` (`Ano`,`Mes`,`CodigoParlamentar`),
  KEY `Index_2` (`AnoMes`),
  KEY `Index_3` (`CodigoParlamentar`),
  KEY `Index_4` (`CodigoDespesa`),
  KEY `Index_5` (`CnpjCpf`)
) ENGINE=MyISAM AUTO_INCREMENT=132252 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `lancamentos_senadores_tmp`
--

DROP TABLE IF EXISTS `lancamentos_senadores_tmp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lancamentos_senadores_tmp` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Ano` decimal(4,0) DEFAULT NULL,
  `Mes` decimal(2,0) DEFAULT NULL,
  `CodigoParlamentar` int(11) DEFAULT NULL,
  `Senador` varchar(255) DEFAULT NULL,
  `TipoDespesa` varchar(255) DEFAULT NULL,
  `CnpjCpf` varchar(14) DEFAULT NULL,
  `Fornecedor` varchar(255) DEFAULT NULL,
  `Documento` varchar(50) DEFAULT NULL,
  `DataDoc` datetime DEFAULT NULL,
  `Detalhamento` text,
  `Valor` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Index_1` (`Ano`,`Mes`,`CodigoParlamentar`),
  KEY `Index_2` (`CnpjCpf`)
) ENGINE=MyISAM AUTO_INCREMENT=3388 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `lancamentos_tmp`
--

DROP TABLE IF EXISTS `lancamentos_tmp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lancamentos_tmp` (
  `txNomeParlamentar` varchar(100) DEFAULT NULL,
  `ideCadastro` int(11) DEFAULT NULL,
  `nuCarteiraParlamentar` int(11) DEFAULT NULL,
  `nuLegislatura` int(11) DEFAULT NULL,
  `sgUF` varchar(2) DEFAULT NULL,
  `sgPartido` varchar(10) DEFAULT NULL,
  `codLegislatura` int(11) DEFAULT NULL,
  `numSubCota` int(11) DEFAULT NULL,
  `txtDescricao` varchar(100) DEFAULT NULL,
  `numEspecificacaoSubCota` int(11) DEFAULT NULL,
  `txtDescricaoEspecificacao` varchar(100) DEFAULT NULL,
  `txtBeneficiario` varchar(100) DEFAULT NULL,
  `txtCNPJCPF` varchar(14) DEFAULT NULL,
  `txtNumero` varchar(50) DEFAULT NULL,
  `indTipoDocumento` varchar(10) DEFAULT NULL,
  `datEmissao` date DEFAULT NULL,
  `vlrDocumento` decimal(10,2) DEFAULT NULL,
  `vlrGlosa` decimal(10,2) DEFAULT NULL,
  `vlrLiquido` decimal(10,2) DEFAULT NULL,
  `numMes` decimal(2,0) DEFAULT NULL,
  `numAno` decimal(4,0) DEFAULT NULL,
  `numParcela` decimal(3,0) DEFAULT NULL,
  `txtPassageiro` varchar(100) DEFAULT NULL,
  `txtTrecho` varchar(100) DEFAULT NULL,
  `numLote` int(11) DEFAULT NULL,
  `numRessarcimento` int(11) DEFAULT NULL,
  KEY `Index_1` (`numAno`,`numMes`,`ideCadastro`),
  KEY `Index_2` (`txtCNPJCPF`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `noticias`
--

DROP TABLE IF EXISTS `noticias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `noticias` (
  `IdNoticia` int(11) NOT NULL AUTO_INCREMENT,
  `TextoNoticia` varchar(255) DEFAULT NULL,
  `LinkNoticia` varchar(255) DEFAULT NULL,
  `DataNoticia` datetime DEFAULT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdNoticia`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `notificacoes`
--

DROP TABLE IF EXISTS `notificacoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `notificacoes` (
  `idDenuncia` int(11) NOT NULL,
  `UserName` varchar(255) NOT NULL,
  PRIMARY KEY (`idDenuncia`,`UserName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `parametros`
--

DROP TABLE IF EXISTS `parametros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parametros` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `menorAno` decimal(4,0) DEFAULT NULL,
  `ultima_atualizacao` datetime DEFAULT NULL,
  `menorAnoSenadores` decimal(4,0) DEFAULT NULL,
  `ultimaAtualizacaoSenadores` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `parlamentares`
--

DROP TABLE IF EXISTS `parlamentares`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parlamentares` (
  `ideCadastro` bigint(20) unsigned NOT NULL,
  `txNomeParlamentar` varchar(100) NOT NULL,
  UNIQUE KEY `idParlamentar` (`ideCadastro`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `partidos`
--

DROP TABLE IF EXISTS `partidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `partidos` (
  `sgPartido` varchar(10) NOT NULL,
  PRIMARY KEY (`sgPartido`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `partidos_senadores`
--

DROP TABLE IF EXISTS `partidos_senadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `partidos_senadores` (
  `SiglaPartido` varchar(45) NOT NULL,
  PRIMARY KEY (`SiglaPartido`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `receitas_eleicao`
--

DROP TABLE IF EXISTS `receitas_eleicao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `receitas_eleicao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `anoEleicao` decimal(4,0) DEFAULT NULL,
  `nomeCandidato` varchar(255) DEFAULT NULL,
  `cpfCandidato` varchar(11) DEFAULT NULL,
  `cargo` varchar(50) DEFAULT NULL,
  `numDocumento` varchar(50) DEFAULT NULL,
  `cnpjCpfDoador` varchar(14) DEFAULT NULL,
  `raizCnpjCpfDoador` varchar(11) DEFAULT NULL,
  `dataReceita` date DEFAULT NULL,
  `valorReceita` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Index_1` (`raizCnpjCpfDoador`)
) ENGINE=MyISAM AUTO_INCREMENT=426557 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `Rolename` varchar(255) NOT NULL,
  `ApplicationName` varchar(255) NOT NULL,
  PRIMARY KEY (`Rolename`,`ApplicationName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `senador_usuario`
--

DROP TABLE IF EXISTS `senador_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `senador_usuario` (
  `UserName` varchar(255) NOT NULL,
  `CodigoParlamentar` int(11) NOT NULL,
  PRIMARY KEY (`UserName`,`CodigoParlamentar`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `senadores`
--

DROP TABLE IF EXISTS `senadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `senadores` (
  `CodigoParlamentar` int(11) NOT NULL,
  `NomeParlamentar` varchar(255) DEFAULT NULL,
  `Url` varchar(255) DEFAULT NULL,
  `Foto` varchar(255) DEFAULT NULL,
  `SiglaPartido` varchar(45) DEFAULT NULL,
  `SiglaUf` varchar(2) DEFAULT NULL,
  `Ativo` char(1) DEFAULT NULL,
  `MandatoAtual` decimal(6,0) DEFAULT NULL,
  `DespesasMandato` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`CodigoParlamentar`),
  KEY `Index_1` (`SiglaPartido`),
  KEY `Index_2` (`SiglaUf`),
  KEY `Index_3` (`Ativo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user_recover`
--

DROP TABLE IF EXISTS `user_recover`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_recover` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `chave` varchar(30) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `data` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `PKID` varchar(36) COLLATE latin1_general_ci NOT NULL DEFAULT '',
  `Username` varchar(255) COLLATE latin1_general_ci NOT NULL DEFAULT '',
  `ApplicationName` varchar(100) COLLATE latin1_general_ci NOT NULL DEFAULT '',
  `Email` varchar(100) COLLATE latin1_general_ci NOT NULL DEFAULT '',
  `Comment` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `Password` varchar(128) COLLATE latin1_general_ci NOT NULL DEFAULT '',
  `PasswordQuestion` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `PasswordAnswer` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `IsApproved` tinyint(1) DEFAULT NULL,
  `LastActivityDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `LastPasswordChangedDate` datetime DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `IsOnLine` tinyint(1) DEFAULT NULL,
  `IsLockedOut` tinyint(1) DEFAULT NULL,
  `LastLockedOutDate` datetime DEFAULT NULL,
  `FailedPasswordAttemptCount` int(11) DEFAULT NULL,
  `FailedPasswordAttemptWindowStart` datetime DEFAULT NULL,
  `FailedPasswordAnswerAttemptCount` int(11) DEFAULT NULL,
  `FailedPasswordAnswerAttemptWindowStart` datetime DEFAULT NULL,
  PRIMARY KEY (`PKID`),
  KEY `ix1_users` (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users_detail`
--

DROP TABLE IF EXISTS `users_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users_detail` (
  `Username` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `uf` char(2) COLLATE latin1_general_ci NOT NULL,
  `cidade` varchar(256) COLLATE latin1_general_ci NOT NULL,
  `mostra_email` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usersinroles`
--

DROP TABLE IF EXISTS `usersinroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usersinroles` (
  `Username` varchar(255) NOT NULL,
  `Rolename` varchar(255) NOT NULL,
  `ApplicationName` varchar(255) NOT NULL,
  KEY `Username` (`Username`,`Rolename`,`ApplicationName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-11 20:15:23
