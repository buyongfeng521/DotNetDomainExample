USE [master]
GO
/****** Object:  Database [Step_Test]    Script Date: 2016/12/17 9:32:40 ******/
CREATE DATABASE [Step_Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Step_Test', FILENAME = N'G:\DbBase\Step_Test.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Step_Test_log', FILENAME = N'G:\DbBase\Step_Test_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Step_Test] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Step_Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Step_Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Step_Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Step_Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Step_Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Step_Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Step_Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Step_Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Step_Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Step_Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Step_Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Step_Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Step_Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Step_Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Step_Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Step_Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Step_Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Step_Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Step_Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Step_Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Step_Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Step_Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Step_Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Step_Test] SET RECOVERY FULL 
GO
ALTER DATABASE [Step_Test] SET  MULTI_USER 
GO
ALTER DATABASE [Step_Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Step_Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Step_Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Step_Test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Step_Test] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Step_Test', N'ON'
GO
USE [Step_Test]
GO
/****** Object:  Table [dbo].[t_admin_user]    Script Date: 2016/12/17 9:32:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_admin_user](
	[user_id] [varchar](50) NOT NULL,
	[role_id] [varchar](50) NULL,
	[user_name] [varchar](25) NULL,
	[user_psw] [varchar](50) NULL,
	[user_salt] [varchar](20) NULL,
	[user_realname] [nvarchar](20) NULL,
	[last_login_time] [datetime] NULL,
	[create_time] [datetime] NULL,
 CONSTRAINT [PK_t_admin_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_menu]    Script Date: 2016/12/17 9:32:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_menu](
	[menu_id] [varchar](50) NOT NULL,
	[menu_name] [nvarchar](25) NULL,
	[menu_value] [varchar](20) NULL,
	[menu_url] [varchar](256) NULL,
	[menu_order] [tinyint] NULL,
	[menu_icon] [varchar](20) NULL,
	[parent_id] [varchar](50) NULL,
	[menu_area] [varchar](20) NULL,
	[menu_controller] [varchar](20) NULL,
	[menu_action] [varchar](20) NULL,
	[menu_style] [varchar](20) NULL,
	[create_time] [datetime] NULL,
 CONSTRAINT [PK_t_menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_role]    Script Date: 2016/12/17 9:32:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_role](
	[role_id] [varchar](50) NOT NULL,
	[role_name] [nvarchar](25) NULL,
	[create_time] [datetime] NULL,
 CONSTRAINT [PK_t_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_role_menu]    Script Date: 2016/12/17 9:32:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_role_menu](
	[role_id] [varchar](50) NOT NULL,
	[menu_id] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_role_menu_1] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC,
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[t_admin_user]  WITH CHECK ADD  CONSTRAINT [FK_t_admin_user_t_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[t_role] ([role_id])
GO
ALTER TABLE [dbo].[t_admin_user] CHECK CONSTRAINT [FK_t_admin_user_t_role]
GO
ALTER TABLE [dbo].[t_role_menu]  WITH CHECK ADD  CONSTRAINT [FK_t_role_menu_t_menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[t_menu] ([menu_id])
GO
ALTER TABLE [dbo].[t_role_menu] CHECK CONSTRAINT [FK_t_role_menu_t_menu]
GO
ALTER TABLE [dbo].[t_role_menu]  WITH CHECK ADD  CONSTRAINT [FK_t_role_menu_t_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[t_role] ([role_id])
GO
ALTER TABLE [dbo].[t_role_menu] CHECK CONSTRAINT [FK_t_role_menu_t_role]
GO
USE [master]
GO
ALTER DATABASE [Step_Test] SET  READ_WRITE 
GO
