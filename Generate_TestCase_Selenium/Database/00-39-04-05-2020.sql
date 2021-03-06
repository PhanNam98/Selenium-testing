USE [master]
GO
/****** Object:  Database [ElementDB]    Script Date: 04/04/2020 00:39:48 ******/
CREATE DATABASE [ElementDB] ON  PRIMARY 
( NAME = N'ElementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ElementDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ElementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ElementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ElementDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ElementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ElementDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ElementDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ElementDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ElementDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ElementDB] SET ARITHABORT OFF
GO
ALTER DATABASE [ElementDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ElementDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ElementDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ElementDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ElementDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ElementDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ElementDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ElementDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ElementDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ElementDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ElementDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [ElementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ElementDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ElementDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ElementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ElementDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ElementDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ElementDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ElementDB] SET  READ_WRITE
GO
ALTER DATABASE [ElementDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ElementDB] SET  MULTI_USER
GO
ALTER DATABASE [ElementDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ElementDB] SET DB_CHAINING OFF
GO
USE [ElementDB]
GO
/****** Object:  Table [dbo].[Redirect_url]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Redirect_url](
	[id_testcase] [nvarchar](100) NOT NULL,
	[current_url] [nvarchar](max) NOT NULL,
	[redirect_url_test] [nvarchar](max) NULL,
 CONSTRAINT [PK_Redirect_url] PRIMARY KEY CLUSTERED 
(
	[id_testcase] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Url]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Url](
	[id_url] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[url] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Url] PRIMARY KEY CLUSTERED 
(
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Url] ON
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (3, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (4, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (5, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (6, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (7, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (8, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (9, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (10, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (11, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (12, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (13, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (14, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (15, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (16, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (17, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (18, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (19, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (20, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (21, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (22, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (23, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (24, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (25, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (26, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (27, N'facebook.com/', N'https://facebook.com/')
INSERT [dbo].[Url] ([id_url], [name], [url]) VALUES (28, N'facebook.com/', N'https://facebook.com/')
SET IDENTITY_INSERT [dbo].[Url] OFF
/****** Object:  Table [dbo].[Test_case]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_case](
	[id_testcase] [nvarchar](100) NOT NULL,
	[id_url] [int] NOT NULL,
	[result] [int] NULL,
	[is_test] [bit] NULL,
 CONSTRAINT [PK_Test_case_1] PRIMARY KEY CLUSTERED 
(
	[id_testcase] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Select_tag]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Select_tag](
	[id_select] [nvarchar](50) NOT NULL,
	[id_form] [nvarchar](50) NULL,
	[id_url] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[xpath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Select_tag] PRIMARY KEY CLUSTERED 
(
	[id_select] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Element]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Element](
	[id_element] [nvarchar](100) NOT NULL,
	[id_url] [int] NOT NULL,
	[name] [nvarchar](100) NULL,
	[class_name] [nvarchar](100) NULL,
	[tag_name] [nvarchar](20) NOT NULL,
	[type] [nvarchar](20) NULL,
	[value] [nvarchar](max) NULL,
	[href] [nvarchar](max) NULL,
	[title] [nvarchar](1000) NULL,
	[id_form] [nvarchar](100) NULL,
	[minlength] [float] NULL,
	[maxlength] [float] NULL,
	[required] [bit] NULL,
	[read_only] [bit] NULL,
	[max_value] [nvarchar](100) NULL,
	[min_value] [nvarchar](100) NULL,
	[multiple] [bit] NULL,
	[xpath] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Element] PRIMARY KEY CLUSTERED 
(
	[id_element] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a1', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/', N'Vào Trang chủ Facebook', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/h1[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a1', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/', N'Vào Trang chủ Facebook', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/h1[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a10', 27, N'', N'_sv4', N'a', N'', NULL, N'https://th-th.facebook.com/', N'Thai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[7]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a10', 28, N'', N'_sv4', N'a', N'', NULL, N'https://th-th.facebook.com/', N'Thai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[7]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a11', 27, N'', N'_sv4', N'a', N'', NULL, N'https://es-la.facebook.com/', N'Spanish', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[8]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a11', 28, N'', N'_sv4', N'a', N'', NULL, N'https://es-la.facebook.com/', N'Spanish', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[8]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a12', 27, N'', N'_sv4', N'a', N'', NULL, N'https://pt-br.facebook.com/', N'Portuguese (Brazil)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[9]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a12', 28, N'', N'_sv4', N'a', N'', NULL, N'https://pt-br.facebook.com/', N'Portuguese (Brazil)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[9]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a13', 27, N'', N'_sv4', N'a', N'', NULL, N'https://de-de.facebook.com/', N'German', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[10]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a13', 28, N'', N'_sv4', N'a', N'', NULL, N'https://de-de.facebook.com/', N'German', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[10]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a14', 27, N'', N'_sv4', N'a', N'', NULL, N'https://it-it.facebook.com/', N'Italian', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[11]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a14', 28, N'', N'_sv4', N'a', N'', NULL, N'https://it-it.facebook.com/', N'Italian', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[11]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a15', 27, N'', N'_42ft _4jy0 _517i _517h _51sy', N'a', N'', NULL, N'https://www.facebook.com/#', N'Hiển thị thêm ngôn ngữ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[12]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a15', 28, N'', N'_42ft _4jy0 _517i _517h _51sy', N'a', N'', NULL, N'https://www.facebook.com/#', N'Hiển thị thêm ngôn ngữ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[12]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a16', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/r.php', N'Đăng ký Facebook', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a16', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/r.php', N'Đăng ký Facebook', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a17', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/login/', N'Đăng nhập Facebook', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a17', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/login/', N'Đăng nhập Facebook', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a18', 27, N'', N'', N'a', N'', NULL, N'https://messenger.com/', N'Xem Messenger.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[3]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a18', 28, N'', N'', N'a', N'', NULL, N'https://messenger.com/', N'Xem Messenger.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[3]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a19', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/lite/', N'Facebook Lite dành cho Android.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[4]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a19', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/lite/', N'Facebook Lite dành cho Android.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[4]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a2', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/recover/initiate?lwv=110&ars=royal_blue_bar', N'', N'login_form', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/table[1]/tbody[1]/tr[3]/td[2]/div[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a2', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/recover/initiate?lwv=110&ars=royal_blue_bar', N'', N'login_form', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/table[1]/tbody[1]/tr[3]/td[2]/div[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a20', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/watch/', N'Lướt xem video của chúng tôi trên tab Watch.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[5]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a20', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/watch/', N'Lướt xem video của chúng tôi trên tab Watch.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[5]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a21', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/directory/people/', N'Lướt xem thư mục con người của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[6]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a21', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/directory/people/', N'Lướt xem thư mục con người của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[6]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a22', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/directory/pages/', N'Lướt xem thư mục trang của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[7]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a22', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/directory/pages/', N'Lướt xem thư mục trang của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[7]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a23', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/pages/category/', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[8]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a23', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/pages/category/', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[8]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a24', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/places/', N'Xem những địa điểm nổi tiếng trên Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[9]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a24', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/places/', N'Xem những địa điểm nổi tiếng trên Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[9]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a25', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/games/', N'Xem trò chơi trên Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[10]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a25', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/games/', N'Xem trò chơi trên Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[10]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a26', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/directory/places/', N'Lướt xem thư mục địa điểm của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[11]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a26', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/directory/places/', N'Lướt xem thư mục địa điểm của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[11]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a27', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/marketplace/', N'Mua bán trên Facebook Marketplace.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[12]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a27', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/marketplace/', N'Mua bán trên Facebook Marketplace.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[12]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a28', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/directory/groups/', N'Lướt xem danh mục nhóm.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[13]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a28', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/directory/groups/', N'Lướt xem danh mục nhóm.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[13]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a29', 27, N'', N'', N'a', N'', NULL, N'https://l.facebook.com/l.php?u=https%3A%2F%2Finstagram.com%2F&h=AT3J6YtgFAGtG8q_35TDz6mA5VH5ARBfNJ1a-63bWol13LqR8s_8wZrr89K6E9znkBheKrfDyR1YtFuS2VEjChaMYa3BWULBfdBOdoNTooVuHaK6ydvktwtJG0FZ_eQTOvMdYQNIKFOK9wHvwlY1VaO2xSmQu-6yUg', N'Hãy xem Instagram', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[14]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a29', 28, N'', N'', N'a', N'', NULL, N'https://l.facebook.com/l.php?u=https%3A%2F%2Finstagram.com%2F&h=AT0liPq9gl6YLwWm0bPOkQImKXDVoLWIDBUKNtyMtccyxT5LYAGrdFGjuMfTkQnzAKwJm6L88Myors3Xwe366ZZtrkAmf1RRjMbuuNh5T9WoyxeAWX2BikrSlO3UEjD6YarNNw5yjYig3vr0YKi6', N'Hãy xem Instagram', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[14]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a3', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/#', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a3', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/#', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a30', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/local/lists/245019872666104/', N'Lướt xem thư mục Danh sách địa phương của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[15]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a30', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/local/lists/245019872666104/', N'Lướt xem thư mục Danh sách địa phương của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[15]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a31', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/fundraisers/', N'Quyên góp cho các mục đích có ý nghĩa.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[16]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a31', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/fundraisers/', N'Quyên góp cho các mục đích có ý nghĩa.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[16]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a32', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/biz/directory/', N'Lướt xem thư mục Dịch vụ Facebook của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[17]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a32', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/biz/directory/', N'Lướt xem thư mục Dịch vụ Facebook của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[17]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a33', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/facebook', N'Đọc blog của chúng tôi, khám phá trung tâm tài nguyên và tìm cơ hội việc làm.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[18]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a33', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/facebook', N'Đọc blog của chúng tôi, khám phá trung tâm tài nguyên và tìm cơ hội việc làm.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[18]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a34', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/ad_campaign/landing.php?placement=pflo&campaign_id=402047449186&extra_1=auto', N'Quảng cáo trên Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[19]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a34', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/ad_campaign/landing.php?placement=pflo&campaign_id=402047449186&extra_1=auto', N'Quảng cáo trên Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[19]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a35', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/pages/create/?ref_type=site_footer', N'Tạo Trang', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[20]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a35', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/pages/create/?ref_type=site_footer', N'Tạo Trang', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[20]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a36', 27, N'', N'', N'a', N'', NULL, N'https://developers.facebook.com/?ref=pf', N'Phát triển trên nền tảng của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[21]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a36', 28, N'', N'', N'a', N'', NULL, N'https://developers.facebook.com/?ref=pf', N'Phát triển trên nền tảng của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[21]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a37', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/careers/?ref=pf', N'Tạo bước ngoặt mới trong sự nghiệp của bạn với công ty tuyệt vời của chúng tôi', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[22]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a37', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/careers/?ref=pf', N'Tạo bước ngoặt mới trong sự nghiệp của bạn với công ty tuyệt vời của chúng tôi', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[22]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a38', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/privacy/explanation', N'Tìm hiểu về quyền riêng tư của bạn và Facebook', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[23]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a38', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/privacy/explanation', N'Tìm hiểu về quyền riêng tư của bạn và Facebook', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[23]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a39', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/policies/cookies/', N'Tìm hiểu về cookie và Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[24]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a39', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/policies/cookies/', N'Tìm hiểu về cookie và Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[24]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a4', 27, N'', N'_8esh', N'a', N'', NULL, N'https://www.facebook.com/pages/create/?ref_type=registration_form', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a4', 28, N'', N'_8esh', N'a', N'', NULL, N'https://www.facebook.com/pages/create/?ref_type=registration_form', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a40', 27, N'', N'_41ug', N'a', N'', NULL, N'https://www.facebook.com/help/568137493302217', N'Tìm hiểu về Lựa chọn quảng cáo.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[25]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a40', 28, N'', N'_41ug', N'a', N'', NULL, N'https://www.facebook.com/help/568137493302217', N'Tìm hiểu về Lựa chọn quảng cáo.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[25]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a41', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/policies?ref=pf', N'Xem lại điều khoản và chính sách của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[26]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a41', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/policies?ref=pf', N'Xem lại điều khoản và chính sách của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[26]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a42', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/help/?ref=pf', N'Truy cập Trung tâm trợ giúp của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[27]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a42', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/help/?ref=pf', N'Truy cập Trung tâm trợ giúp của chúng tôi.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[27]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a43', 27, N'', N'accessible_elem', N'a', N'', NULL, N'https://www.facebook.com/settings', N'Xem và chỉnh sửa cài đặt Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[28]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a43', 28, N'', N'accessible_elem', N'a', N'', NULL, N'https://www.facebook.com/settings', N'Xem và chỉnh sửa cài đặt Facebook.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[28]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a44', 27, N'', N'accessible_elem', N'a', N'', NULL, N'https://www.facebook.com/allactivity?privacy_source=activity_log_top_menu', N'Xem nhật ký hoạt động', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[29]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a44', 28, N'', N'accessible_elem', N'a', N'', NULL, N'https://www.facebook.com/allactivity?privacy_source=activity_log_top_menu', N'Xem nhật ký hoạt động', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[2]/ul[1]/li[29]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a5', 27, N'', N'_sv4', N'a', N'', NULL, N'https://en-gb.facebook.com/', N'English (UK)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a5', 28, N'', N'_sv4', N'a', N'', NULL, N'https://en-gb.facebook.com/', N'English (UK)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a6', 27, N'', N'_sv4', N'a', N'', NULL, N'https://zh-tw.facebook.com/', N'Traditional Chinese (Taiwan)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[3]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a6', 28, N'', N'_sv4', N'a', N'', NULL, N'https://zh-tw.facebook.com/', N'Traditional Chinese (Taiwan)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[3]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a7', 27, N'', N'_sv4', N'a', N'', NULL, N'https://ko-kr.facebook.com/', N'Korean', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[4]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a7', 28, N'', N'_sv4', N'a', N'', NULL, N'https://ko-kr.facebook.com/', N'Korean', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[4]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a8', 27, N'', N'_sv4', N'a', N'', NULL, N'https://ja-jp.facebook.com/', N'Japanese', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[5]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a8', 28, N'', N'_sv4', N'a', N'', NULL, N'https://ja-jp.facebook.com/', N'Japanese', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[5]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a9', 27, N'', N'_sv4', N'a', N'', NULL, N'https://fr-fr.facebook.com/', N'French (France)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[6]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'a9', 28, N'', N'_sv4', N'a', N'', NULL, N'https://fr-fr.facebook.com/', N'French (France)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/ul[1]/li[6]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'birthday-help', 27, N'', N'_58ms mlm', N'a', N'', NULL, N'https://www.facebook.com/#', N'Nhấp chuột để biết thêm thông tin', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[5]/div[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'birthday-help', 28, N'', N'_58ms mlm', N'a', N'', NULL, N'https://www.facebook.com/#', N'Nhấp chuột để biết thêm thông tin', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[5]/div[2]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'cookie-use-link', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/policies/cookies/', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[8]/p[1]/a[3]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'cookie-use-link', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/policies/cookies/', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[8]/p[1]/a[3]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'day', 27, N'birthday_day', N'_5dba _8esg', N'select', N'select-one', N'1', NULL, N'Ngày', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[5]/div[2]/span[1]/span[1]/select[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'day', 28, N'birthday_day', N'_5dba _8esg', N'select', N'select-one', N'1', NULL, N'Ngày', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[5]/div[2]/span[1]/span[1]/select[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'email', 27, N'email', N'inputtext login_form_input_box', N'input', N'email', N'', NULL, N'', N'login_form', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/table[1]/tbody[1]/tr[2]/td[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'email', 28, N'email', N'inputtext login_form_input_box', N'input', N'email', N'', NULL, N'', N'login_form', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/table[1]/tbody[1]/tr[2]/td[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'gender-help', 27, N'', N'_58ms mlm', N'a', N'', NULL, N'https://www.facebook.com/#', N'Nhấp để biết thêm thông tin', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[6]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'gender-help', 28, N'', N'_58ms mlm', N'a', N'', NULL, N'https://www.facebook.com/#', N'Nhấp để biết thêm thông tin', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[6]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'month', 27, N'birthday_month', N'_5dba _8esg', N'select', N'select-one', N'4', NULL, N'Tháng', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[5]/div[2]/span[1]/span[1]/select[2]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'month', 28, N'birthday_month', N'_5dba _8esg', N'select', N'select-one', N'4', NULL, N'Tháng', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[5]/div[2]/span[1]/span[1]/select[2]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'pass', 27, N'pass', N'inputtext login_form_input_box', N'input', N'password', N'', NULL, N'', N'login_form', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/table[1]/tbody[1]/tr[2]/td[2]/input[1]')
GO
print 'Processed 100 total records'
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'pass', 28, N'pass', N'inputtext login_form_input_box', N'input', N'password', N'', NULL, N'', N'login_form', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/table[1]/tbody[1]/tr[2]/td[2]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'privacy-link', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/about/privacy/update', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[8]/p[1]/a[2]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'privacy-link', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/about/privacy/update', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[8]/p[1]/a[2]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'select0', 27, N'preferred_pronoun', N'_7-16 _5dba', N'select', N'select-one', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[7]/div[1]/select[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'select0', 28, N'preferred_pronoun', N'_7-16 _5dba', N'select', N'select-one', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[7]/div[1]/select[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'terms-link', 27, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/legal/terms/update', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[8]/p[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'terms-link', 28, N'', N'', N'a', N'', NULL, N'https://www.facebook.com/legal/terms/update', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[8]/p[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_11', 27, N'custom_gender', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[7]/div[3]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_11', 28, N'custom_gender', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[7]/div[3]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_13', 27, N'websubmit', N'_6j mvm _6wk _6wl _58mi _6o _6v', N'button', N'submit', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[9]/button[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_13', 28, N'websubmit', N'_6j mvm _6wk _6wl _58mi _6o _6v', N'button', N'submit', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[9]/button[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_15', 27, N'', N'_58my', N'a', N'', NULL, N'https://www.facebook.com/#', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[2]/div[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_15', 28, N'', N'_58my', N'a', N'', NULL, N'https://www.facebook.com/#', N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[2]/div[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_16', 27, N'', N'_6j mvm _6wk _6wl _58me _58mi _6o _6v', N'button', N'submit', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[2]/div[2]/div[1]/button[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_16', 28, N'', N'_6j mvm _6wk _6wl _58me _58mi _6o _6v', N'button', N'submit', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[2]/div[2]/div[1]/button[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_6', 27, N'sex', N'_8esa', N'input', N'radio', N'1', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[6]/span[1]/span[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_6', 28, N'sex', N'_8esa', N'input', N'radio', N'1', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[6]/span[1]/span[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_7', 27, N'sex', N'_8esa', N'input', N'radio', N'2', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[6]/span[1]/span[2]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_7', 28, N'sex', N'_8esa', N'input', N'radio', N'2', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[6]/span[1]/span[2]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_8', 27, N'sex', N'_8esa', N'input', N'radio', N'-1', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[6]/span[1]/span[3]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_8', 28, N'sex', N'_8esa', N'input', N'radio', N'-1', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[6]/span[1]/span[3]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_b', 27, N'', N'', N'input', N'submit', N'Đăng nhập', NULL, N'', N'login_form', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/table[1]/tbody[1]/tr[2]/td[3]/label[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_b', 28, N'', N'', N'input', N'submit', N'Đăng nhập', NULL, N'', N'login_form', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/table[1]/tbody[1]/tr[2]/td[3]/label[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_i', 27, N'', N'_42ft _4jy0 _55pi _2agf _4o_4 _63xb _p _4jy3 _517h _51sy', N'a', N'', NULL, N'https://www.facebook.com/#', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_i', 28, N'', N'_42ft _4jy0 _55pi _2agf _4o_4 _63xb _p _4jy3 _517h _51sy', N'a', N'', NULL, N'https://www.facebook.com/#', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_k', 27, N'', N'_42ft _4jy0 _55pi _2agf _4o_4 _3_s2 _63xb _p _4jy3 _4jy1 selected _51sy', N'a', N'', NULL, N'https://www.facebook.com/#', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_k', 28, N'', N'_42ft _4jy0 _55pi _2agf _4o_4 _3_s2 _63xb _p _4jy3 _4jy1 selected _51sy', N'a', N'', NULL, N'https://www.facebook.com/#', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/a[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_m', 27, N'lastname', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_m', 28, N'lastname', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_o', 27, N'firstname', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_o', 28, N'firstname', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_r', 27, N'reg_email__', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_r', 28, N'reg_email__', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_u', 27, N'reg_email_confirmation__', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[3]/div[1]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_u', 28, N'reg_email_confirmation__', N'inputtext _58mg _5dba _2ph-', N'input', N'text', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[3]/div[1]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_w', 27, N'reg_passwd__', N'inputtext _58mg _5dba _2ph-', N'input', N'password', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[4]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'u_0_w', 28, N'reg_passwd__', N'inputtext _58mg _5dba _2ph-', N'input', N'password', N'', NULL, N'', N'reg', NULL, NULL, NULL, NULL, N'', N'', NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[4]/div[1]/div[1]/input[1]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'year', 27, N'birthday_year', N'_5dba _8esg', N'select', N'select-one', N'1995', NULL, N'Năm', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[5]/div[2]/span[1]/span[1]/select[3]')
INSERT [dbo].[Element] ([id_element], [id_url], [name], [class_name], [tag_name], [type], [value], [href], [title], [id_form], [minlength], [maxlength], [required], [read_only], [max_value], [min_value], [multiple], [xpath]) VALUES (N'year', 28, N'birthday_year', N'_5dba _8esg', N'select', N'select-one', N'1995', NULL, N'Năm', N'reg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[5]/div[2]/span[1]/span[1]/select[3]')
/****** Object:  Table [dbo].[Button_tag]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Button_tag](
	[id_button] [nvarchar](50) NOT NULL,
	[type] [nvarchar](10) NOT NULL,
	[name] [nvarchar](50) NULL,
	[value] [nvarchar](50) NULL,
	[id_form] [nvarchar](50) NULL,
	[id_url] [int] NOT NULL,
	[xpath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Button_tag] PRIMARY KEY CLUSTERED 
(
	[id_button] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_tag]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_tag](
	[id_a_tag] [nvarchar](50) NOT NULL,
	[href] [nvarchar](max) NOT NULL,
	[id_url] [int] NOT NULL,
	[title] [nvarchar](max) NULL,
	[text_value] [nvarchar](max) NULL,
	[xpath] [nvarchar](max) NULL,
 CONSTRAINT [PK_A_tag] PRIMARY KEY CLUSTERED 
(
	[id_a_tag] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Input_elements]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input_elements](
	[id_input] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[class_name] [nvarchar](50) NULL,
	[type] [nvarchar](50) NOT NULL,
	[value] [nvarchar](50) NULL,
	[id_form] [nvarchar](50) NOT NULL,
	[minlength] [int] NULL,
	[maxlength] [int] NULL,
	[required] [bit] NULL,
	[readonly] [bit] NULL,
	[max] [real] NULL,
	[min] [real] NULL,
	[multiple] [bit] NULL,
	[xpath] [nvarchar](max) NULL,
	[id_url] [int] NOT NULL,
 CONSTRAINT [PK_Input_elements_1] PRIMARY KEY CLUSTERED 
(
	[id_input] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Form_elements]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Form_elements](
	[id_form] [nvarchar](100) NOT NULL,
	[name] [nvarchar](100) NULL,
	[id_url] [int] NOT NULL,
	[xpath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Form_elements] PRIMARY KEY CLUSTERED 
(
	[id_form] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Form_elements] ([id_form], [name], [id_url], [xpath]) VALUES (N'login_form', N'', 27, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]')
INSERT [dbo].[Form_elements] ([id_form], [name], [id_url], [xpath]) VALUES (N'login_form', N'', 28, N'/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]')
INSERT [dbo].[Form_elements] ([id_form], [name], [id_url], [xpath]) VALUES (N'reg', N'reg', 27, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]')
INSERT [dbo].[Form_elements] ([id_form], [name], [id_url], [xpath]) VALUES (N'reg', N'reg', 28, N'/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]')
/****** Object:  Table [dbo].[Input_testcase]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input_testcase](
	[id_testcase] [nvarchar](100) NOT NULL,
	[id_element] [nvarchar](100) NOT NULL,
	[id_url] [int] NOT NULL,
	[xpath] [nvarchar](max) NULL,
	[value] [nvarchar](max) NULL,
	[action] [nvarchar](50) NULL,
 CONSTRAINT [PK_Input_testcase] PRIMARY KEY CLUSTERED 
(
	[id_testcase] ASC,
	[id_element] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Element_test]    Script Date: 04/04/2020 00:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Element_test](
	[id_testcase] [nvarchar](100) NOT NULL,
	[id_url] [int] NOT NULL,
	[id_element] [nvarchar](100) NOT NULL,
	[xpath] [nvarchar](50) NOT NULL,
	[xpath_full] [nvarchar](max) NULL,
	[value_return] [nvarchar](max) NULL,
	[value_test] [nvarchar](max) NULL,
	[class_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Element_test_1] PRIMARY KEY CLUSTERED 
(
	[id_testcase] ASC,
	[id_url] ASC,
	[id_element] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Test_case_Redirect_url]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Test_case]  WITH CHECK ADD  CONSTRAINT [FK_Test_case_Redirect_url] FOREIGN KEY([id_testcase])
REFERENCES [dbo].[Redirect_url] ([id_testcase])
GO
ALTER TABLE [dbo].[Test_case] CHECK CONSTRAINT [FK_Test_case_Redirect_url]
GO
/****** Object:  ForeignKey [FK_Test_case_Url]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Test_case]  WITH CHECK ADD  CONSTRAINT [FK_Test_case_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Test_case] CHECK CONSTRAINT [FK_Test_case_Url]
GO
/****** Object:  ForeignKey [FK_Select_tag_Url]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Select_tag]  WITH CHECK ADD  CONSTRAINT [FK_Select_tag_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Select_tag] CHECK CONSTRAINT [FK_Select_tag_Url]
GO
/****** Object:  ForeignKey [FK_Element_Url]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Element]  WITH CHECK ADD  CONSTRAINT [FK_Element_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Element] CHECK CONSTRAINT [FK_Element_Url]
GO
/****** Object:  ForeignKey [FK_Button_tag_Url]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Button_tag]  WITH CHECK ADD  CONSTRAINT [FK_Button_tag_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Button_tag] CHECK CONSTRAINT [FK_Button_tag_Url]
GO
/****** Object:  ForeignKey [FK_A_tag_Url]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[A_tag]  WITH CHECK ADD  CONSTRAINT [FK_A_tag_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[A_tag] CHECK CONSTRAINT [FK_A_tag_Url]
GO
/****** Object:  ForeignKey [FK_Input_elements_Url]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Input_elements]  WITH CHECK ADD  CONSTRAINT [FK_Input_elements_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Input_elements] CHECK CONSTRAINT [FK_Input_elements_Url]
GO
/****** Object:  ForeignKey [FK_Form_elements_Url]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Form_elements]  WITH CHECK ADD  CONSTRAINT [FK_Form_elements_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Form_elements] CHECK CONSTRAINT [FK_Form_elements_Url]
GO
/****** Object:  ForeignKey [FK_Input_testcase_Element]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Input_testcase]  WITH CHECK ADD  CONSTRAINT [FK_Input_testcase_Element] FOREIGN KEY([id_element], [id_url])
REFERENCES [dbo].[Element] ([id_element], [id_url])
GO
ALTER TABLE [dbo].[Input_testcase] CHECK CONSTRAINT [FK_Input_testcase_Element]
GO
/****** Object:  ForeignKey [FK_Input_testcase_Test_case1]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Input_testcase]  WITH CHECK ADD  CONSTRAINT [FK_Input_testcase_Test_case1] FOREIGN KEY([id_testcase], [id_url])
REFERENCES [dbo].[Test_case] ([id_testcase], [id_url])
GO
ALTER TABLE [dbo].[Input_testcase] CHECK CONSTRAINT [FK_Input_testcase_Test_case1]
GO
/****** Object:  ForeignKey [FK_Element_test_Test_case]    Script Date: 04/04/2020 00:39:50 ******/
ALTER TABLE [dbo].[Element_test]  WITH CHECK ADD  CONSTRAINT [FK_Element_test_Test_case] FOREIGN KEY([id_testcase], [id_url])
REFERENCES [dbo].[Test_case] ([id_testcase], [id_url])
GO
ALTER TABLE [dbo].[Element_test] CHECK CONSTRAINT [FK_Element_test_Test_case]
GO
