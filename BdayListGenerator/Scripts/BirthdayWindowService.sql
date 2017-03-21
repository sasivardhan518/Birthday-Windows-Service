USE [BDayDB]
GO
/****** Object:  Table [dbo].[BDTable]    Script Date: 21-Mar-17 6:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BDTable](
	[Name] [varchar](500) NULL,
	[BirthDay] [datetime] NULL,
	[MailId] [varchar](5000) NULL,
	[wishName] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Niteesha Jupally
', CAST(N'1994-03-09 00:00:00.000' AS DateTime), N'niteesha.jupally@inrhythm-inc.com
', N'Niteesha(Konda)')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Sai Kumar Vanam
', CAST(N'1994-04-30 00:00:00.000' AS DateTime), N'saikumar.vanam@inrhythm-inc.com
', N'Vanam')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Ajay Vardham Bejjam
', CAST(N'1993-07-22 00:00:00.000' AS DateTime), N'ajay.bejjam@inrhythm-inc.com
', N'Victory')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Mallesh Musuni
', CAST(N'1994-07-26 00:00:00.000' AS DateTime), N'mallesh.musuni@inrhythm-inc.com
', N'Heroo')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Raghu Veera Teja Gudapati
', CAST(N'1994-07-26 00:00:00.000' AS DateTime), N'raghu.gudapati@inrhythm-inc.com
', N'Ragghu')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Srinivasa Yella
', CAST(N'1994-08-25 00:00:00.000' AS DateTime), N'srinivasa.yella@inrhythm-inc.com
', N'YSR')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Venkata Sai Varsha Mathukumalli
', CAST(N'1994-08-30 00:00:00.000' AS DateTime), N'varsha.mathukumalli@inrhythm-inc.com
', N'Varsha')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Shiva Prasad Potharaju
', CAST(N'1992-10-27 00:00:00.000' AS DateTime), N'shiva.potharaju@inrhythm-inc.com
', N'Shiva')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Sai Kiriti Sambangi
', CAST(N'1994-11-11 00:00:00.000' AS DateTime), N'saikiriti.sambangi@inrhythm-inc.com
', N'Kaka')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Jagadish Chigurupati
', CAST(N'1993-11-25 00:00:00.000' AS DateTime), N'jagadish.chigurupati@inrhythm-inc.com
', N'Jaggu')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Karthik Indreesh Bandi
', CAST(N'1994-11-28 00:00:00.000' AS DateTime), N'karthik.bandi@inrhythm-inc.com
', N'Karthik')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Shashi Vardhana Rao Dadi
', CAST(N'1992-11-30 00:00:00.000' AS DateTime), N'shashi.dadi@inrhythm-inc.com
', N'SASI')
GO
INSERT [dbo].[BDTable] ([Name], [BirthDay], [MailId], [wishName]) VALUES (N'Sreeja Banswada
', CAST(N'1994-12-28 00:00:00.000' AS DateTime), N'sreeja.banswada@inrhythm-inc.com
', N'CHEEJA')
GO
