USE [master]
GO
/****** Object:  Database [kurs_rab]    Script Date: 17.03.2022 22:46:01 ******/
CREATE DATABASE [kurs_rab]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kurs_rab', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\kurs_rab.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kurs_rab_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\kurs_rab_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [kurs_rab] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kurs_rab].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kurs_rab] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kurs_rab] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kurs_rab] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kurs_rab] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kurs_rab] SET ARITHABORT OFF 
GO
ALTER DATABASE [kurs_rab] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kurs_rab] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kurs_rab] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kurs_rab] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kurs_rab] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kurs_rab] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kurs_rab] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kurs_rab] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kurs_rab] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kurs_rab] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kurs_rab] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kurs_rab] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kurs_rab] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kurs_rab] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kurs_rab] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kurs_rab] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kurs_rab] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kurs_rab] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [kurs_rab] SET  MULTI_USER 
GO
ALTER DATABASE [kurs_rab] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kurs_rab] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kurs_rab] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kurs_rab] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kurs_rab] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [kurs_rab] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [kurs_rab] SET QUERY_STORE = OFF
GO
USE [kurs_rab]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Login] [varchar](50) NOT NULL,
	[Pass] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заказы]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказы](
	[id_заказа] [int] IDENTITY(1,1) NOT NULL,
	[id_работника] [int] NOT NULL,
	[id_поставщика] [int] NOT NULL,
	[Статус] [varchar](50) NULL,
	[Цена] [decimal](12, 2) NULL,
	[Описание] [varchar](255) NULL,
 CONSTRAINT [PK_Заказы] PRIMARY KEY CLUSTERED 
(
	[id_заказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Покупатель]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Покупатель](
	[id_покупателя] [int] IDENTITY(1,1) NOT NULL,
	[Имя] [varchar](50) NULL,
	[Отчество] [varchar](50) NULL,
	[Фамилия] [varchar](50) NULL,
	[Телефон] [varchar](12) NULL,
 CONSTRAINT [PK_Покупатель] PRIMARY KEY CLUSTERED 
(
	[id_покупателя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Покупки]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Покупки](
	[id_покупки] [int] IDENTITY(1,1) NOT NULL,
	[id_покупателя] [int] NOT NULL,
	[id_работника] [int] NOT NULL,
	[Цена] [decimal](12, 2) NULL,
 CONSTRAINT [PK_Покупки] PRIMARY KEY CLUSTERED 
(
	[id_покупки] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ПокупкиТоваров]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ПокупкиТоваров](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_покупки] [int] NOT NULL,
	[id_товара] [int] NOT NULL,
	[Количество] [int] NULL,
 CONSTRAINT [PK_ПокупкиТоваров] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Поставщики]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Поставщики](
	[id_поставщика] [int] IDENTITY(1,1) NOT NULL,
	[Имя] [varchar](50) NULL,
	[Отчество] [varchar](50) NULL,
	[Фамилия] [varchar](50) NULL,
	[Фирма] [varchar](50) NULL,
	[Телефон] [varchar](12) NULL,
 CONSTRAINT [PK_Поставщики] PRIMARY KEY CLUSTERED 
(
	[id_поставщика] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Работники]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Работники](
	[id_работника] [int] IDENTITY(1,1) NOT NULL,
	[Имя] [varchar](50) NULL,
	[Отчество] [varchar](50) NULL,
	[Фамилия] [varchar](50) NULL,
	[Должность] [varchar](50) NULL,
 CONSTRAINT [PK_Работники] PRIMARY KEY CLUSTERED 
(
	[id_работника] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товары]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товары](
	[id_товара] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](50) NULL,
	[Количество] [int] NULL,
	[Цена] [decimal](12, 2) NULL,
 CONSTRAINT [PK_Товары] PRIMARY KEY CLUSTERED 
(
	[id_товара] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТоварыЗаказов]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТоварыЗаказов](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_заказа] [int] NOT NULL,
	[id_товара] [int] NOT NULL,
	[Количество] [int] NULL,
 CONSTRAINT [PK_ТоварыЗаказов] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Удаленные_товары]    Script Date: 17.03.2022 22:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Удаленные_товары](
	[id_товара] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](50) NULL,
	[Количество] [int] NULL,
	[Цена] [decimal](12, 2) NULL,
 CONSTRAINT [PK_Удаленные_товары] PRIMARY KEY CLUSTERED 
(
	[id_товара] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_Поставщики] FOREIGN KEY([id_поставщика])
REFERENCES [dbo].[Поставщики] ([id_поставщика])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_Поставщики]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_Работники] FOREIGN KEY([id_работника])
REFERENCES [dbo].[Работники] ([id_работника])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_Работники]
GO
ALTER TABLE [dbo].[Покупки]  WITH CHECK ADD  CONSTRAINT [FK_Покупки_Покупатель] FOREIGN KEY([id_покупателя])
REFERENCES [dbo].[Покупатель] ([id_покупателя])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Покупки] CHECK CONSTRAINT [FK_Покупки_Покупатель]
GO
ALTER TABLE [dbo].[Покупки]  WITH CHECK ADD  CONSTRAINT [FK_Покупки_Работники] FOREIGN KEY([id_работника])
REFERENCES [dbo].[Работники] ([id_работника])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Покупки] CHECK CONSTRAINT [FK_Покупки_Работники]
GO
ALTER TABLE [dbo].[ПокупкиТоваров]  WITH CHECK ADD  CONSTRAINT [FK_ПокупкиТоваров_Покупки] FOREIGN KEY([id_покупки])
REFERENCES [dbo].[Покупки] ([id_покупки])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ПокупкиТоваров] CHECK CONSTRAINT [FK_ПокупкиТоваров_Покупки]
GO
ALTER TABLE [dbo].[ПокупкиТоваров]  WITH CHECK ADD  CONSTRAINT [FK_ПокупкиТоваров_Товары] FOREIGN KEY([id_товара])
REFERENCES [dbo].[Товары] ([id_товара])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ПокупкиТоваров] CHECK CONSTRAINT [FK_ПокупкиТоваров_Товары]
GO
ALTER TABLE [dbo].[ТоварыЗаказов]  WITH CHECK ADD  CONSTRAINT [FK_ТоварыЗаказов_Заказы] FOREIGN KEY([id_заказа])
REFERENCES [dbo].[Заказы] ([id_заказа])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ТоварыЗаказов] CHECK CONSTRAINT [FK_ТоварыЗаказов_Заказы]
GO
ALTER TABLE [dbo].[ТоварыЗаказов]  WITH CHECK ADD  CONSTRAINT [FK_ТоварыЗаказов_Товары] FOREIGN KEY([id_товара])
REFERENCES [dbo].[Товары] ([id_товара])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ТоварыЗаказов] CHECK CONSTRAINT [FK_ТоварыЗаказов_Товары]
GO
USE [master]
GO
ALTER DATABASE [kurs_rab] SET  READ_WRITE 
GO
