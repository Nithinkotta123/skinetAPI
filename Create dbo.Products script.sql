USE [ProductDB]
GO

/****** Object: Table [dbo].[Products] Script Date: 09/02/2020 5:21:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL
);

SET IDENTITY_INSERT Products ON

INSERT INTO Products(Id,Name) values (1, 'Product one')
INSERT INTO Products(Id,Name) values (2, 'Product Two')
INSERT INTO Products(Id,Name) values (3, 'Product Three')

SET IDENTITY_INSERT Products OFF