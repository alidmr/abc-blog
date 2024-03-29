USE [AbcBlogDb]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [DF_Users_IsEmailVerified]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28.08.2022 01:46:27 ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 28.08.2022 01:46:27 ******/
DROP TABLE IF EXISTS [dbo].[Articles]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 28.08.2022 01:46:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Articles_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28.08.2022 01:46:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[PasswordSalt] [nvarchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [Title], [Slug], [Description], [StatusId], [CreatedUserId], [CreatedDate]) VALUES (1, N'Lorem Ipsum Nereden Gelir?', N'lorem-ipsum-nereden-gelir-9337', N'Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia''daki Hampden-Sydney College''dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan ''consectetur'' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.', 2, 1, CAST(N'2022-07-29T11:34:08.050' AS DateTime))
INSERT [dbo].[Articles] ([Id], [Title], [Slug], [Description], [StatusId], [CreatedUserId], [CreatedDate]) VALUES (2, N'Lorem Ipsum Nedir?', N'lorem-ipsum-nedir-8434', N'Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500''lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960''larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.', 3, 1, CAST(N'2022-07-29T15:38:47.133' AS DateTime))
INSERT [dbo].[Articles] ([Id], [Title], [Slug], [Description], [StatusId], [CreatedUserId], [CreatedDate]) VALUES (3, N'Test Article 1', N'test-article-1-3611', N'Test Article 1 Description', 3, 2, CAST(N'2022-08-28T01:32:39.847' AS DateTime))
INSERT [dbo].[Articles] ([Id], [Title], [Slug], [Description], [StatusId], [CreatedUserId], [CreatedDate]) VALUES (4, N'Test Article 2', N'test-article-2-3913', N'Test Article 2 Description', 3, 2, CAST(N'2022-08-28T01:32:52.987' AS DateTime))
INSERT [dbo].[Articles] ([Id], [Title], [Slug], [Description], [StatusId], [CreatedUserId], [CreatedDate]) VALUES (5, N'Test Article 3', N'test-article-3-5231', N'Test Article 3 Description', 3, 2, CAST(N'2022-08-28T01:33:03.073' AS DateTime))
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [IsActive], [IsDeleted], [IsEmailVerified], [Password], [PasswordSalt], [CreatedDate]) VALUES (1, N'Ali', N'Demir', N'alidemirytu@gmail.com', 1, 0, 0, N'56bc0e00e32da12d9feb0289db936ae0772c4a1d8703866cfd44e19afe330589', N'f8d6978921db18fc3e1130c9b44edcfe', CAST(N'2022-07-29T11:26:59.073' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [IsActive], [IsDeleted], [IsEmailVerified], [Password], [PasswordSalt], [CreatedDate]) VALUES (2, N'Can', N'Soytürk', N'can@mail.com', 1, 1, 0, N'05b5b2f1e8f5909c159806619606dabe1c7d885c0f455f542c1cdfedf681280e', N'7af406d8c761a4969daa20409b2fc221', CAST(N'2022-08-28T01:31:58.850' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsEmailVerified]  DEFAULT ((0)) FOR [IsEmailVerified]
GO
