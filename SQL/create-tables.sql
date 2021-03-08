CREATE TABLE [dbo].[CategoryTypes] (
    [CTID] INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CTID] ASC)
);
GO

CREATE TABLE [dbo].[FlowTypes] (
    [FTID] INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([FTID] ASC)
);
GO

CREATE TABLE [dbo].[StateTypes] (
    [STID]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (50) NOT NULL,
    [Alias] NCHAR (10)    NOT NULL,
    PRIMARY KEY CLUSTERED ([STID] ASC)
);
GO

CREATE TABLE [dbo].[AccountTypes] (
    [ATID] INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ATID] ASC)
);
GO

CREATE TABLE [dbo].[Accounts] (
    [AID]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NOT NULL,
    [ATID]   INT           DEFAULT ((0)) NOT NULL,
    [FTID]   INT           DEFAULT ((0)) NOT NULL,
    [Hidden] BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([AID] ASC),
    CONSTRAINT [FK_Accounts_AccountTypes] FOREIGN KEY ([ATID]) REFERENCES [dbo].[AccountTypes] ([ATID]),
    CONSTRAINT [FK_Accounts_FlowTypes] FOREIGN KEY ([FTID]) REFERENCES [dbo].[FlowTypes] ([FTID])
);
GO

CREATE TABLE [dbo].[Transactions] (
    [TID]      INT           IDENTITY (1, 1) NOT NULL,
    [Date]     DATETIME      NOT NULL,
    [Payee]    NVARCHAR (50) NULL,
    [Memo]     NVARCHAR (50) NULL,
    [CTID]     INT           DEFAULT ((0)) NOT NULL,
    [CheckNum] NVARCHAR (50) NULL,
    [Amount]   DECIMAL (18)  NOT NULL,
    [AID]      INT           DEFAULT ((0)) NOT NULL,
    [STID]     INT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([TID] ASC),
    CONSTRAINT [FK_Transactions_To_Accounts] FOREIGN KEY ([AID]) REFERENCES [dbo].[Accounts] ([AID]),
    CONSTRAINT [FK_Transactions_To_StateTypes] FOREIGN KEY ([STID]) REFERENCES [dbo].[StateTypes] ([STID])
);
GO
