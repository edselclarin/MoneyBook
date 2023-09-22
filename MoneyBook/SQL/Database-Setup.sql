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
		[ImportFilePath] VARCHAR(64) DEFAULT(''),
		[IsDeleted] BIT NOT NULL DEFAULT(CONVERT(BIT, 0))
	);

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId], [ImportFilePath]) 
	VALUES (
		'SFCHK', 'Checking', 'CHECKING', 1, 0.00, '70', 1, 'C:\Users\Edsel\Downloads\transactions.qfx');

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId], [ImportFilePath]) 
	VALUES (
		'SFSAV1', 'Primary Savings', 'SAVINGS', 2, 5.00, '01', 1, 'C:\Users\Edsel\Downloads\transactions(1).qfx');

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId], [ImportFilePath]) 
	VALUES (
		'SFSAV2', 'Secondary Savings', 'SAVINGS', 2, 5.00, '02', 1, 'C:\Users\Edsel\Downloads\transactions(2).qfx');

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId], [ImportFilePath]) 
	VALUES (
		'SFSAV3-ED', 'Personal Savings', 'SAVINGS', 2, 5.00, '03', 1, 'C:\Users\Edsel\Downloads\transactions(3).qfx');

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId], [ImportFilePath]) 
	VALUES (
		'SFSAV5-CP', 'Cal Poly Savings', 'SAVINGS', 2, 5.00, '01', 1, 'C:\Users\Edsel\Downloads\transactions(4).qfx');

	INSERT INTO [Accounts](
		[Name], [Description], [AcctType], [AcctTypeId], [ReserveAmount], [ExtAcctId], [InstId], [ImportFilePath]) 
	VALUES (
		'SUMMERSAVER', 'Summer Saver Savings', 'SAVINGS', 2, 0.00, '20', 1, 'C:\Users\Edsel\Downloads\transactions(5).qfx');
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

-- Create Reminders table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Reminders' and xtype='U')
BEGIN
	CREATE TABLE [Reminders] (
		[RmdrId] INT PRIMARY KEY IDENTITY (1, 1),
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

GO

CREATE VIEW TransactionSummaries AS
SELECT AcctId,
       Credits,
       Debits,
	   Credits - Debits as Total,
       StagedCredits,
       StagedDebits,
       StagedCredits - StagedDebits AS StagedTotal
FROM (
    SELECT AcctId,
           SUM(CASE WHEN TrnsType = 'DEBIT'  AND State != 'Ignored' THEN Amount ELSE 0 END) AS Debits,
           SUM(CASE WHEN TrnsType = 'CREDIT' AND State != 'Ignored' THEN Amount ELSE 0 END) AS Credits,
           SUM(CASE WHEN TrnsType = 'DEBIT'  AND State = 'Staged' THEN Amount ELSE 0 END) AS StagedDebits,
           SUM(CASE WHEN TrnsType = 'CREDIT' AND State = 'Staged' THEN Amount ELSE 0 END) AS StagedCredits
    FROM Transactions
    WHERE IsDeleted = CONVERT(BIT, 0)
    GROUP BY AcctId
) AS Totals;

GO

CREATE VIEW AccountSummaries AS
select  a.*,
		t.Credits,
		t.Debits,
		t.Total,
		t.StagedCredits,
		t.StagedDebits,
		t.StagedTotal,
		a.StartingBalance + t.Total - t.StagedTotal as Balance,
		a.StartingBalance + t.Total - t.StagedTotal - a.ReserveAmount as AvailableBalance,
		a.StartingBalance + t.Total - a.ReserveAmount as FinalBalance		
from Accounts a, TransactionSummaries t
where a.AcctId = t.AcctId and a.IsDeleted = CONVERT(BIT, 0)

