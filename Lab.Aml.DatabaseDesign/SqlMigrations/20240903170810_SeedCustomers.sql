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

