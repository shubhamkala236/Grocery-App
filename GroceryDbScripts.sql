USE [master]
GO
/****** Object:  Database [GroceryDb]    Script Date: 18-06-2023 16:01:39 ******/
CREATE DATABASE [GroceryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GroceryDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\GroceryDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GroceryDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\GroceryDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GroceryDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GroceryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GroceryDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GroceryDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GroceryDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GroceryDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GroceryDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GroceryDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GroceryDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GroceryDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GroceryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GroceryDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GroceryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GroceryDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GroceryDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GroceryDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GroceryDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GroceryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GroceryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GroceryDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GroceryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GroceryDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GroceryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GroceryDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GroceryDb] SET RECOVERY FULL 
GO
ALTER DATABASE [GroceryDb] SET  MULTI_USER 
GO
ALTER DATABASE [GroceryDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GroceryDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GroceryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GroceryDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GroceryDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GroceryDb', N'ON'
GO
ALTER DATABASE [GroceryDb] SET QUERY_STORE = OFF
GO
USE [GroceryDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18-06-2023 16:01:39 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 18-06-2023 16:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[QuantityAdded] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 18-06-2023 16:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UniqueOrderId] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderQuantity] [int] NOT NULL,
	[OrderImageUrl] [nvarchar](max) NOT NULL,
	[OrderName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 18-06-2023 16:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Category] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[ImageCloudId] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[Specification] [nvarchar](100) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 18-06-2023 16:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Rating] [int] NOT NULL,
	[ReviewDate] [datetime2](7) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18-06-2023 16:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[isAdmin] [bit] NOT NULL,
	[Password] [varbinary](max) NOT NULL,
	[PasswordKey] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230602160503_AddedUsers', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230602164639_AddedPasswordKey', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230602205746_PhoneNumberToStringType', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230603102242_addedProductTable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230604061609_AddedCartModel', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230604130352_addedOrdersTable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230604140536_addedOrdersQuantity', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230604163426_addedImageUrlToOrders', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230606083229_addedNameToOrder', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230606083451_addedNameAgain', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607114603_addedAdmin', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607160921_ReviewAdded', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607162536_updatedReviewUserId', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607162723_updatedReviewUserName', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([CardId], [UserId], [ProductId], [QuantityAdded]) VALUES (17, 1, 1, 4)
