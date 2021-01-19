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

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(150) NOT NULL,
    [CreateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Username] varchar(150) NULL,
    [Password] varchar(150) NULL,
    [Type] varchar(150) NULL,
    [CreateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(150) NOT NULL,
    [Description] varchar(350) NULL,
    [Value] float NOT NULL,
    [ProductDate] datetime2 NOT NULL,
    [CategoryId] int NOT NULL,
    [CreateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [CategoryProducts] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [CategoryId] int NOT NULL,
    [CreateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_CategoryProducts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CategoryProducts_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CategoryProducts_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_CategoryProducts_CategoryId] ON [CategoryProducts] ([CategoryId]);
GO

CREATE INDEX [IX_CategoryProducts_ProductId] ON [CategoryProducts] ([ProductId]);
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210119214043_Initial', N'5.0.2');
GO

COMMIT;
GO

