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

