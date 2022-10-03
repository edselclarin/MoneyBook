-- Create database.

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'MoneyBook')
BEGIN
	CREATE DATABASE [MoneyBook];
END

USE [MoneyBook]
GO

-- Create Categories table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Categories' and xtype='U')
BEGIN
	CREATE TABLE [Categories] (
		[CatId] INT PRIMARY KEY IDENTITY (1, 1),
		[Name] VARCHAR(128) NOT NULL DEFAULT('Unknown Category'),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	)
END

-- Create Institutions table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Institutions' and xtype='U')
BEGIN
	CREATE TABLE [Institutions] (
		[InstId] INT PRIMARY KEY IDENTITY (1, 1),
		[Name] VARCHAR(128) NOT NULL DEFAULT('Unknown Institution'),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	);
	INSERT INTO [Institutions]([Name]) VALUES('SchoolsFirst FCU');
END

-- Create Accounts table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' and xtype='U')
BEGIN
	CREATE TABLE [Accounts] (
		[AcctId] INT PRIMARY KEY IDENTITY (1, 1),
		[Name] VARCHAR(64) NOT NULL DEFAULT('ACCT'),
		[Description] VARCHAR (128) NOT NULL DEFAULT(''),
		[ExtAcctId] VARCHAR (128) NOT NULL DEFAULT(''),
		[InstId] INT NOT NULL DEFAULT(0),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	);

	INSERT INTO [Accounts]([Name],[ExtAcctId],[Description],[InstId]) VALUES('SFCHK', '70', 'SchoolsFirst FCU - Checking', 1);
	INSERT INTO [Accounts]([Name],[ExtAcctId],[Description],[InstId]) VALUES('SFSAV1', '01', 'SchoolsFirst FCU - Primary Savings', 1);
	INSERT INTO [Accounts]([Name],[ExtAcctId],[Description],[InstId]) VALUES('SFSAV2', '02', 'SchoolsFirst FCU - Secondary Savings', 1);
	INSERT INTO [Accounts]([Name],[ExtAcctId],[Description],[InstId]) VALUES('SFSAV3-ED', '03', 'SchoolsFirst FCU - Personal Savings', 1);
	INSERT INTO [Accounts]([Name],[ExtAcctId],[Description],[InstId]) VALUES('SFSAV4-CP', '01', 'SchoolsFirst FCU - Cal Poly Checking', 1);
	INSERT INTO [Accounts]([Name],[ExtAcctId],[Description],[InstId]) VALUES('SUMMERSAVER', '20', 'SchoolsFirst FCU - Summer Saver Savings', 1);
END

-- Create Transactions table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Transactions' and xtype='U')
BEGIN
	CREATE TABLE [Transactions] (
		[TrnsId] INT PRIMARY KEY IDENTITY (1, 1),
		[Date] DATE NOT NULL DEFAULT(GETDATE()),
		[TrnsType] VARCHAR(16) NOT NULL DEFAULT('DEBIT'),
		[RefNum] VARCHAR(128) DEFAULT(''),
		[Payee] VARCHAR(128) NOT NULL DEFAULT(''),
		[Memo] VARCHAR(256) DEFAULT(''),
		[State] VARCHAR(2) NOT NULL DEFAULT('U'),
		[Amount] DECIMAL(10, 2) NOT NULL DEFAULT(0.00),
		[ExtTrnsId] VARCHAR(128) DEFAULT(''),
		[InstId] INT NOT NULL DEFAULT(0),
		[AcctId] INT NOT NULL DEFAULT(0),
		[CatId] INT NOT NULL DEFAULT(0),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	)
	END

USE [MoneyBook];
GO

CREATE VIEW [GetAccountDetail] AS
	SELECT 
		A.*,
		I.[Name] as InstName
	FROM 
		[dbo].[Accounts] A
	INNER JOIN
		[dbo].[Institutions] I on A.[InstId] = I.[InstId]
