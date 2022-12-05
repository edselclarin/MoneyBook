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

-- Create AccountTypes table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AccountTypes' and xtype='U')
BEGIN
	CREATE TABLE AccountTypes (
		AcctTypeId INT NOT NULL,
		TypeName VARCHAR(128) NOT NULL DEFAULT('New AccountType')
	);

	INSERT INTO AccountTypes 
		(AcctTypeId, TypeName)
	VALUES 
		(1, 'CHECKING');

	INSERT INTO AccountTypes 
		(AcctTypeId, TypeName)
	VALUES 
		(2, 'SAVINGS');
END

-- Create Accounts table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' and xtype='U')
BEGIN
	CREATE TABLE [Accounts] (
		[AcctId] INT PRIMARY KEY IDENTITY (1, 1),
		[Name] VARCHAR(64) NOT NULL DEFAULT('ACCT'),
		[Description] VARCHAR (128) DEFAULT(''),
		[AcctType] VARCHAR (128) NOT NULL DEFAULT('SAVINGS'),
		[AcctTypeId] INT NOT NULL DEFAULT(1),
		[StartingBalance] DECIMAL(10, 2) NOT NULL DEFAULT(0.00),
		[ReserveAmount] DECIMAL(10, 2) NOT NULL DEFAULT(0.00),
		[DateAdded] DATE NOT NULL DEFAULT(GETDATE()),
		[DateModified] DATE NOT NULL DEFAULT(GETDATE()),
		[ExtAcctId] VARCHAR (128) NOT NULL DEFAULT(''),
		[InstId] INT NOT NULL DEFAULT(0),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFCHK', 'Checking', 'CHECKING', 1, 0.00, '70', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFSAV1', 'Primary Savings', 'SAVINGS', 2, 5.00, '01', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFSAV2', 'Secondary Savings', 'SAVINGS', 2, 5.00, '02', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFSAV3-ED', 'Personal Savings', 'SAVINGS', 2, 5.00, '03', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SFSAV5-CP', 'Cal Poly Savings', 'SAVINGS', 2, 5.00, '01', 1);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId]) 
	VALUES (
		'SUMMERSAVER', 'Summer Saver Savings', 'SAVINGS', 2, 0.00, '20', 1);
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
		[State] VARCHAR(32) NOT NULL DEFAULT('Uncleared'),
		[Amount] DECIMAL(10, 2) NOT NULL DEFAULT(0.00),
		[ExtTrnsId] VARCHAR(128) DEFAULT(''),
		[DateAdded] DATE NOT NULL DEFAULT(GETDATE()),
		[DateModified] DATE NOT NULL DEFAULT(GETDATE()),
		[AcctId] INT NOT NULL DEFAULT(0),
		[CatId] INT NOT NULL DEFAULT(0),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	)
	END

-- Create Transactions table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='RecurringTransactions' and xtype='U')
BEGIN
	CREATE TABLE [RecurringTransactions] (
		[RecTrnsId] INT PRIMARY KEY IDENTITY (1, 1),
		[DueDate] DATE NOT NULL DEFAULT(GETDATE()),
		[TrnsType] VARCHAR(16) NOT NULL DEFAULT('DEBIT'),
		[Payee] VARCHAR(128) NOT NULL DEFAULT(''),
		[Memo] VARCHAR(256) DEFAULT(''),
		[Website] VARCHAR(256) DEFAULT(''),
		[Amount] DECIMAL(10, 2) NOT NULL DEFAULT(0.00),
		[Frequency] VARCHAR(256) DEFAULT('Once'),
		[DateAdded] DATE NOT NULL DEFAULT(GETDATE()),
		[DateModified] DATE NOT NULL DEFAULT(GETDATE()),
		[AcctId] INT NOT NULL DEFAULT(0),
		[CatId] INT NOT NULL DEFAULT(0),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	)
	END

