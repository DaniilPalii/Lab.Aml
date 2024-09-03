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

