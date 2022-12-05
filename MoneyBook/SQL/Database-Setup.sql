
-- Create database.
USE master;
GO
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'money_book')
BEGIN
	CREATE DATABASE money_book;
END

-- Drop all tables.
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'money_book')
BEGIN
	DROP VIEW account_detail;
	DROP VIEW account_transaction_detail;
	DROP TABLE account_types;
	DROP TABLE frequency_types;
	DROP TABLE transaction_types;
	DROP TABLE state_types;
	DROP TABLE categories;
	DROP TABLE institutions;
	DROP TABLE accounts;
	DROP TABLE transactions;
	DROP TABLE reminders;
END

USE money_book
GO

-- Create account_types table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='account_types' and xtype='U')
BEGIN
	CREATE TABLE account_types (
		pk_acct_type_id INT NOT NULL,
		acct_type_name NVARCHAR(48) NOT NULL DEFAULT('New')
	);

	INSERT INTO account_types
		(pk_acct_type_id, acct_type_name)
	VALUES
		(1, 'CHECKING');

	INSERT INTO 
		account_types(pk_acct_type_id, acct_type_name)
	VALUES
		(2, 'SAVINGS');
END

-- Create frequency_types table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='frequency_types' and xtype='U')
BEGIN
	CREATE TABLE frequency_types (
		pk_freq_type_id INT NOT NULL,
		freq_type_name NVARCHAR(48) NOT NULL DEFAULT('New')
	);

	INSERT INTO frequency_types
		(pk_freq_type_id, freq_type_name)
	VALUES
		(1, 'Once');

	INSERT INTO frequency_types
		(pk_freq_type_id, freq_type_name)
	VALUES
		(2, 'Weekly');

	INSERT INTO frequency_types
		(pk_freq_type_id, freq_type_name)
	VALUES
		(3, 'BiWeekly');

	INSERT INTO frequency_types
		(pk_freq_type_id, freq_type_name)
	VALUES
		(4, 'Monthly');

	INSERT INTO frequency_types
		(pk_freq_type_id, freq_type_name)
	VALUES
		(5, 'Quarterly');

	INSERT INTO frequency_types
		(pk_freq_type_id, freq_type_name)
	VALUES
		(6, 'Yearly');
END

-- Create transaction_types table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='transaction_types' and xtype='U')
BEGIN
	CREATE TABLE transaction_types (
		pk_tran_type_id INT NOT NULL,
		tran_type_name NVARCHAR(48) NOT NULL DEFAULT('New')
	);

	INSERT INTO transaction_types
		(pk_tran_type_id, tran_type_name)
	VALUES
		(1, 'DEBIT');

	INSERT INTO transaction_types
		(pk_tran_type_id, tran_type_name)
	VALUES
		(2, 'CREDIT');
END

-- Create state_types table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='state_types' and xtype='U')
BEGIN
	CREATE TABLE state_types (
		pk_state_type_id INT NOT NULL,
		state_type_name NVARCHAR(48) NOT NULL DEFAULT('New'),
		state_type_description NVARCHAR(128) NOT NULL DEFAULT('')
	);

	INSERT INTO state_types
		(pk_state_type_id, state_type_name, state_type_description)
	VALUES
		(1, 'New', 'Newly added or imported.');

	INSERT INTO state_types
		(pk_state_type_id, state_type_name, state_type_description)
	VALUES
		(1, 'Staged', 'Projected transaction, not yet registered at institution.');

	INSERT INTO state_types
		(pk_state_type_id, state_type_name, state_type_description)
	VALUES
		(1, 'Reconciled', 'Matches with transaction at institution.');

	INSERT INTO state_types
		(pk_state_type_id, state_type_name, state_type_description)
	VALUES
		(1, 'Ignored', 'Exclude from balance calculations.');
END

-- Create categories table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='categories' and xtype='U')
BEGIN
	CREATE TABLE categories
	(
		pk_cat_id INT NOT NULL,
		cat_name NVARCHAR(48) NOT NULL DEFAULT('New'),
		cat_description NVARCHAR(128) NOT NULL DEFAULT('')
	);

	INSERT INTO categories 
		(pk_cat_id, cat_name)
	VALUES 
		(1, 'Uncategorized');
END

-- Create institutions table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='institutions' and xtype='U')
BEGIN
	CREATE TABLE institutions (
		pk_inst_id INT NOT NULL,
		inst_name NVARCHAR(48) NOT NULL DEFAULT('New'),
		inst_description NVARCHAR(128) NOT NULL DEFAULT('')
	);

	INSERT INTO institutions 
		(pk_inst_id, inst_name, inst_description)
	VALUES 
		(1, 'SchoolsFirst FCU', 'CREDIT UNION');
END

