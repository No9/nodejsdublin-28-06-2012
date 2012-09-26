USE [master]
GO

/****** Object:  Database [nodejstest]    Script Date: 06/26/2012 00:04:30 ******/
CREATE DATABASE [nodejstest] ON  PRIMARY 
( NAME = N'nodejstest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\nodejstest.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'nodejstest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\nodejstest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [nodejstest] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [nodejstest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [nodejstest] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [nodejstest] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [nodejstest] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [nodejstest] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [nodejstest] SET ARITHABORT OFF 
GO

ALTER DATABASE [nodejstest] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [nodejstest] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [nodejstest] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [nodejstest] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [nodejstest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [nodejstest] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [nodejstest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [nodejstest] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [nodejstest] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [nodejstest] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [nodejstest] SET  DISABLE_BROKER 
GO

ALTER DATABASE [nodejstest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [nodejstest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [nodejstest] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [nodejstest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [nodejstest] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [nodejstest] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [nodejstest] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [nodejstest] SET  READ_WRITE 
GO

ALTER DATABASE [nodejstest] SET RECOVERY FULL 
GO

ALTER DATABASE [nodejstest] SET  MULTI_USER 
GO

ALTER DATABASE [nodejstest] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [nodejstest] SET DB_CHAINING OFF 
GO

