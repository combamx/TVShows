USE [TVShowData]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16/11/2024 16:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[TvShows]    Script Date: 16/11/2024 16:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TvShows]') AND type in (N'U'))
DROP TABLE [dbo].[TvShows]
GO
USE [master]
GO
/****** Object:  Database [TVShowData]    Script Date: 16/11/2024 16:50:47 ******/
DROP DATABASE [TVShowData]
GO
/****** Object:  Database [TVShowData]    Script Date: 16/11/2024 16:50:47 ******/
CREATE DATABASE [TVShowData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TVShowData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TVShowData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TVShowData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TVShowData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TVShowData] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TVShowData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TVShowData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TVShowData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TVShowData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TVShowData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TVShowData] SET ARITHABORT OFF 
GO
ALTER DATABASE [TVShowData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TVShowData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TVShowData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TVShowData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TVShowData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TVShowData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TVShowData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TVShowData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TVShowData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TVShowData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TVShowData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TVShowData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TVShowData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TVShowData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TVShowData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TVShowData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TVShowData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TVShowData] SET RECOVERY FULL 
GO
ALTER DATABASE [TVShowData] SET  MULTI_USER 
GO
ALTER DATABASE [TVShowData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TVShowData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TVShowData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TVShowData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TVShowData] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TVShowData] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TVShowData', N'ON'
GO
ALTER DATABASE [TVShowData] SET QUERY_STORE = ON
GO
ALTER DATABASE [TVShowData] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TVShowData]
GO
/****** Object:  Table [dbo].[TvShows]    Script Date: 16/11/2024 16:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TvShows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Favorite] [bit] NOT NULL,
	[Content] [nvarchar](255) NOT NULL,
	[Format] [nvarchar](255) NOT NULL,
	[Episodes] [nvarchar](255) NOT NULL,
	[Duration] [nvarchar](50) NOT NULL,
	[Scenarios] [nvarchar](255) NOT NULL,
	[Classification] [nvarchar](50) NOT NULL,
	[Image] [varchar](800) NULL,
 CONSTRAINT [PK__TvShows__3214EC0763762B10] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16/11/2024 16:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TvShows] ON 
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (1, N'Breaking Bad', 1, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various interior and exterior settings', N'R', N'https://hipermediaciones.com/wp-content/uploads/2013/10/bbs5-1600x1200-pre-e.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (2, N'Game of Thrones', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'60 minutes or longer', N'Various interior and exterior settings', N'18A', N'https://t.ctcdn.com.br/wQkKKDBe1HpwEmbJ7ADMfLznS_Q=/990x557/smart/i350335.jpeg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (3, N'The Office', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Office interior settings', N'PG', N'https://images.reporteindigo.com/wp-content/uploads/2023/09/the-office-reboot.png')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (4, N'Friends', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Apartment interior settings', N'PG', N'https://beam-images.warnermediacdn.com/BEAM_LWM_DELIVERABLES/52dae4c7-2ab1-4bb9-ab1c-8100fd54e2f9/24ec1000-8a0f-4ba4-be79-8c7a5eb288ee?host=wbd-images.prod-vod.h264.io&partner=beamcom&w=500')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (5, N'Stranger Things', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various interior and exterior settings', N'14A', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQWN8AkViFHvaTTH0C7fRRJCnLiYL3CtpbTdw&s')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (6, N'The Mandalorian', 1, N'Fiction', N'Series', N'Narrative units with continuity', N'30-40 minutes', N'Various interior and exterior settings', N'PG', N'https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/4826879538A92B52B2B316E2E9D5A1BEC5C774C094FF9F96E3265E0D4220E3E6/scale?width=1200&aspectRatio=1.78&format=webp')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (7, N'Black Mirror', 0, N'Fiction', N'Series', N'Standalone narrative units', N'50-60 minutes', N'Various settings, futuristic and dystopian', N'18A', N'https://media.gq.com.mx/photos/66f06cc998463deeaf2a4854/16:9/w_2992,h_1683,c_limit/BM.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (8, N'Rick and Morty', 1, N'Animation', N'Animation Series', N'Individual narrative units', N'20-30 minutes', N'Various sci-fi settings', N'R', N'https://wallpapers.com/images/featured/imagenes-de-rick-and-morty-b3e2pq02sb2fuvy3.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (9, N'The Crown', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Historical settings, interior and exterior', N'PG', N'https://occ-0-8407-1722.1.nflxso.net/dnm/api/v6/E8vDc_W8CLv7-yMQu8KMEC7Rrr8/AAAABRa2Ojolth_4mw7fNztaPZJHe6V0oyMCD-NF0By0ddFyNQRb7NdWoHl3BPwSXVS3dbgG-jeiIaKzqAxqcpR_BGOHghInV3iHy6pY.jpg?r=f43')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (10, N'Brooklyn Nine-Nine', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Police station interior settings', N'PG', N'https://media.revistagq.com/photos/5d47d3043b83c000083d3ba1/16:9/w_2560%2Cc_limit/B99%25201.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (11, N'Sherlock', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'90 minutes', N'Modern London settings', N'14A', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQB3abubwqH5tkoKV-fXq6TatvAr4r9m5j_Pg&s')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (12, N'Chernobyl', 1, N'Docudrama', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Historical settings', N'18A', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaLopBI8RHM6FiXOhepa9al9cZqwBQEDSN3g&s')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (13, N'House of Cards', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Political interior settings', N'18A', N'https://i.ytimg.com/vi/jNTgPxHKlbo/maxresdefault.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (14, N'The Simpsons', 1, N'Animation', N'Animation Series', N'Individual narrative units', N'20-30 minutes', N'Springfield settings', N'PG', N'https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/0E97E967C1744CB09006B7A86EEB05F4B070665074177C32E159BEBE22D22D7C/scale?width=1200&aspectRatio=1.78&format=webp')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (15, N'Narcos', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various settings, interior and exterior', N'18A', N'https://i.ytimg.com/vi/iiuW754iw7o/maxresdefault.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (16, N'Dexter ', 0, N'Dexter es una serie de televisión emitida originalmente por la cadena Showtime desde el 1 de octubre de 2006 hasta el 22 de septiembre de 2013.', N'Series', N'96', N'45min', N'Various interior and exterior settings', N'PG', N'https://m.media-amazon.com/images/S/pv-target-images/a4c0bd7d850e79e5856a3fc54d70290e0bf8cb94813d3d68451ea4f495e481c7._BR-6_AC_SX720_FMjpg_.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (17, N'The Big Bang Theory', 1, N'The Big Bang Theory es una serie de televisión en inglés que cuenta con 12 temporadas y 279 episodios.', N'Comedy', N'279', N'60 min', N'Various interior and exterior settings', N'18A', N'https://m.media-amazon.com/images/S/pv-target-images/94a2f334c2888fb83eb90e9862c6b3f821a3b953bba0d7fae79a1289d1c474cf.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (18, N'Dr. House', 1, N'En el Princenton Plainsboro de Nueva Jersey, el Dr. Gregory House, un singular genio de la medicina, se encarga de resolver casos como lo haría Sherlock Holmes', N'Drama', N'177', N'60 min', N'Various interior and exterior settings', N'18A', N'https://juliocesarsalinas.mx/data/files/01house..jpg')
GO
SET IDENTITY_INSERT [dbo].[TvShows] OFF
GO
USE [master]
GO
ALTER DATABASE [TVShowData] SET  READ_WRITE 
GO