-- Create accounts table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='accounts' and xtype='U')
BEGIN
	CREATE TABLE accounts (
		pk_acct_id INT PRIMARY KEY IDENTITY (1, 1),
		acct_name NVARCHAR(64) NOT NULL DEFAULT('ACCT'),
		acct_description NVARCHAR (64) DEFAULT(''),
		starting_balance DECIMAL(18, 4) NOT NULL DEFAULT(0.0000),
		reserve_amount DECIMAL(18, 4) NOT NULL DEFAULT(0.0000),
		credits DECIMAL(18, 4) NOT NULL DEFAULT (0.00),
		debits DECIMAL(18, 4) NOT NULL DEFAULT (0.00),
		balance DECIMAL(18, 4) NOT NULL DEFAULT (0.00),
		available_balance DECIMAL(18, 4) NOT NULL DEFAULT (0.00),
		ext_acct_id NVARCHAR (128) NOT NULL DEFAULT(''),
		fk_acct_type_id INT NOT NULL DEFAULT(1),
		fk_inst_id INT NOT NULL DEFAULT(1)
	);

	INSERT INTO accounts
		(fk_acct_type_id, fk_inst_id, ext_acct_id, acct_name, acct_description)
	VALUES 
		(1, 1, '70', 'SFCHK', 'Checking');

	INSERT INTO accounts
		(fk_acct_type_id, fk_inst_id, ext_acct_id, acct_name, acct_description)
	VALUES 
		(2, 1, '01', 'SFSAV1', 'Primary Savings');

	INSERT INTO accounts
		(fk_acct_type_id, fk_inst_id, ext_acct_id, acct_name, acct_description)
	VALUES 
		(2, 1, '02', 'SFSAV2', 'Secondary Savings');

	INSERT INTO accounts
		(fk_acct_type_id, fk_inst_id, ext_acct_id, acct_name, acct_description)
	VALUES 
		(2, 1, '03', 'SFSAV3-ED', 'Personal Savings');

	INSERT INTO accounts
		(fk_acct_type_id, fk_inst_id, ext_acct_id, acct_name, acct_description)
	VALUES 
		(2, 1, '01', 'SFSAV5-CP', 'Cal Poly Savings');

	INSERT INTO accounts
		(fk_acct_type_id, fk_inst_id, ext_acct_id, acct_name, acct_description)
	VALUES 
		(2, 1, '20', 'SUMMERSAVER', 'Summer Saver Savings');
END

-- Create transactions table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='transactions' and xtype='U')
BEGIN
	CREATE TABLE transactions (
		pk_tran_id INT PRIMARY KEY IDENTITY (1, 1),
		tran_date DATE NOT NULL DEFAULT(GETDATE()),
		ref_num VARCHAR(128) DEFAULT(''),
		payee VARCHAR(128) NOT NULL DEFAULT(''),
		memo VARCHAR(256) DEFAULT(''),
		amount DECIMAL(18, 4) NOT NULL DEFAULT(0.0000),
		date_added DATE NOT NULL DEFAULT(GETDATE()),
		date_modified DATE NOT NULL DEFAULT(GETDATE()),
		ext_tran_id VARCHAR(128) DEFAULT(''),
		fk_acct_id INT NOT NULL DEFAULT(1),
		fk_cat_id INT NOT NULL DEFAULT(1),
		fk_tran_type_id INT NOT NULL DEFAULT(1),
		fk_state_type_id INT NOT NULL DEFAULT(1)
	);
END

-- Create reminders table.
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='reminders' and xtype='U')
BEGIN
	CREATE TABLE reminders (
		pk_reminder_id INT PRIMARY KEY IDENTITY (1, 1),
		due_Date DATE NOT NULL DEFAULT(GETDATE()),
		payee VARCHAR(128) NOT NULL DEFAULT(''),
		memo VARCHAR(256) DEFAULT(''),
		website VARCHAR(256) DEFAULT(''),
		amount DECIMAL(18, 4) NOT NULL DEFAULT(0.0000),
		date_added DATE NOT NULL DEFAULT(GETDATE()),
		date_modified DATE NOT NULL DEFAULT(GETDATE()),
		fk_acct_id INT NOT NULL DEFAULT(1),
		fk_cat_id INT NOT NULL DEFAULT(1),
		fk_tran_type_id INT NOT NULL DEFAULT(1),
		fk_freq_type_id INT NOT NULL DEFAULT(1)
	);
END

create view account_detail 
as
	select 
		pk_acct_id,
		acct_name,
		acct_description,
		starting_balance,
		reserve_amount,
		credits,
		debits,
		balance,
		available_balance,
		ext_acct_id,
		acct_type_name,
		inst_name,
		inst_description
	from accounts t1
	join account_types t2 on t2.pk_acct_type_id = t1.fk_acct_type_id
	join institutions t3 on t3.pk_inst_id = t1.fk_inst_id
go

create view account_transaction_detail 
as
	select
		pk_tran_id,
		tran_date,
		ref_num,
		payee,
		memo,
		amount,
		date_added,
		date_modified,
		ext_tran_id,
		fk_acct_id,
		acct_name,
		fk_cat_id,
		cat_name,
		fk_tran_type_id,
		tran_type_name,
		fk_state_type_id,
		state_type_name
	from transactions t1
	join accounts t2 on t2.pk_acct_id = t1.fk_acct_id
	join categories t3 on t3.pk_cat_id = t1.fk_cat_id
	join transaction_types t4 on t4.pk_tran_type_id = t1.fk_tran_type_id
	join state_types t5 on t5.pk_state_type_id = t1.fk_state_type_id
go

