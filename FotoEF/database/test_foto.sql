USE [master]
GO
/****** Object:  Database [test_foto]    Script Date: 2018-02-03 15:19:50 ******/
CREATE DATABASE [test_foto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test_foto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\test_foto.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'test_foto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\test_foto_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [test_foto] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test_foto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test_foto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test_foto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test_foto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test_foto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test_foto] SET ARITHABORT OFF 
GO
ALTER DATABASE [test_foto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [test_foto] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [test_foto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test_foto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test_foto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test_foto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test_foto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test_foto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test_foto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test_foto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test_foto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [test_foto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test_foto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test_foto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test_foto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test_foto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test_foto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test_foto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test_foto] SET RECOVERY FULL 
GO
ALTER DATABASE [test_foto] SET  MULTI_USER 
GO
ALTER DATABASE [test_foto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test_foto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test_foto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test_foto] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'test_foto', N'ON'
GO
USE [test_foto]
GO
/****** Object:  Table [dbo].[Table_folders]    Script Date: 2018-02-03 15:19:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_folders](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[description] [nvarchar](1000) NULL,
	[icon] [nvarchar](200) NULL,
 CONSTRAINT [PK_Table_folders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table_foto_files]    Script Date: 2018-02-03 15:19:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_foto_files](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[description] [nvarchar](1000) NULL,
	[id_folder] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Table_foto_files] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Table_folders] ON 

INSERT [dbo].[Table_folders] ([id], [name], [description], [icon]) VALUES (CAST(1 AS Numeric(18, 0)), N'folder1', N'opis 33', NULL)
INSERT [dbo].[Table_folders] ([id], [name], [description], [icon]) VALUES (CAST(2 AS Numeric(18, 0)), N'folder2', N'opis 222 test', NULL)
INSERT [dbo].[Table_folders] ([id], [name], [description], [icon]) VALUES (CAST(7 AS Numeric(18, 0)), N'folder3', N'opis test5', N'')
INSERT [dbo].[Table_folders] ([id], [name], [description], [icon]) VALUES (CAST(9 AS Numeric(18, 0)), N'test folder4', N'opis33', N'123')
SET IDENTITY_INSERT [dbo].[Table_folders] OFF
SET IDENTITY_INSERT [dbo].[Table_foto_files] ON 

INSERT [dbo].[Table_foto_files] ([id], [name], [description], [id_folder]) VALUES (CAST(1 AS Numeric(18, 0)), N'foto1', N'opis 111', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Table_foto_files] ([id], [name], [description], [id_folder]) VALUES (CAST(2 AS Numeric(18, 0)), N'foto2', N'opis 3333', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Table_foto_files] ([id], [name], [description], [id_folder]) VALUES (CAST(3 AS Numeric(18, 0)), N'foto2', N'opis 22222', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Table_foto_files] ([id], [name], [description], [id_folder]) VALUES (CAST(5 AS Numeric(18, 0)), N'foto3', N'opis 1111', CAST(2 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Table_foto_files] OFF
ALTER TABLE [dbo].[Table_foto_files]  WITH CHECK ADD  CONSTRAINT [FK_Table_foto_files_Table_folders] FOREIGN KEY([id_folder])
REFERENCES [dbo].[Table_folders] ([id])
GO
ALTER TABLE [dbo].[Table_foto_files] CHECK CONSTRAINT [FK_Table_foto_files_Table_folders]
GO
USE [master]
GO
ALTER DATABASE [test_foto] SET  READ_WRITE 
GO
