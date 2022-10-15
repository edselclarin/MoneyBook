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
		[Name] VARCHAR(128) NOT NULL DEFAULT('New Category'),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	);

	INSERT INTO [Categories] (
		[Name])
	VALUES (
		'Uncategorized');
END

-- Create Institutions table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Institutions' and xtype='U')
BEGIN
	CREATE TABLE [Institutions] (
		[InstId] INT PRIMARY KEY IDENTITY (1, 1),
		[Name] VARCHAR(128) NOT NULL DEFAULT('New Institution'),
		[InstType] VARCHAR(128) NOT NULL DEFAULT('BANK'),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	);

	INSERT INTO [Institutions] (
		[Name], [InstType])
	VALUES (
		'SchoolsFirst FCU', 'CREDIT UNION');
END

-- Create Accounts table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' and xtype='U')
BEGIN
	CREATE TABLE [Accounts] (
		[AcctId] INT PRIMARY KEY IDENTITY (1, 1),
		[Name] VARCHAR(64) NOT NULL DEFAULT('ACCT'),
		[Description] VARCHAR (128) DEFAULT(''),
		[AcctType] VARCHAR (128) NOT NULL DEFAULT('SAVINGS'),
		[StartingBalance] DECIMAL(10, 2) NOT NULL DEFAULT(0.00),
		[ReserveAmount] DECIMAL(10, 2) NOT NULL DEFAULT(0.00),
		[Credits] DECIMAL(10, 2) NOT NULL DEFAULT (0),
		[Debits] DECIMAL(10, 2) NOT NULL DEFAULT (0),
		[Balance] DECIMAL(10, 2) NOT NULL DEFAULT (0),
		[AvailableBalance] DECIMAL(10, 2) NOT NULL DEFAULT (0),
		[DateAdded] DATE NOT NULL DEFAULT(GETDATE()),
		[DateModified] DATE NOT NULL DEFAULT(GETDATE()),
		[ExtAcctId] VARCHAR (128) NOT NULL DEFAULT(''),
		[InstId] INT NOT NULL DEFAULT(0),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFCHK', 'Checking', 'CHECKING', 0.00, '70', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFSAV1', 'Primary Savings', 'SAVINGS', 5.00, '01', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFSAV2', 'Secondary Savings', 'SAVINGS', 5.00, '02', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFSAV3-ED', 'Personal Savings', 'SAVINGS', 5.00, '03', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFSAV5-CP', 'Cal Poly Savings', 'SAVINGS', 5.00, '01', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SUMMERSAVER', 'Summer Saver Savings', 'SAVINGS', 0.00, '20', 1);
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
		[DateAdded] DATE NOT NULL DEFAULT(GETDATE()),
		[DateModified] DATE NOT NULL DEFAULT(GETDATE()),
		[InstId] INT NOT NULL DEFAULT(0),
		[AcctId] INT NOT NULL DEFAULT(0),
		[CatId] INT NOT NULL DEFAULT(0),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	)
	END
