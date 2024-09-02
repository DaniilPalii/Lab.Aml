BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902163250_AddSuspicionToTransaction'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Description');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var0 + '];');
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
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Currency');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var1 + '];');
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
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Amount');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var2 + '];');
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
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Surname');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var3 + '];');
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
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Name');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var4 + '];');
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
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Birthdate');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var5 + '];');
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
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Address');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var6 + '];');
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

