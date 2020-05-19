
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2020 12:29:12
-- Generated from EDMX file: C:\Users\Monges\source\repos\raph901\Bio_Tourist\Bio-Tourist\Models\crud_seller.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BioTourist];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ID_PRODUCT]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_AD] DROP CONSTRAINT [FK_ID_PRODUCT];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[T_AD]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_AD];
GO
IF OBJECT_ID(N'[dbo].[T_PRODUCT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_PRODUCT];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T_AD'
CREATE TABLE [dbo].[T_AD] (
    [ID_AD] int IDENTITY(1,1) NOT NULL,
    [PICTURES_AD] varchar(500)  NOT NULL,
    [TITLE_AD] varchar(500)  NOT NULL,
    [NAME_AD] varchar(200)  NOT NULL,
    [PRICE_AD] float  NOT NULL,
    [ADRESS_AD] varchar(400)  NOT NULL,
    [DESCRIPTION_AD] varchar(600)  NOT NULL,
    [ID_USER] int  NOT NULL,
    [STOCK_AD] int  NOT NULL,
    [ID_PRODUCT] int  NOT NULL,
    [CITY_AD] varchar(200)  NOT NULL,
    [COUNTRY_AD] varchar(200)  NOT NULL,
    [DATE_AD] datetime  NOT NULL
);
GO

-- Creating table 'T_PRODUCT'
CREATE TABLE [dbo].[T_PRODUCT] (
    [ID_PRODUCT] int IDENTITY(1,1) NOT NULL,
    [CATEGORIE_PRODUCT] varchar(100)  NOT NULL,
    [QUANTITE_PRODUCT] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID_AD] in table 'T_AD'
ALTER TABLE [dbo].[T_AD]
ADD CONSTRAINT [PK_T_AD]
    PRIMARY KEY CLUSTERED ([ID_AD] ASC);
GO

-- Creating primary key on [ID_PRODUCT] in table 'T_PRODUCT'
ALTER TABLE [dbo].[T_PRODUCT]
ADD CONSTRAINT [PK_T_PRODUCT]
    PRIMARY KEY CLUSTERED ([ID_PRODUCT] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ID_PRODUCT] in table 'T_AD'
ALTER TABLE [dbo].[T_AD]
ADD CONSTRAINT [FK_ID_PRODUCT]
    FOREIGN KEY ([ID_PRODUCT])
    REFERENCES [dbo].[T_PRODUCT]
        ([ID_PRODUCT])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ID_PRODUCT'
CREATE INDEX [IX_FK_ID_PRODUCT]
ON [dbo].[T_AD]
    ([ID_PRODUCT]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------