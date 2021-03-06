USE [master]
GO
/****** Object:  Database [BookStoreDB]    Script Date: 02/05/2011 20:01:23 ******/
CREATE DATABASE [BookStoreDB] ON  PRIMARY 
( NAME = N'BookStoreDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BookStoreDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookStoreDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BookStoreDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookStoreDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStoreDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BookStoreDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BookStoreDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BookStoreDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BookStoreDB] SET ARITHABORT OFF
GO
ALTER DATABASE [BookStoreDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BookStoreDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BookStoreDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BookStoreDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BookStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BookStoreDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BookStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BookStoreDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BookStoreDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BookStoreDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BookStoreDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [BookStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BookStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BookStoreDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BookStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BookStoreDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BookStoreDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BookStoreDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BookStoreDB] SET  READ_WRITE
GO
ALTER DATABASE [BookStoreDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [BookStoreDB] SET  MULTI_USER
GO
ALTER DATABASE [BookStoreDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BookStoreDB] SET DB_CHAINING OFF
GO
USE [BookStoreDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[Decription] [ntext] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pulishers]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pulishers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PulisherName] [nvarchar](255) NOT NULL,
	[Addres] [ntext] NULL,
	[Phone] [char](11) NULL,
	[WebAddres] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pulishers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Authers]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Authers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Bio] [text] NULL,
 CONSTRAINT [PK_Authers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [float] NOT NULL,
	[RecordDate] [date] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeesName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Pwd] [ntext] NOT NULL,
	[RevordDate] [date] NULL,
	[LoginLastDate] [date] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coutomers]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coutomers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CoutomerName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Pwd] [ntext] NOT NULL,
	[RevordDate] [date] NOT NULL,
	[LoginLastDate] [date] NULL,
 CONSTRAINT [PK_Coutomers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoustomerToOrder]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoustomerToOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CoutomerID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK_CoustomerToOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](50) NOT NULL,
	[AutherID] [int] NULL,
	[PulisherID] [int] NULL,
	[Prices] [float] NOT NULL,
	[Description] [ntext] NULL,
	[PublisDate] [date] NULL,
	[InStok] [bit] NOT NULL,
	[ISBN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderToBook]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderToBook](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
 CONSTRAINT [PK_OrderToBook] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookToCategory]    Script Date: 02/05/2011 20:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookToCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_BookToCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_CoustomerToOrder_Coutomers]    Script Date: 02/05/2011 20:01:28 ******/
ALTER TABLE [dbo].[CoustomerToOrder]  WITH CHECK ADD  CONSTRAINT [FK_CoustomerToOrder_Coutomers] FOREIGN KEY([CoutomerID])
REFERENCES [dbo].[Coutomers] ([ID])
GO
ALTER TABLE [dbo].[CoustomerToOrder] CHECK CONSTRAINT [FK_CoustomerToOrder_Coutomers]
GO
/****** Object:  ForeignKey [FK_CoustomerToOrder_Orders]    Script Date: 02/05/2011 20:01:28 ******/
ALTER TABLE [dbo].[CoustomerToOrder]  WITH CHECK ADD  CONSTRAINT [FK_CoustomerToOrder_Orders] FOREIGN KEY([CoutomerID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[CoustomerToOrder] CHECK CONSTRAINT [FK_CoustomerToOrder_Orders]
GO
/****** Object:  ForeignKey [FK_Books_Authers]    Script Date: 02/05/2011 20:01:28 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authers] FOREIGN KEY([AutherID])
REFERENCES [dbo].[Authers] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authers]
GO
/****** Object:  ForeignKey [FK_Books_Pulishers]    Script Date: 02/05/2011 20:01:28 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Pulishers] FOREIGN KEY([PulisherID])
REFERENCES [dbo].[Pulishers] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Pulishers]
GO
/****** Object:  ForeignKey [FK_OrderToBook_Books]    Script Date: 02/05/2011 20:01:28 ******/
ALTER TABLE [dbo].[OrderToBook]  WITH CHECK ADD  CONSTRAINT [FK_OrderToBook_Books] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Books] ([ID])
GO
ALTER TABLE [dbo].[OrderToBook] CHECK CONSTRAINT [FK_OrderToBook_Books]
GO
/****** Object:  ForeignKey [FK_OrderToBook_Orders]    Script Date: 02/05/2011 20:01:28 ******/
ALTER TABLE [dbo].[OrderToBook]  WITH CHECK ADD  CONSTRAINT [FK_OrderToBook_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[OrderToBook] CHECK CONSTRAINT [FK_OrderToBook_Orders]
GO
/****** Object:  ForeignKey [FK_BookToCategory_Books]    Script Date: 02/05/2011 20:01:28 ******/
ALTER TABLE [dbo].[BookToCategory]  WITH CHECK ADD  CONSTRAINT [FK_BookToCategory_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([ID])
GO
ALTER TABLE [dbo].[BookToCategory] CHECK CONSTRAINT [FK_BookToCategory_Books]
GO
/****** Object:  ForeignKey [FK_BookToCategory_Categories]    Script Date: 02/05/2011 20:01:28 ******/
ALTER TABLE [dbo].[BookToCategory]  WITH CHECK ADD  CONSTRAINT [FK_BookToCategory_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[BookToCategory] CHECK CONSTRAINT [FK_BookToCategory_Categories]
GO
