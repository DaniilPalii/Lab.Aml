BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903211143_SeedOptionalData'
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
    WHERE [MigrationId] = N'20240903211143_SeedOptionalData'
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
    WHERE [MigrationId] = N'20240903211143_SeedOptionalData'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240903211143_SeedOptionalData', N'8.0.8');
END;
GO

COMMIT;
GO

