BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240903054937_RemoveIsObsoleteFromLimit'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Limits]') AND [c].[name] = N'IsObsolete');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Limits] DROP CONSTRAINT [' + @var0 + '];');
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

