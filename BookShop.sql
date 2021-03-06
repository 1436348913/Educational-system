USE [master]
GO
/****** Object:  Database [BookShop]    Script Date: 2019/12/13 18:21:19 ******/
CREATE DATABASE [BookShop] ON  PRIMARY 
( NAME = N'BookShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookShop.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookShop_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookShop] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BookShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookShop] SET RECOVERY FULL 
GO
ALTER DATABASE [BookShop] SET  MULTI_USER 
GO
ALTER DATABASE [BookShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookShop] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookShop', N'ON'
GO
USE [BookShop]
GO
/****** Object:  Table [dbo].[F]    Script Date: 2019/12/13 18:21:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[F](
	[FID] [char](10) NOT NULL,
	[FName] [char](50) NOT NULL,
	[Fnum] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KC]    Script Date: 2019/12/13 18:21:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KC](
	[KID] [int] IDENTITY(1,1) NOT NULL,
	[FID] [char](10) NOT NULL,
	[FName] [char](10) NOT NULL,
	[TID] [char](10) NOT NULL,
	[TName] [char](10) NOT NULL,
 CONSTRAINT [PK_KC] PRIMARY KEY CLUSTERED 
(
	[KID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[score]    Script Date: 2019/12/13 18:21:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[score](
	[FID] [char](10) NULL,
	[MID] [char](10) NULL,
	[TID] [char](10) NULL,
	[Score] [int] NULL,
	[SID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_score] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2019/12/13 18:21:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[MID] [char](10) NOT NULL,
	[MPassWord] [char](50) NOT NULL,
	[MName] [char](50) NOT NULL,
	[Msex] [char](10) NOT NULL,
	[Mclass] [char](10) NOT NULL,
	[MclassID] [int] NOT NULL,
	[MUserID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__Student__C797348A7B366F7A] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2019/12/13 18:21:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[TID] [char](10) NOT NULL,
	[TPassWord] [char](50) NOT NULL,
	[TName] [char](50) NOT NULL,
	[Tsex] [char](10) NOT NULL,
	[TUserID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2019/12/13 18:21:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[F] ON 

INSERT [dbo].[F] ([FID], [FName], [Fnum]) VALUES (N'F001      ', N'计算机基础                                        ', 1)
INSERT [dbo].[F] ([FID], [FName], [Fnum]) VALUES (N'F002      ', N'大学物理                                          ', 2)
INSERT [dbo].[F] ([FID], [FName], [Fnum]) VALUES (N'F003      ', N'Java基础                                          ', 3)
SET IDENTITY_INSERT [dbo].[F] OFF
SET IDENTITY_INSERT [dbo].[KC] ON 

INSERT [dbo].[KC] ([KID], [FID], [FName], [TID], [TName]) VALUES (1, N'F001      ', N'计算机基础', N'T001      ', N'黎明      ')
INSERT [dbo].[KC] ([KID], [FID], [FName], [TID], [TName]) VALUES (2, N'F002      ', N'大学物理  ', N'T002      ', N'张强      ')
INSERT [dbo].[KC] ([KID], [FID], [FName], [TID], [TName]) VALUES (3, N'F003      ', N'Java基础  ', N'T003      ', N'王红      ')
INSERT [dbo].[KC] ([KID], [FID], [FName], [TID], [TName]) VALUES (6, N'F001      ', N'计算机基础', N'T004      ', N'张磊      ')
INSERT [dbo].[KC] ([KID], [FID], [FName], [TID], [TName]) VALUES (7, N'F003      ', N'Java基础  ', N'T005      ', N'王丽      ')
SET IDENTITY_INSERT [dbo].[KC] OFF
SET IDENTITY_INSERT [dbo].[score] ON 

INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F001      ', N'M3001     ', N'T001      ', 80, 1)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F002      ', N'M3001     ', N'T002      ', 79, 3)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F003      ', N'M3001     ', N'T003      ', 65, 4)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F001      ', N'M3002     ', N'T001      ', 88, 5)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F002      ', N'M3002     ', N'T002      ', 66, 6)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F003      ', N'M3002     ', N'T003      ', 55, 7)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F001      ', N'M3003     ', N'T001      ', 77, 8)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F002      ', N'M3003     ', N'T002      ', 88, 17)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F003      ', N'M3003     ', N'T003      ', 99, 18)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F001      ', N'M4004     ', N'T004      ', 72, 19)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F002      ', N'M4004     ', N'T002      ', 85, 21)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F003      ', N'M4004     ', N'T005      ', 58, 26)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F001      ', N'M4005     ', N'T004      ', 55, 27)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F002      ', N'M4005     ', N'T002      ', 88, 29)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F003      ', N'M4005     ', N'T005      ', 69, 30)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F001      ', N'M4006     ', N'T004      ', 99, 31)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F002      ', N'M4006     ', N'T002      ', 69, 32)
INSERT [dbo].[score] ([FID], [MID], [TID], [Score], [SID]) VALUES (N'F003      ', N'M4006     ', N'T005      ', 78, 33)
SET IDENTITY_INSERT [dbo].[score] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([MID], [MPassWord], [MName], [Msex], [Mclass], [MclassID], [MUserID]) VALUES (N'M3001     ', N'1234                                              ', N'小明                                              ', N'男        ', N'计科1703  ', 3, 1)
INSERT [dbo].[Student] ([MID], [MPassWord], [MName], [Msex], [Mclass], [MclassID], [MUserID]) VALUES (N'M3002     ', N'1234                                              ', N'小刘                                              ', N'男        ', N'计科1703  ', 3, 2)
INSERT [dbo].[Student] ([MID], [MPassWord], [MName], [Msex], [Mclass], [MclassID], [MUserID]) VALUES (N'M3003     ', N'1234                                              ', N'小红                                              ', N'女        ', N'计科1703  ', 3, 3)
INSERT [dbo].[Student] ([MID], [MPassWord], [MName], [Msex], [Mclass], [MclassID], [MUserID]) VALUES (N'M4004     ', N'1234                                              ', N'小李                                              ', N'男        ', N'计科1704  ', 4, 6)
INSERT [dbo].[Student] ([MID], [MPassWord], [MName], [Msex], [Mclass], [MclassID], [MUserID]) VALUES (N'M4005     ', N'1234                                              ', N'小王                                              ', N'女        ', N'计科1704  ', 4, 7)
INSERT [dbo].[Student] ([MID], [MPassWord], [MName], [Msex], [Mclass], [MclassID], [MUserID]) VALUES (N'M4006     ', N'1234                                              ', N'小吧                                              ', N'男        ', N'计科1704  ', 4, 8)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TID], [TPassWord], [TName], [Tsex], [TUserID]) VALUES (N'T001      ', N'1234                                              ', N'黎明                                              ', N'男        ', 1)
INSERT [dbo].[Teacher] ([TID], [TPassWord], [TName], [Tsex], [TUserID]) VALUES (N'T002      ', N'1234                                              ', N'张强                                              ', N'男        ', 2)
INSERT [dbo].[Teacher] ([TID], [TPassWord], [TName], [Tsex], [TUserID]) VALUES (N'T003      ', N'1234                                              ', N'王红                                              ', N'女        ', 3)
INSERT [dbo].[Teacher] ([TID], [TPassWord], [TName], [Tsex], [TUserID]) VALUES (N'T004      ', N'1234                                              ', N'张磊                                              ', N'男        ', 4)
INSERT [dbo].[Teacher] ([TID], [TPassWord], [TName], [Tsex], [TUserID]) VALUES (N'T005      ', N'1234                                              ', N'王丽                                              ', N'女        ', 6)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [PassWord]) VALUES (1, N'1234', N'1234')
INSERT [dbo].[User] ([UserID], [UserName], [PassWord]) VALUES (2, N'1111', N'1111')
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [KC_unique]    Script Date: 2019/12/13 18:21:19 ******/
ALTER TABLE [dbo].[KC] ADD  CONSTRAINT [KC_unique] UNIQUE NONCLUSTERED 
(
	[FID] ASC,
	[TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [uk_t_1]    Script Date: 2019/12/13 18:21:19 ******/
ALTER TABLE [dbo].[score] ADD  CONSTRAINT [uk_t_1] UNIQUE NONCLUSTERED 
(
	[FID] ASC,
	[MID] ASC,
	[TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [uk_t_11]    Script Date: 2019/12/13 18:21:19 ******/
ALTER TABLE [dbo].[score] ADD  CONSTRAINT [uk_t_11] UNIQUE NONCLUSTERED 
(
	[FID] ASC,
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KC]  WITH CHECK ADD  CONSTRAINT [FK_KC_F] FOREIGN KEY([FID])
REFERENCES [dbo].[F] ([FID])
GO
ALTER TABLE [dbo].[KC] CHECK CONSTRAINT [FK_KC_F]
GO
ALTER TABLE [dbo].[KC]  WITH CHECK ADD  CONSTRAINT [FK_KC_Teacher] FOREIGN KEY([TID])
REFERENCES [dbo].[Teacher] ([TID])
GO
ALTER TABLE [dbo].[KC] CHECK CONSTRAINT [FK_KC_Teacher]
GO
ALTER TABLE [dbo].[score]  WITH NOCHECK ADD  CONSTRAINT [FK__score__FID__4F7CD00D] FOREIGN KEY([FID])
REFERENCES [dbo].[F] ([FID])
GO
ALTER TABLE [dbo].[score] CHECK CONSTRAINT [FK__score__FID__4F7CD00D]
GO
ALTER TABLE [dbo].[score]  WITH CHECK ADD  CONSTRAINT [FK__score__MID__5070F446] FOREIGN KEY([MID])
REFERENCES [dbo].[Student] ([MID])
GO
ALTER TABLE [dbo].[score] CHECK CONSTRAINT [FK__score__MID__5070F446]
GO
ALTER TABLE [dbo].[score]  WITH NOCHECK ADD  CONSTRAINT [FK__score__TID__5165187F] FOREIGN KEY([TID])
REFERENCES [dbo].[Teacher] ([TID])
GO
ALTER TABLE [dbo].[score] CHECK CONSTRAINT [FK__score__TID__5165187F]
GO
USE [master]
GO
ALTER DATABASE [BookShop] SET  READ_WRITE 
GO
