USE [master]
GO
/****** Object:  Database [EMI-R]    Script Date: 08/02/2022 23:04:10 ******/
CREATE DATABASE [EMI-R]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EMI-R', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EMI-R.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EMI-R_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EMI-R_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EMI-R] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EMI-R].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EMI-R] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EMI-R] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EMI-R] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EMI-R] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EMI-R] SET ARITHABORT OFF 
GO
ALTER DATABASE [EMI-R] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EMI-R] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EMI-R] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EMI-R] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EMI-R] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EMI-R] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EMI-R] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EMI-R] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EMI-R] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EMI-R] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EMI-R] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EMI-R] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EMI-R] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EMI-R] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EMI-R] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EMI-R] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EMI-R] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EMI-R] SET RECOVERY FULL 
GO
ALTER DATABASE [EMI-R] SET  MULTI_USER 
GO
ALTER DATABASE [EMI-R] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EMI-R] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EMI-R] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EMI-R] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EMI-R] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EMI-R] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EMI-R', N'ON'
GO
ALTER DATABASE [EMI-R] SET QUERY_STORE = OFF
GO
USE [EMI-R]
GO
/****** Object:  Table [dbo].[adherents]    Script Date: 08/02/2022 23:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adherents](
	[idAdherents] [int] IDENTITY(1,1) NOT NULL,
	[societe] [nvarchar](40) NOT NULL,
	[civiliteContact] [varchar](4) NOT NULL,
	[nomContact] [nvarchar](50) NOT NULL,
	[prenomContact] [nchar](50) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[adresse] [nvarchar](38) NOT NULL,
	[dateAdhesion] [datetime] NOT NULL,
 CONSTRAINT [PK_adherents] PRIMARY KEY CLUSTERED 
(
	[idAdherents] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[assoProduitsFournisseurs]    Script Date: 08/02/2022 23:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[assoProduitsFournisseurs](
	[idFournisseurs] [int] NOT NULL,
	[idProduits] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fournisseurs]    Script Date: 08/02/2022 23:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fournisseurs](
	[idFournisseurs] [int] IDENTITY(1,1) NOT NULL,
	[societe] [varchar](40) NOT NULL,
	[civiliteContact] [varchar](4) NOT NULL,
	[nomContact] [nvarchar](50) NOT NULL,
	[prenomContact] [nvarchar](50) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[adresse] [nvarchar](38) NOT NULL,
	[dateAdhesion] [datetime] NOT NULL,
 CONSTRAINT [PK_fournisseurs] PRIMARY KEY CLUSTERED 
(
	[idFournisseurs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lignesPaniersGlobaux]    Script Date: 08/02/2022 23:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lignesPaniersGlobaux](
	[idLignesPaniersGlobaux] [int] IDENTITY(1,1) NOT NULL,
	[idProduits] [int] NOT NULL,
	[quantite] [int] NULL,
	[idPaniersGlobaux] [int] NOT NULL,
	[idAdherents] [int] NOT NULL,
 CONSTRAINT [PK_LignesPaniersGlobaux] PRIMARY KEY CLUSTERED 
(
	[idLignesPaniersGlobaux] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[offres]    Script Date: 08/02/2022 23:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[offres](
	[idFournisseurs] [int] NOT NULL,
	[idPaniersGlobaux] [int] NOT NULL,
	[prix] [real] NOT NULL,
	[quantite] [int] NOT NULL,
	[idOffres] [int] IDENTITY(1,1) NOT NULL,
	[idProduits] [int] NOT NULL,
	[gagne] [bit] NOT NULL,
 CONSTRAINT [PK_offres] PRIMARY KEY CLUSTERED 
(
	[idOffres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paniersGlobaux]    Script Date: 08/02/2022 23:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paniersGlobaux](
	[idPaniersGlobaux] [int] IDENTITY(1,1) NOT NULL,
	[numeroSemaine] [int] NOT NULL,
	[annee] [int] NOT NULL,
	[cloture] [bit] NOT NULL,
 CONSTRAINT [PK_PanierGlobal] PRIMARY KEY CLUSTERED 
(
	[idPaniersGlobaux] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produits]    Script Date: 08/02/2022 23:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produits](
	[idProduits] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](200) NOT NULL,
	[marque] [nvarchar](200) NOT NULL,
	[reference] [varchar](50) NOT NULL,
	[disponible] [bit] NOT NULL,
 CONSTRAINT [PK_produit] PRIMARY KEY CLUSTERED 
(
	[idProduits] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[paniersGlobaux] ADD  CONSTRAINT [DF_paniersGlobaux_cloture]  DEFAULT ((0)) FOR [cloture]
GO
ALTER TABLE [dbo].[assoProduitsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_AssoProduitsFournisseurs_fournisseurs] FOREIGN KEY([idFournisseurs])
REFERENCES [dbo].[fournisseurs] ([idFournisseurs])
GO
ALTER TABLE [dbo].[assoProduitsFournisseurs] CHECK CONSTRAINT [FK_AssoProduitsFournisseurs_fournisseurs]
GO
ALTER TABLE [dbo].[assoProduitsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_AssoProduitsFournisseurs_produits] FOREIGN KEY([idProduits])
REFERENCES [dbo].[produits] ([idProduits])
GO
ALTER TABLE [dbo].[assoProduitsFournisseurs] CHECK CONSTRAINT [FK_AssoProduitsFournisseurs_produits]
GO
ALTER TABLE [dbo].[lignesPaniersGlobaux]  WITH CHECK ADD  CONSTRAINT [FK_lignesPaniersGlobaux_adherents] FOREIGN KEY([idAdherents])
REFERENCES [dbo].[adherents] ([idAdherents])
GO
ALTER TABLE [dbo].[lignesPaniersGlobaux] CHECK CONSTRAINT [FK_lignesPaniersGlobaux_adherents]
GO
ALTER TABLE [dbo].[lignesPaniersGlobaux]  WITH CHECK ADD  CONSTRAINT [FK_LignesPaniersGlobaux_PanierGlobal] FOREIGN KEY([idPaniersGlobaux])
REFERENCES [dbo].[paniersGlobaux] ([idPaniersGlobaux])
GO
ALTER TABLE [dbo].[lignesPaniersGlobaux] CHECK CONSTRAINT [FK_LignesPaniersGlobaux_PanierGlobal]
GO
ALTER TABLE [dbo].[lignesPaniersGlobaux]  WITH CHECK ADD  CONSTRAINT [FK_LignesPaniersGlobaux_produit] FOREIGN KEY([idProduits])
REFERENCES [dbo].[produits] ([idProduits])
GO
ALTER TABLE [dbo].[lignesPaniersGlobaux] CHECK CONSTRAINT [FK_LignesPaniersGlobaux_produit]
GO
ALTER TABLE [dbo].[offres]  WITH CHECK ADD  CONSTRAINT [FK_offres_fournisseurs] FOREIGN KEY([idFournisseurs])
REFERENCES [dbo].[fournisseurs] ([idFournisseurs])
GO
ALTER TABLE [dbo].[offres] CHECK CONSTRAINT [FK_offres_fournisseurs]
GO
ALTER TABLE [dbo].[offres]  WITH CHECK ADD  CONSTRAINT [FK_offres_paniersGlobaux1] FOREIGN KEY([idPaniersGlobaux])
REFERENCES [dbo].[paniersGlobaux] ([idPaniersGlobaux])
GO
ALTER TABLE [dbo].[offres] CHECK CONSTRAINT [FK_offres_paniersGlobaux1]
GO
ALTER TABLE [dbo].[offres]  WITH CHECK ADD  CONSTRAINT [FK_offres_produits] FOREIGN KEY([idProduits])
REFERENCES [dbo].[produits] ([idProduits])
GO
ALTER TABLE [dbo].[offres] CHECK CONSTRAINT [FK_offres_produits]
GO
USE [master]
GO
ALTER DATABASE [EMI-R] SET  READ_WRITE 
GO
