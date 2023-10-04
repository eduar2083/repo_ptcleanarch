USE CrossDb
GO

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

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [UnitPrice] decimal(8,2) NOT NULL,
    [OrganizationId] nvarchar(72) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Products_Name] ON [Products] ([Name]);
GO

CREATE NONCLUSTERED INDEX [IX_Products_OrganizationId] ON [Products] ([OrganizationId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231004191712_Initial_Cross', N'7.0.11');
GO

COMMIT;
GO

