USE [master]
GO
/****** Object:  Database [ElementDB]    Script Date: 05/02/2020 01:01:06 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles] 
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers] 
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers] 
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Id_User] [nvarchar](450) NOT NULL,
	[name] [nvarchar](450) NOT NULL,
	[description] [nvarchar](450) NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Url]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Url](
	[id_url] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[url] [nvarchar](max) NOT NULL,
	[project_id] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedDate] [date] NULL,
 CONSTRAINT [PK_Url] PRIMARY KEY CLUSTERED 
(
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Element]    Script Date: 05/02/2020 01:01:08 ******/
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
/****** Object:  Table [dbo].[Button_tag]    Script Date: 05/02/2020 01:01:08 ******/
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
/****** Object:  Table [dbo].[A_tag]    Script Date: 05/02/2020 01:01:08 ******/
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
/****** Object:  Table [dbo].[Test_case]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_case](
	[id_testcase] [nvarchar](100) NOT NULL,
	[id_url] [int] NOT NULL,
	[description] [nvarchar](200) NULL,
	[result] [nvarchar](50) NULL,
	[is_test] [bit] NULL,
	[CreatedDate] [date] NULL,
	[ModifiedDate] [date] NULL,
 CONSTRAINT [PK_Test_case_1] PRIMARY KEY CLUSTERED 
(
	[id_testcase] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Select_tag]    Script Date: 05/02/2020 01:01:08 ******/
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
/****** Object:  Table [dbo].[Input_elements]    Script Date: 05/02/2020 01:01:08 ******/
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
/****** Object:  Table [dbo].[Form_elements]    Script Date: 05/02/2020 01:01:08 ******/
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
/****** Object:  Table [dbo].[Input_testcase]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input_testcase](
	[id_testcase] [nvarchar](100) NOT NULL,
	[id_element] [nvarchar](100) NOT NULL,
	[id_url] [int] NOT NULL,
	[test_step] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Element_test]    Script Date: 05/02/2020 01:01:08 ******/
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
/****** Object:  Table [dbo].[Redirect_url]    Script Date: 05/02/2020 01:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Redirect_url](
	[id_testcase] [nvarchar](100) NOT NULL,
	[id_url] [int] NOT NULL,
	[current_url] [nvarchar](max) NOT NULL,
	[redirect_url_test] [nvarchar](max) NULL,
 CONSTRAINT [PK_Redirect_url_1] PRIMARY KEY CLUSTERED 
(
	[id_testcase] ASC,
	[id_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF__AspNetUse__IsAdm__02FC7413]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0),0)) FOR [IsAdmin]
GO
/****** Object:  ForeignKey [FK_AspNetUserRoles_AspNetRoles_RoleId]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
/****** Object:  ForeignKey [FK_AspNetUserRoles_AspNetUsers_UserId]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_AspNetUserLogins_AspNetUsers_UserId]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_AspNetUserClaims_AspNetUsers_UserId]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_AspNetRoleClaims_AspNetRoles_RoleId]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
/****** Object:  ForeignKey [FK_AspNetUserTokens_AspNetUsers_UserId]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_Project_AspNetUsers]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_AspNetUsers] FOREIGN KEY([Id_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_AspNetUsers]
GO
/****** Object:  ForeignKey [FK_Url_Project]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Url]  WITH CHECK ADD  CONSTRAINT [FK_Url_Project] FOREIGN KEY([project_id])
REFERENCES [dbo].[Project] ([id])
GO
ALTER TABLE [dbo].[Url] CHECK CONSTRAINT [FK_Url_Project]
GO
/****** Object:  ForeignKey [FK_Element_Url]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Element]  WITH CHECK ADD  CONSTRAINT [FK_Element_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Element] CHECK CONSTRAINT [FK_Element_Url]
GO
/****** Object:  ForeignKey [FK_Button_tag_Url]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Button_tag]  WITH CHECK ADD  CONSTRAINT [FK_Button_tag_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Button_tag] CHECK CONSTRAINT [FK_Button_tag_Url]
GO
/****** Object:  ForeignKey [FK_A_tag_Url]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[A_tag]  WITH CHECK ADD  CONSTRAINT [FK_A_tag_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[A_tag] CHECK CONSTRAINT [FK_A_tag_Url]
GO
/****** Object:  ForeignKey [FK_Test_case_Url]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Test_case]  WITH CHECK ADD  CONSTRAINT [FK_Test_case_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Test_case] CHECK CONSTRAINT [FK_Test_case_Url]
GO
/****** Object:  ForeignKey [FK_Select_tag_Url]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Select_tag]  WITH CHECK ADD  CONSTRAINT [FK_Select_tag_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Select_tag] CHECK CONSTRAINT [FK_Select_tag_Url]
GO
/****** Object:  ForeignKey [FK_Input_elements_Url]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Input_elements]  WITH CHECK ADD  CONSTRAINT [FK_Input_elements_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Input_elements] CHECK CONSTRAINT [FK_Input_elements_Url]
GO
/****** Object:  ForeignKey [FK_Form_elements_Url]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Form_elements]  WITH CHECK ADD  CONSTRAINT [FK_Form_elements_Url] FOREIGN KEY([id_url])
REFERENCES [dbo].[Url] ([id_url])
GO
ALTER TABLE [dbo].[Form_elements] CHECK CONSTRAINT [FK_Form_elements_Url]
GO
/****** Object:  ForeignKey [FK_Input_testcase_Element]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Input_testcase]  WITH CHECK ADD  CONSTRAINT [FK_Input_testcase_Element] FOREIGN KEY([id_element], [id_url])
REFERENCES [dbo].[Element] ([id_element], [id_url])
GO
ALTER TABLE [dbo].[Input_testcase] CHECK CONSTRAINT [FK_Input_testcase_Element]
GO
/****** Object:  ForeignKey [FK_Input_testcase_Test_case1]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Input_testcase]  WITH CHECK ADD  CONSTRAINT [FK_Input_testcase_Test_case1] FOREIGN KEY([id_testcase], [id_url])
REFERENCES [dbo].[Test_case] ([id_testcase], [id_url])
GO
ALTER TABLE [dbo].[Input_testcase] CHECK CONSTRAINT [FK_Input_testcase_Test_case1]
GO
/****** Object:  ForeignKey [FK_Element_test_Test_case]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Element_test]  WITH CHECK ADD  CONSTRAINT [FK_Element_test_Test_case] FOREIGN KEY([id_testcase], [id_url])
REFERENCES [dbo].[Test_case] ([id_testcase], [id_url])
GO
ALTER TABLE [dbo].[Element_test] CHECK CONSTRAINT [FK_Element_test_Test_case]
GO
/****** Object:  ForeignKey [FK_Redirect_url_Test_case]    Script Date: 05/02/2020 01:01:08 ******/
ALTER TABLE [dbo].[Redirect_url]  WITH CHECK ADD  CONSTRAINT [FK_Redirect_url_Test_case] FOREIGN KEY([id_testcase], [id_url])
REFERENCES [dbo].[Test_case] ([id_testcase], [id_url])
GO
ALTER TABLE [dbo].[Redirect_url] CHECK CONSTRAINT [FK_Redirect_url_Test_case]
GO
