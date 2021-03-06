USE [master]
GO
/****** Object:  Database [College]    Script Date: 4/4/2021 11:42:33 PM ******/
CREATE DATABASE [College]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'College', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\College.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'College_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\College_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [College] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [College].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [College] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [College] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [College] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [College] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [College] SET ARITHABORT OFF 
GO
ALTER DATABASE [College] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [College] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [College] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [College] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [College] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [College] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [College] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [College] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [College] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [College] SET  DISABLE_BROKER 
GO
ALTER DATABASE [College] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [College] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [College] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [College] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [College] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [College] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [College] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [College] SET RECOVERY FULL 
GO
ALTER DATABASE [College] SET  MULTI_USER 
GO
ALTER DATABASE [College] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [College] SET DB_CHAINING OFF 
GO
ALTER DATABASE [College] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [College] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [College] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'College', N'ON'
GO
ALTER DATABASE [College] SET QUERY_STORE = OFF
GO
USE [College]
GO
/****** Object:  Table [dbo].[College]    Script Date: 4/4/2021 11:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[College](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CollegeName] [varchar](200) NULL,
	[Email] [varchar](200) NULL,
	[PhoneNo] [varchar](200) NULL,
	[Address] [varchar](200) NULL,
	[StartDate] [datetime] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/4/2021 11:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](100) NULL,
	[Description] [varchar](500) NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAuthor]    Script Date: 4/4/2021 11:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAuthor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](100) NULL,
	[AccessPages] [varchar](max) NULL,
 CONSTRAINT [PK_RoleAuthor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/4/2021 11:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](200) NULL,
	[Email] [varchar](200) NULL,
	[PhoneNo] [varchar](200) NULL,
	[Address] [varchar](500) NULL,
	[HireDate] [datetime] NULL,
	[CollegeID] [int] NULL,
	[DepartmentID] [int] NULL,
	[RoleID] [int] NULL,
	[Password] [varchar](200) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[College] ON 

INSERT [dbo].[College] ([ID], [CollegeName], [Email], [PhoneNo], [Address], [StartDate]) VALUES (1, N'Sant Josaf college', N'sant@gmail.com', N'23234', N'2334234', CAST(N'2021-03-30T00:00:00.000' AS DateTime))
INSERT [dbo].[College] ([ID], [CollegeName], [Email], [PhoneNo], [Address], [StartDate]) VALUES (2, N'Test college', N'testcollege@gmail.com', N'123456', N'test', CAST(N'2021-03-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[College] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([ID], [DepartmentName], [Description], [Status], [CreatedDate]) VALUES (1, N'HR', N'Human Resource', 1, CAST(N'2021-03-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Department] ([ID], [DepartmentName], [Description], [Status], [CreatedDate]) VALUES (2, N'Admin', N'Administration', 1, CAST(N'2021-03-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[RoleAuthor] ON 

INSERT [dbo].[RoleAuthor] ([Id], [RoleName], [AccessPages]) VALUES (1, N'Admin', N'Home, College, Department, RoleAuthorization, User')
INSERT [dbo].[RoleAuthor] ([Id], [RoleName], [AccessPages]) VALUES (2, N'User', N',Home,College,Department')
SET IDENTITY_INSERT [dbo].[RoleAuthor] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Email], [PhoneNo], [Address], [HireDate], [CollegeID], [DepartmentID], [RoleID], [Password]) VALUES (1, N'Admin', N'admin@gmail.com', N'23324453453', N'Test', CAST(N'2021-03-30T00:00:00.000' AS DateTime), 0, 0, 1, N'123')
INSERT [dbo].[User] ([ID], [UserName], [Email], [PhoneNo], [Address], [HireDate], [CollegeID], [DepartmentID], [RoleID], [Password]) VALUES (2, N'Test', N'test@gmail.com', N'435353', N'asfd', CAST(N'2021-04-01T00:00:00.000' AS DateTime), 1, 1, 2, N'123')
INSERT [dbo].[User] ([ID], [UserName], [Email], [PhoneNo], [Address], [HireDate], [CollegeID], [DepartmentID], [RoleID], [Password]) VALUES (4, N'tet', N'df@gmail.com', N'122', N'11', CAST(N'2021-03-29T00:00:00.000' AS DateTime), 2, 1, 2, N'1234')
SET IDENTITY_INSERT [dbo].[User] OFF
USE [master]
GO
ALTER DATABASE [College] SET  READ_WRITE 
GO
