BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903211114_SeedRequiredData'
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
    WHERE [MigrationId] = N'20240903211114_SeedRequiredData'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240903211114_SeedRequiredData', N'8.0.8');
END;
GO

COMMIT;
GO

