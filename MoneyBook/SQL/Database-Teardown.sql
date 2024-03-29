IF EXISTS(SELECT * FROM sys.databases WHERE name = 'MoneyBook')
BEGIN
	USE [MoneyBook]

	-- Drop Reminders table.
	IF EXISTS (SELECT * FROM sysobjects WHERE name='Reminders' and xtype='U')
	BEGIN
		DROP TABLE [Reminders]
	END

	-- Drop Transactions table.
	IF EXISTS (SELECT * FROM sysobjects WHERE name='Transactions' and xtype='U')
	BEGIN
		DROP TABLE [Transactions]
	END

	-- Drop Categories table.
	IF EXISTS (SELECT * FROM sysobjects WHERE name='Categories' and xtype='U')
	BEGIN
		DROP TABLE [Categories]
	END

	-- Drop Accounts table.
	IF EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' and xtype='U')
	BEGIN
		DROP TABLE [Accounts]
	END

	-- Drop Institutions table.
	IF EXISTS (SELECT * FROM sysobjects WHERE name='Institutions' and xtype='U')
	BEGIN
		DROP TABLE [Institutions]
	END
END

-- Drop database.
USE [tempdb]
GO
DECLARE @SQL nvarchar(1000);
IF EXISTS (SELECT 1 FROM sys.databases WHERE [name] = 'MoneyBook')
BEGIN
    SET @SQL = 'USE [MoneyBook];
                ALTER DATABASE [MoneyBook] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                USE [tempdb];
                DROP DATABASE [MoneyBook];';
    EXEC (@SQL);
END;

/*
USE [MoneyBook];
DELETE FROM [Transactions];

USE [MoneyBook];
UPDATE [Accounts] SET [StartingBalance] = 0.00;

*/