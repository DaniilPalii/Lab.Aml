IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240831202330_Initialize'
)
BEGIN
    CREATE TABLE [Customers] (
        [Id] bigint NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [Birthdate] date NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240831202330_Initialize'
)
BEGIN
    CREATE TABLE [Transactions] (
        [Id] bigint NOT NULL IDENTITY,
        [Amount] decimal(18,2) NOT NULL,
        [Currency] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [CustomerId] bigint NOT NULL,
        [Customer] bigint NOT NULL,
        CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Transactions_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240831202330_Initialize'
)
BEGIN
    CREATE INDEX [IX_Transactions_CustomerId] ON [Transactions] ([CustomerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240831202330_Initialize'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240831202330_Initialize', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    ALTER TABLE [Transactions] DROP CONSTRAINT [FK_Transactions_Customers_CustomerId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Customer');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Transactions] DROP COLUMN [Customer];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Description');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [Description] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'CustomerId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [CustomerId] bigint NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Currency');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [Currency] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Amount');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [Amount] decimal(18,2) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Surname');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Customers] ALTER COLUMN [Surname] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Name');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Customers] ALTER COLUMN [Name] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Birthdate');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Customers] ALTER COLUMN [Birthdate] date NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Address');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Customers] ALTER COLUMN [Address] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    ALTER TABLE [Transactions] ADD CONSTRAINT [FK_Transactions_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240901093145_FixRelations'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240901093145_FixRelations', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Description');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var9 + '];');
    EXEC(N'UPDATE [Transactions] SET [Description] = N'''' WHERE [Description] IS NULL');
    ALTER TABLE [Transactions] ALTER COLUMN [Description] nvarchar(max) NOT NULL;
    ALTER TABLE [Transactions] ADD DEFAULT N'' FOR [Description];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Currency');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var10 + '];');
    EXEC(N'UPDATE [Transactions] SET [Currency] = 0 WHERE [Currency] IS NULL');
    ALTER TABLE [Transactions] ALTER COLUMN [Currency] int NOT NULL;
    ALTER TABLE [Transactions] ADD DEFAULT 0 FOR [Currency];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Amount');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var11 + '];');
    EXEC(N'UPDATE [Transactions] SET [Amount] = 0.0 WHERE [Amount] IS NULL');
    ALTER TABLE [Transactions] ALTER COLUMN [Amount] decimal(18,2) NOT NULL;
    ALTER TABLE [Transactions] ADD DEFAULT 0.0 FOR [Amount];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    ALTER TABLE [Transactions] ADD [CreationDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    ALTER TABLE [Transactions] ADD [IsSuspicious] bit NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    ALTER TABLE [Transactions] ADD [TransactionType] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Surname');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var12 + '];');
    EXEC(N'UPDATE [Customers] SET [Surname] = N'''' WHERE [Surname] IS NULL');
    ALTER TABLE [Customers] ALTER COLUMN [Surname] nvarchar(max) NOT NULL;
    ALTER TABLE [Customers] ADD DEFAULT N'' FOR [Surname];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Name');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var13 + '];');
    EXEC(N'UPDATE [Customers] SET [Name] = N'''' WHERE [Name] IS NULL');
    ALTER TABLE [Customers] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
    ALTER TABLE [Customers] ADD DEFAULT N'' FOR [Name];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Birthdate');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var14 + '];');
    EXEC(N'UPDATE [Customers] SET [Birthdate] = ''0001-01-01'' WHERE [Birthdate] IS NULL');
    ALTER TABLE [Customers] ALTER COLUMN [Birthdate] date NOT NULL;
    ALTER TABLE [Customers] ADD DEFAULT '0001-01-01' FOR [Birthdate];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Address');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var15 + '];');
    EXEC(N'UPDATE [Customers] SET [Address] = N'''' WHERE [Address] IS NULL');
    ALTER TABLE [Customers] ALTER COLUMN [Address] nvarchar(max) NOT NULL;
    ALTER TABLE [Customers] ADD DEFAULT N'' FOR [Address];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240902163250_AddSuspicionToTransaction', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902204703_AddLimits'
)
BEGIN
    CREATE TABLE [Limits] (
        [Id] bigint NOT NULL IDENTITY,
        [Currency] int NOT NULL,
        [CreationDate] datetime2 NOT NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Count] int NOT NULL,
        [Range] time NOT NULL,
        CONSTRAINT [PK_Limits] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902204703_AddLimits'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240902204703_AddLimits', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903052007_AddIsObsoleteToLimit'
)
BEGIN
    ALTER TABLE [Limits] ADD [IsObsolete] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903052007_AddIsObsoleteToLimit'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240903052007_AddIsObsoleteToLimit', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903054937_RemoveIsObsoleteFromLimit'
)
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Limits]') AND [c].[name] = N'IsObsolete');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Limits] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Limits] DROP COLUMN [IsObsolete];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903054937_RemoveIsObsoleteFromLimit'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240903054937_RemoveIsObsoleteFromLimit', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903152403_SetAmountPrecision'
)
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Amount');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [Amount] decimal(18,4) NOT NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903152403_SetAmountPrecision'
)
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Limits]') AND [c].[name] = N'Amount');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Limits] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Limits] ALTER COLUMN [Amount] decimal(18,4) NOT NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903152403_SetAmountPrecision'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240903152403_SetAmountPrecision', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903164744_SeedLimits'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amount', N'Count', N'CreationDate', N'Currency', N'Range') AND [object_id] = OBJECT_ID(N'[Limits]'))
        SET IDENTITY_INSERT [Limits] ON;
    EXEC(N'INSERT INTO [Limits] ([Id], [Amount], [Count], [CreationDate], [Currency], [Range])
    VALUES (CAST(1 AS bigint), 11000.0, 11, ''2000-01-01T00:00:00.0000000'', 1, ''00:05:00''),
    (CAST(2 AS bigint), 12000.0, 12, ''2000-01-01T00:00:00.0000000'', 2, ''00:05:00''),
    (CAST(3 AS bigint), 13000.0, 13, ''2000-01-01T00:00:00.0000000'', 3, ''00:05:00''),
    (CAST(4 AS bigint), 21000.0, 21, ''2024-01-01T00:00:00.0000000'', 1, ''00:05:00''),
    (CAST(5 AS bigint), 22000.0, 22, ''2024-01-01T00:00:00.0000000'', 2, ''00:06:00''),
    (CAST(6 AS bigint), 23000.0, 23, ''2024-01-01T00:00:00.0000000'', 3, ''00:07:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amount', N'Count', N'CreationDate', N'Currency', N'Range') AND [object_id] = OBJECT_ID(N'[Limits]'))
        SET IDENTITY_INSERT [Limits] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903164744_SeedLimits'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240903164744_SeedLimits', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903170810_SeedCustomers'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Birthdate', N'Name', N'Surname') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    EXEC(N'INSERT INTO [Customers] ([Id], [Address], [Birthdate], [Name], [Surname])
    VALUES (CAST(1 AS bigint), N''ul. Kwiatowa 5, 00-001 Warszawa'', ''1990-06-15'', N''Anna'', N''Kowalska''),
    (CAST(2 AS bigint), N''ul. Słoneczna 12, 31-234 Kraków'', ''1985-03-22'', N''Jan'', N''Nowak''),
    (CAST(3 AS bigint), N''ul. Ogrodowa 8, 40-600 Katowice'', ''1995-10-11'', N''Katarzyna'', N''Zielińska'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Birthdate', N'Name', N'Surname') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903170810_SeedCustomers'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240903170810_SeedCustomers', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903173649_SeedTransactions'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amount', N'CreationDate', N'Currency', N'CustomerId', N'Description', N'IsSuspicious', N'TransactionType') AND [object_id] = OBJECT_ID(N'[Transactions]'))
        SET IDENTITY_INSERT [Transactions] ON;
    EXEC(N'INSERT INTO [Transactions] ([Id], [Amount], [CreationDate], [Currency], [CustomerId], [Description], [IsSuspicious], [TransactionType])
    VALUES (CAST(1 AS bigint), 150.0, ''2023-01-01T14:30:00.0000000'', 3, CAST(1 AS bigint), N''Initial deposit'', NULL, 1),
    (CAST(2 AS bigint), 75.5, ''2023-01-02T09:15:00.0000000'', 3, CAST(1 AS bigint), N''ATM withdrawal'', NULL, 2),
    (CAST(3 AS bigint), 300.0, ''2023-01-03T11:45:00.0000000'', 2, CAST(2 AS bigint), N''Online transfer'', NULL, 2),
    (CAST(4 AS bigint), 1000.0, ''2023-01-04T10:00:00.0000000'', 1, CAST(3 AS bigint), N''Salary deposit'', NULL, 1),
    (CAST(5 AS bigint), 50.0, ''2023-01-05T16:20:00.0000000'', 3, CAST(1 AS bigint), N''Grocery payment'', NULL, 2),
    (CAST(6 AS bigint), 120.0, ''2023-01-06T13:10:00.0000000'', 3, CAST(2 AS bigint), N''Gift deposit'', NULL, 1),
    (CAST(7 AS bigint), 45.0, ''2023-02-15T17:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(8 AS bigint), 45.0, ''2023-03-15T17:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(9 AS bigint), 45.0, ''2023-04-15T17:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(10 AS bigint), 45.0, ''2023-04-15T18:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(11 AS bigint), 45.0, ''2023-04-15T19:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(12 AS bigint), 45.0, ''2023-04-15T20:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(13 AS bigint), 45.0, ''2023-04-15T21:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(14 AS bigint), 45.0, ''2023-04-15T22:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(15 AS bigint), 45.0, ''2023-04-15T23:30:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(16 AS bigint), 45.0, ''2023-04-15T23:31:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(17 AS bigint), 45.0, ''2023-04-15T23:32:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(18 AS bigint), 45.0, ''2023-04-15T23:33:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(19 AS bigint), 45.0, ''2023-04-15T23:34:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(20 AS bigint), 45.0, ''2023-04-15T23:35:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(21 AS bigint), 45.0, ''2023-04-15T23:36:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(22 AS bigint), 45.0, ''2023-04-15T23:37:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(23 AS bigint), 45.0, ''2023-04-15T23:38:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(24 AS bigint), 45.0, ''2023-04-15T23:39:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(25 AS bigint), 45.0, ''2023-04-15T23:40:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(26 AS bigint), 45.0, ''2023-04-15T23:41:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(27 AS bigint), 45.0, ''2023-04-15T23:42:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(28 AS bigint), 45.0, ''2023-04-15T23:43:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(29 AS bigint), 450.0, ''2023-04-15T23:44:00.0000000'', 3, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(30 AS bigint), 45.0, ''2023-04-15T23:45:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(31 AS bigint), 100.0, ''2024-01-01T01:01:00.0000000'', 2, CAST(3 AS bigint), N''Online shopping'', NULL, 1),
    (CAST(32 AS bigint), 100000.0, ''2024-02-01T01:01:00.0000000'', 2, CAST(1 AS bigint), N''Online shopping'', NULL, 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amount', N'CreationDate', N'Currency', N'CustomerId', N'Description', N'IsSuspicious', N'TransactionType') AND [object_id] = OBJECT_ID(N'[Transactions]'))
        SET IDENTITY_INSERT [Transactions] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903173649_SeedTransactions'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240903173649_SeedTransactions', N'8.0.8');
END;
GO

COMMIT;
GO