INSERT [dbo].[Cart] ([CardId], [UserId], [ProductId], [QuantityAdded]) VALUES (18, 3, 8, 3)
INSERT [dbo].[Cart] ([CardId], [UserId], [ProductId], [QuantityAdded]) VALUES (1012, 2, 1, 4)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (2, N'cb2aa9c1-38af-423f-a038-6704390007b3', 1, 5, CAST(N'2023-06-04T22:16:08.2998345' AS DateTime2), 3, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685822450/zjbxzl7kzgc20hkgwijz.jpg', N'WhiteShoes')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (3, N'c9b55f78-75a0-43be-84af-b481ffb0dcad', 1, 1, CAST(N'2023-06-06T13:11:48.9417554' AS DateTime2), 2, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685801199/zathg86kpqqqexwjfhjo.jpg', N'Juice')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (4, N'd05cce2d-9938-43af-a53d-0c5a68273bb5', 1, 4, CAST(N'2023-06-06T13:12:33.4096052' AS DateTime2), 2, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685822701/ft0d41rjhx8fgtgcqcwf.jpg', N'ShoesAir')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (5, N'1c4eff2d-3d37-4e96-b807-8a206cb91b68', 1, 4, CAST(N'2023-06-06T13:22:31.5656077' AS DateTime2), 1, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685822701/ft0d41rjhx8fgtgcqcwf.jpg', N'ShoesAir')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (6, N'ec6f622f-2518-4ad5-acce-f3ff1109ccc6', 1, 1, CAST(N'2023-06-06T13:25:09.4080235' AS DateTime2), 1, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685801199/zathg86kpqqqexwjfhjo.jpg', N'Juice')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (11, N'a920aeca-ab2e-43f0-a660-5212c55c8fa7', 1, 1, CAST(N'2023-06-06T14:41:28.0166119' AS DateTime2), 2, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685801199/zathg86kpqqqexwjfhjo.jpg', N'Juice')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1007, N'938c188d-2b9d-4198-b2a5-b2316d7d1f5e', 1, 1002, CAST(N'2023-06-07T18:34:49.6014656' AS DateTime2), 4, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686142762/s5lmuwmul6jmnuvzajnm.jpg', N'Carrot')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1008, N'2086be1b-ae20-45e5-87cf-626094eb72dd', 1, 1002, CAST(N'2023-06-08T21:47:47.7303186' AS DateTime2), 3, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686142762/s5lmuwmul6jmnuvzajnm.jpg', N'Carrot')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1009, N'ff23aeea-f981-40d7-8e45-9c1956717e9f', 2, 1004, CAST(N'2023-06-13T16:10:14.2622664' AS DateTime2), 2, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686652714/y1upebeklq9dq8x5cmig.jpg', N'Rajma')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1010, N'3afc5b00-fd88-471e-9eb1-5bfd85ce4ff2', 2, 1004, CAST(N'2023-06-13T16:10:35.4651149' AS DateTime2), 1, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686652714/y1upebeklq9dq8x5cmig.jpg', N'Rajma')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1011, N'f970cd52-443f-41a2-81ad-297db4aaaed1', 2, 1004, CAST(N'2023-06-13T16:15:26.2453154' AS DateTime2), 10, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686653095/z4nnca0lyidbphuhvcc0.jpg', N'Rajma')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1012, N'903c8f9b-0e60-4d98-b801-1614a5c1f210', 2, 1005, CAST(N'2023-06-14T15:19:46.5158137' AS DateTime2), 9, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686736138/nq3zwmvulleskmyuj82f.jpg', N'Doritos')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1013, N'0e08ff4f-655a-414e-b3d4-9b511c9d2053', 2, 1005, CAST(N'2023-06-14T15:20:46.2616719' AS DateTime2), 3, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686736138/nq3zwmvulleskmyuj82f.jpg', N'Doritos')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1014, N'f00cd4ca-5fdf-4247-8d8a-29adefdd1047', 2, 1005, CAST(N'2023-06-14T15:21:08.4934688' AS DateTime2), 1, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686736138/nq3zwmvulleskmyuj82f.jpg', N'Doritos')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1015, N'ed97b350-9736-44bf-990c-af002df881e0', 2, 1005, CAST(N'2023-06-14T15:21:18.3921002' AS DateTime2), 1, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686736138/nq3zwmvulleskmyuj82f.jpg', N'Doritos')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1016, N'a2798351-bdb1-4e9b-8350-e301e02cc80d', 1005, 10, CAST(N'2023-06-18T14:33:51.9472878' AS DateTime2), 2, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686072668/qfuwlnhwc1ijezl60vf9.jpg', N'Chips')
INSERT [dbo].[Orders] ([OrderId], [UniqueOrderId], [UserId], [ProductId], [OrderDate], [OrderQuantity], [OrderImageUrl], [OrderName]) VALUES (1017, N'd89659f7-a6dc-4d30-aeb6-5d0ad48eed21', 1005, 5, CAST(N'2023-06-18T15:23:12.9797748' AS DateTime2), 2, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685822450/zjbxzl7kzgc20hkgwijz.jpg', N'WhiteShoes')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (1, N'OrangeJuice', N'Great', N'JUICE', 25, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686061680/vmvlfs2dxa5decsenyfx.jpg', N'vmvlfs2dxa5decsenyfx', CAST(100.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'NoSpecification')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (4, N'ShoesAir', N'AirForce', N'Footwear', 26, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685822701/ft0d41rjhx8fgtgcqcwf.jpg', N'ft0d41rjhx8fgtgcqcwf', CAST(25000.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'AirForce')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (5, N'WhiteShoes', N'FoamWhite', N'Footwear', 11, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1685822450/zjbxzl7kzgc20hkgwijz.jpg', N'zjbxzl7kzgc20hkgwijz', CAST(231.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), N'this')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (6, N'Milk', N'Carton', N'Drink', 20, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686056437/tlygwpysahblayjqqfz8.jpg', N'tlygwpysahblayjqqfz8', CAST(20.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'calcium')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (9, N'RiceBag', N'IndiaGate', N'Cereal', 50, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686072587/vlprjhzx5qhwrunenmgf.jpg', N'vlprjhzx5qhwrunenmgf', CAST(350.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), N'Basmati')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (10, N'Chips', N'Lays', N'Snacks', 28, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686072668/qfuwlnhwc1ijezl60vf9.jpg', N'qfuwlnhwc1ijezl60vf9', CAST(30.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), N'Potato')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (1002, N'Carrot', N'Fresh', N'Vegetable', 43, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686142762/s5lmuwmul6jmnuvzajnm.jpg', N's5lmuwmul6jmnuvzajnm', CAST(20.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), N'RedCarrot')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (1004, N'Rajma', N'Dal', N'Cereal', 0, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686653095/z4nnca0lyidbphuhvcc0.jpg', N'z4nnca0lyidbphuhvcc0', CAST(20.00 AS Decimal(18, 2)), CAST(16.00 AS Decimal(18, 2)), N'GreatFiber')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [Quantity], [ImageUrl], [ImageCloudId], [Price], [Discount], [Specification]) VALUES (1005, N'Doritos', N'Crunchy', N'Eatables', 26, N'https://res.cloudinary.com/shubham236-cloud/image/upload/v1686736138/nq3zwmvulleskmyuj82f.jpg', N'nq3zwmvulleskmyuj82f', CAST(30.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), N'WholeGrain')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (1, 1, 1, N'Shubham', 3, CAST(N'2023-06-07T22:21:17.3336013' AS DateTime2), N'Nice Product')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (2, 1, 1, N'Shubham', 3, CAST(N'2023-06-08T02:07:27.3046331' AS DateTime2), N'This is pure orange juice')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (3, 1, 1, N'Shubham', 1, CAST(N'2023-06-08T02:22:11.4454863' AS DateTime2), N'Tasty drink orange')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (4, 1, 1, N'Shubham', 2, CAST(N'2023-06-08T02:26:53.0757910' AS DateTime2), N'Amazing')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (5, 1, 1, N'Shubham', 1, CAST(N'2023-06-08T02:35:16.3732971' AS DateTime2), N'Delicious')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (6, 1, 6, N'Shubham', 3, CAST(N'2023-06-08T10:36:52.8577412' AS DateTime2), N'Cheap and good')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (7, 1, 6, N'Shubham', 5, CAST(N'2023-06-08T10:37:24.5073928' AS DateTime2), N'Great Taste with quality ')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (8, 1, 4, N'Shubham', 2, CAST(N'2023-06-08T10:39:02.7062919' AS DateTime2), N'Nice color')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (9, 1, 4, N'Shubham', 4, CAST(N'2023-06-08T10:39:16.3237387' AS DateTime2), N'Comfortable fit')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (10, 1, 10, N'Shubham', 1, CAST(N'2023-06-08T13:49:52.2901621' AS DateTime2), N'Amazing saltiness')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (11, 1, 1, N'Shubham', 4, CAST(N'2023-06-13T15:02:59.5750233' AS DateTime2), N'Great product value for money')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (12, 2, 1005, N'Milind', 5, CAST(N'2023-06-14T15:20:17.9415268' AS DateTime2), N'This is a great Product')
INSERT [dbo].[Reviews] ([ReviewId], [UserId], [ProductId], [UserName], [Rating], [ReviewDate], [Comment]) VALUES (13, 1005, 5, N'Ranjeev', 1, CAST(N'2023-06-18T15:22:59.0877046' AS DateTime2), N'A great Fit Product')
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (-1, N'Admin', N'admin@gmail.com', N'8098767811', 1, 0xE2AE8B39E6903B0B40BC2A35747788124DC5006CEB6BCB3380949BD8EA6AEC90B6ACB8880569AD9E3B45E8A975BEE1F0894ABC344833BF7A101D2F5CC11DAD32, 0x7E68E22D6C06E1B7F637839690F3337FF059B7EBA72BB328797D2FFE1DF2D48F332AE1C13EEB180B9A9408A4088FE3AA06635478EFE28D808EEF66D5EF988C51B91B300E7FCD33CBA3B3F01CE87C0AFDCDBBA43F0DBFF98AFB75D7D6BFFDAB762E40B8FC8A0B211052B4FD37448249C4EEFEB5920C8CF5499B7FDDF4E8315A40)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (1, N'Shubham', N'sk@gmail.com', N'0', 0, 0x3C815028913335E43993E45E6EE1CE2AC788252FD79C159CE39AC05BC551CDE4FF961290C477E588EA7E81A96D178460B14A4E12C6B152974A33BC023CDC1847, 0x787C4EA576096063E43B42582A6EC04A33064E077B2B27875A6737F66AC9C5B4BB5A72DF1278050C4E306DFF03D55E9464907B803EC2C55CC91E1ACF4F3F648985F4A82E2BD4A56A7FF9BCBF81BA62166D2119367F7DFBF83468C5226A788615517B7E50AB85040658348B9A6DED9CB884FDEC9CDA6D37ECFDB793C9855E42F8)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (2, N'Milind', N'Mb@gmail.com', N'8909876789', 0, 0x4269E9FBB2FBE0285F87C14B1178B9EC81F0C2D7C55173CB1B6F3E030BA412CCD5F9D6DA24106904370DE441B20E88A89118B4C8400CE35A63228CB7EF120D8C, 0x1EA99384CC33F28AB3733D65B88BE79E889F418B4FA41AF570D700F973B640EECA38D08A3E822721EC832B9FC9EF0702EA02B8547980C4F610BDA634F72F979489189D96A8BAEB1902E8ADF0E81C0A49B374A5A09E8E54BBEFBBB2432B48007BC2EA1FA658D6C3E0EF4EBA590ACE900AD9266A3EAA08A2F9482B54CBD2491BAA)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (3, N'ShubhamAdmin', N'sl@gmail.com', N'8078778900', 1, 0x77AF6CA03F873370481B2A1636A95214297A7537EF71BD119EEB031DA9548BA9263FFB32BBDEB27C032A1621B294E0C9A1F22B9F692AAFFA8F69DB16C97DCD02, 0xE70F6F1A17E521BD9D2034FDD2719D8D1AB0F5414A92C2EEF2D960C34CCC90579FBAF6A4B05F9AC4F98001C8D3F6E7397EEF133487BB93A79A3C8DE44CE744062E2D542210DB54E6094BD7CFEB780D1B4DF4DCF30CBF44215750C640514DDE237684A224C5B57049A86632AF89F6BCDCFE9CC5FB714A803E90C081B7695ABB85)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (4, N'Rahul', N'Rak@gmail.com', N'7282987366', 0, 0x1420A25E71A8FC69187A175F6C98E3AB416714970424AC20E77D40064B8F5E1ED3113D5D67F3899F7BB1048C581406B1A28498F352529842037A3AF10190D55C, 0x7FF043FA1BE8999E2B4C318A3F486120037493286CF2117DF50D01335558A79D369823A8A0AD04B95EE125839A6F140785E199347BA61801A6BEAE59251C2225920426B8505819B44C9B56985FCA8A76690C7DCFF99AD3FDB2B0258A2A6635B5B4594AAAB21BDBD514EBB94ADA1F940319A9F0765C352424E7C8A36337EC03D5)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (5, N'Ramesh', N'ram@gmail.com', N'9287627899', 0, 0x55409CE9A2965315F3F8D6376EC8FD48693A7A2A02B2A7F2C7F317111D044175A94A0E0E20E38C1362337C07BC394D49BECC27E536470913CADDB9F8571524C0, 0x64BF5F90000023E000C2B1CA5D7C5448103B98CCE74755314A031CA77BB0933334B65FFBAFF537015EF0DF1DF4554C6E790198DF0950BD31FBAE6C23033FDF89D6976CEAC8D7035FF28C2EF34AB1C64724C9FE7EA521D2308F070BFA0CC89B2D6AF00E5A053A9115C8216A09CE2523E3693D31CC60534082103F85DBEEC57663)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (6, N'rink', N'rink@gmail.com', N'2827262899', 0, 0xF22A0479A3C38CEFA51790007F5C1865600947EB42AFDEA11A3327CCB6985486B499953D691C5B2ECE37565DE7F356E96D0DC8F0AE8B05557D0E147D476004BE, 0xDA0B10EA4400BAB18BA00CF5495C9EE5B7D4EC39CD1B83983475C9080ECA5F5882A7CE52C82BCF1D41281A42DC9C9CC2A05AF7EB096B6121D00B515EA8228F0F9F9CAEB004C609336AE0F73EE03A708DF72A43307741F6BCC61EB6718D0F053760D560E04726FC26656E23210D84ABDD05B67B681C21B673357AA405E6F1965A)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (7, N'Reema', N'rema@gmail.com', N'2827262992', 0, 0xC08178EE16AAA6C4ECEE1FDD2D9D6C2FB58A60F20F10AEA8C3898C2569E34F526776D41BDF2CABD881880898BEA1F5F99AC026D743A06CB7366654CE553D9125, 0xF074E2D1DD3D8E93D36AFD068FE64DF24338AE7B8815686286496009CA0F74D9BB5A63E5A0F03258701B5D87E32E9960597370178DB6CFFDF66CC73B7AF55ECED365D736FC1BA7145245E434468A82FBDDBF040855B51E5414C9F055C16E4FCD541D11287D3FB234129FE0ADB2925407855B410E63237988D27AF758159052BA)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (8, N'Karan', N'karan@gmail.com', N'8272615880', 0, 0xC297D16EC05341F481E0806F4702E5449279E8B761FD3E48EB7852F7D3210EF02E100F36F26130EEEDEF85016459F2515E51206124746743D495211A989EE785, 0x91CB72F144039B72C1A8CE20C4706A5CA09EDA0A841B221BE43AB5AC29B028127EA7737DEE75E226C530F1D4C9195203781C163E86F12E827120D7A57CF2BEF9990817CC739DE74035B943026BECC1E6C027F4D27C16C484F1359A036F2C14C8C72D3FDE1FC375E09827916298763D6CEF36E6F20E06C0C7415F4D3E5C40E275)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (1004, N'Lalit', N'lat@gmail.com', N'9287617889', 0, 0xF64B4A4F83FD0403E91F3760710B177E2A0F65C3EFB35D56D6936CA48E3681831725A0D4FC6C73C672D8C0F3EA9D7BF7A90E2906A95A2047630FEA478D895A9A, 0x34768574EAD5001C4617B3AB2D76EEA4F909280698624AF732F5EC9367546DF778A05728A90C6E43F5B2C6142A17315A3E92BB21B790436B03E285BCA604C621632E091FF9F1018570755F49A811AC7E063513ADB6F234341B5F2FC1030BEC42BF72D509403392A2356B03B9A0A7A98A0D54F1067B007614DD80BCE54E528203)
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [isAdmin], [Password], [PasswordKey]) VALUES (1005, N'Ranjeev', N'ranjeev@gmail.com', N'8276378200', 0, 0xFB7D8750F220BCFA220599AA569B9059F5C4C00FD97B46F0383ED10FE930012260DCB8F0B56D6233140D6CE68F7CE89F2685EE5C727C3E608C31167C94F1ECBC, 0x286259888DBF569E27C10FEE9FB37CA1BB6B6B9FD5746D6D029AAFE9B2508FCDA9D3B9D5CD31E0EC14079C14CCD64FD066797B78C893C96ECA3240CF13273F2C9BB5D347C461EB600643A2C458FF02734772B4E7A03A17CC5BF45C7F0DAA24DB1F0387CFCD0B2ADE0888CC39683636A5B14EB4D5B61ED910CCC0BEE7A6EBDC4C)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [OrderQuantity]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [OrderImageUrl]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [OrderName]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Email]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (0x) FOR [Password]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (0x) FOR [PasswordKey]
GO
USE [master]
GO
ALTER DATABASE [GroceryDb] SET  READ_WRITE 
GO
