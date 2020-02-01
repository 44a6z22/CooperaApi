
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2020 16:08:31
-- Generated from EDMX file: C:\Users\Youcode\source\repos\CooperaApi\Coopera.Data\CoopDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Coop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FKCommandes456662]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Commandes] DROP CONSTRAINT [FK_FKCommandes456662];
GO
IF OBJECT_ID(N'[dbo].[FK_FKCommandes811927]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Commandes] DROP CONSTRAINT [FK_FKCommandes811927];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDetails co486043]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Details commande] DROP CONSTRAINT [FK_FKDetails co486043];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDetails co934420]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Details commande] DROP CONSTRAINT [FK_FKDetails co934420];
GO
IF OBJECT_ID(N'[dbo].[FK_FKFilliers110136]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Filliers] DROP CONSTRAINT [FK_FKFilliers110136];
GO
IF OBJECT_ID(N'[dbo].[FK_FKFilliers946845]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Filliers] DROP CONSTRAINT [FK_FKFilliers946845];
GO
IF OBJECT_ID(N'[dbo].[FK_FKImages541097]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_FKImages541097];
GO
IF OBJECT_ID(N'[dbo].[FK_FKProduits456164]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Produits] DROP CONSTRAINT [FK_FKProduits456164];
GO
IF OBJECT_ID(N'[dbo].[FK_FKProduits803246]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Produits] DROP CONSTRAINT [FK_FKProduits803246];
GO
IF OBJECT_ID(N'[dbo].[FK_FKreviews448794]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[reviews] DROP CONSTRAINT [FK_FKreviews448794];
GO
IF OBJECT_ID(N'[dbo].[FK_FKreviews90585]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[reviews] DROP CONSTRAINT [FK_FKreviews90585];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Commandes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Commandes];
GO
IF OBJECT_ID(N'[dbo].[Details commande]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Details commande];
GO
IF OBJECT_ID(N'[dbo].[Filliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Filliers];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Produits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produits];
GO
IF OBJECT_ID(N'[dbo].[reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[reviews];
GO
IF OBJECT_ID(N'[dbo].[secteurDactivite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[secteurDactivite];
GO
IF OBJECT_ID(N'[dbo].[status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[status];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Commandes'
CREATE TABLE [dbo].[Commandes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [statusId] int  NOT NULL,
    [UsersId] int  NOT NULL,
    [DateCreation] datetime  NULL,
    [DateLivraison] datetime  NULL
);
GO

-- Creating table 'Details_commande'
CREATE TABLE [dbo].[Details_commande] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [TotalPrice] real  NOT NULL,
    [ProduitsId] int  NOT NULL,
    [CommandesId] int  NOT NULL,
    [Sub_total] real  NULL
);
GO

-- Creating table 'Filliers'
CREATE TABLE [dbo].[Filliers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FilliersId] int  NULL,
    [secteurDactiviteId] int  NOT NULL,
    [Name] varchar(255)  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProduitsId] int  NOT NULL,
    [Path] varchar(255)  NULL
);
GO

-- Creating table 'Produits'
CREATE TABLE [dbo].[Produits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsersId] int  NOT NULL,
    [FilliersId] int  NOT NULL,
    [Name] varchar(255)  NULL,
    [Price] real  NOT NULL
);
GO

-- Creating table 'reviews'
CREATE TABLE [dbo].[reviews] (
    [UsersId] int  NOT NULL,
    [ProduitsId] int  NOT NULL,
    [Content] varchar(255)  NULL,
    [Rating] real  NOT NULL
);
GO

-- Creating table 'secteurDactivite'
CREATE TABLE [dbo].[secteurDactivite] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NULL
);
GO

-- Creating table 'status'
CREATE TABLE [dbo].[status] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(255)  NULL,
    [PassWord] varchar(255)  NULL,
    [Email] varchar(255)  NULL,
    [Name] varchar(255)  NULL,
    [Adress] varchar(255)  NULL,
    [PhoneNumber] varchar(255)  NULL,
    [IsDeleted] bit  NOT NULL,
    [IsActivated] bit  NOT NULL,
    [Matricule] varchar(255)  NULL,
    [Discriminator] varchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Commandes'
ALTER TABLE [dbo].[Commandes]
ADD CONSTRAINT [PK_Commandes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Details_commande'
ALTER TABLE [dbo].[Details_commande]
ADD CONSTRAINT [PK_Details_commande]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Filliers'
ALTER TABLE [dbo].[Filliers]
ADD CONSTRAINT [PK_Filliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [PK_Produits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UsersId], [ProduitsId] in table 'reviews'
ALTER TABLE [dbo].[reviews]
ADD CONSTRAINT [PK_reviews]
    PRIMARY KEY CLUSTERED ([UsersId], [ProduitsId] ASC);
GO

-- Creating primary key on [Id] in table 'secteurDactivite'
ALTER TABLE [dbo].[secteurDactivite]
ADD CONSTRAINT [PK_secteurDactivite]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'status'
ALTER TABLE [dbo].[status]
ADD CONSTRAINT [PK_status]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [statusId] in table 'Commandes'
ALTER TABLE [dbo].[Commandes]
ADD CONSTRAINT [FK_FKCommandes456662]
    FOREIGN KEY ([statusId])
    REFERENCES [dbo].[status]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKCommandes456662'
CREATE INDEX [IX_FK_FKCommandes456662]
ON [dbo].[Commandes]
    ([statusId]);
GO

-- Creating foreign key on [UsersId] in table 'Commandes'
ALTER TABLE [dbo].[Commandes]
ADD CONSTRAINT [FK_FKCommandes811927]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKCommandes811927'
CREATE INDEX [IX_FK_FKCommandes811927]
ON [dbo].[Commandes]
    ([UsersId]);
GO

-- Creating foreign key on [CommandesId] in table 'Details_commande'
ALTER TABLE [dbo].[Details_commande]
ADD CONSTRAINT [FK_FKDetails_co934420]
    FOREIGN KEY ([CommandesId])
    REFERENCES [dbo].[Commandes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKDetails_co934420'
CREATE INDEX [IX_FK_FKDetails_co934420]
ON [dbo].[Details_commande]
    ([CommandesId]);
GO

-- Creating foreign key on [ProduitsId] in table 'Details_commande'
ALTER TABLE [dbo].[Details_commande]
ADD CONSTRAINT [FK_FKDetails_co486043]
    FOREIGN KEY ([ProduitsId])
    REFERENCES [dbo].[Produits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKDetails_co486043'
CREATE INDEX [IX_FK_FKDetails_co486043]
ON [dbo].[Details_commande]
    ([ProduitsId]);
GO

-- Creating foreign key on [FilliersId] in table 'Filliers'
ALTER TABLE [dbo].[Filliers]
ADD CONSTRAINT [FK_FKFilliers110136]
    FOREIGN KEY ([FilliersId])
    REFERENCES [dbo].[Filliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKFilliers110136'
CREATE INDEX [IX_FK_FKFilliers110136]
ON [dbo].[Filliers]
    ([FilliersId]);
GO

-- Creating foreign key on [secteurDactiviteId] in table 'Filliers'
ALTER TABLE [dbo].[Filliers]
ADD CONSTRAINT [FK_FKFilliers946845]
    FOREIGN KEY ([secteurDactiviteId])
    REFERENCES [dbo].[secteurDactivite]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKFilliers946845'
CREATE INDEX [IX_FK_FKFilliers946845]
ON [dbo].[Filliers]
    ([secteurDactiviteId]);
GO

-- Creating foreign key on [FilliersId] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [FK_FKProduits803246]
    FOREIGN KEY ([FilliersId])
    REFERENCES [dbo].[Filliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKProduits803246'
CREATE INDEX [IX_FK_FKProduits803246]
ON [dbo].[Produits]
    ([FilliersId]);
GO

-- Creating foreign key on [ProduitsId] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_FKImages541097]
    FOREIGN KEY ([ProduitsId])
    REFERENCES [dbo].[Produits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKImages541097'
CREATE INDEX [IX_FK_FKImages541097]
ON [dbo].[Images]
    ([ProduitsId]);
GO

-- Creating foreign key on [UsersId] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [FK_FKProduits456164]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKProduits456164'
CREATE INDEX [IX_FK_FKProduits456164]
ON [dbo].[Produits]
    ([UsersId]);
GO

-- Creating foreign key on [ProduitsId] in table 'reviews'
ALTER TABLE [dbo].[reviews]
ADD CONSTRAINT [FK_FKreviews90585]
    FOREIGN KEY ([ProduitsId])
    REFERENCES [dbo].[Produits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKreviews90585'
CREATE INDEX [IX_FK_FKreviews90585]
ON [dbo].[reviews]
    ([ProduitsId]);
GO

-- Creating foreign key on [UsersId] in table 'reviews'
ALTER TABLE [dbo].[reviews]
ADD CONSTRAINT [FK_FKreviews448794]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------