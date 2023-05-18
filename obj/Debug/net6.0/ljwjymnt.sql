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

CREATE TABLE [Classes] (
    [CId] int NOT NULL IDENTITY,
    [ClassName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Classes] PRIMARY KEY ([CId])
);
GO

CREATE TABLE [Lecturers] (
    [LId] bigint NOT NULL IDENTITY,
    [CId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [ClassCId] int NOT NULL,
    CONSTRAINT [PK_Lecturers] PRIMARY KEY ([LId]),
    CONSTRAINT [FK_Lecturers_Classes_ClassCId] FOREIGN KEY ([ClassCId]) REFERENCES [Classes] ([CId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Students] (
    [SId] int NOT NULL IDENTITY,
    [CId] int NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [ClassCId] int NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([SId]),
    CONSTRAINT [FK_Students_Classes_ClassCId] FOREIGN KEY ([ClassCId]) REFERENCES [Classes] ([CId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Enrollment] (
    [SId] int NOT NULL,
    [CId] int NOT NULL,
    CONSTRAINT [PK_Enrollment] PRIMARY KEY ([SId], [CId]),
    CONSTRAINT [FK_Enrollment_Classes_CId] FOREIGN KEY ([CId]) REFERENCES [Classes] ([CId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Enrollment_Students_SId] FOREIGN KEY ([SId]) REFERENCES [Students] ([SId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Enrollment_CId] ON [Enrollment] ([CId]);
GO

CREATE INDEX [IX_Lecturers_ClassCId] ON [Lecturers] ([ClassCId]);
GO

CREATE INDEX [IX_Students_ClassCId] ON [Students] ([ClassCId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230509062834_StudentManagement.Models.DBContext', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Lecturers] DROP CONSTRAINT [FK_Lecturers_Classes_ClassCId];
GO

ALTER TABLE [Students] DROP CONSTRAINT [FK_Students_Classes_ClassCId];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'ClassCId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Students] ALTER COLUMN [ClassCId] int NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lecturers]') AND [c].[name] = N'ClassCId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Lecturers] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Lecturers] ALTER COLUMN [ClassCId] int NULL;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CId', N'ClassName') AND [object_id] = OBJECT_ID(N'[Classes]'))
    SET IDENTITY_INSERT [Classes] ON;
INSERT INTO [Classes] ([CId], [ClassName])
VALUES (1, N'Mathematics'),
(2, N'Physics'),
(3, N'Chemistry');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CId', N'ClassName') AND [object_id] = OBJECT_ID(N'[Classes]'))
    SET IDENTITY_INSERT [Classes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'LId', N'CId', N'ClassCId', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Lecturers]'))
    SET IDENTITY_INSERT [Lecturers] ON;
INSERT INTO [Lecturers] ([LId], [CId], [ClassCId], [Email], [Name])
VALUES (CAST(11 AS bigint), 1, NULL, N'john.doe@example.com', N'John Doe'),
(CAST(12 AS bigint), 2, NULL, N'jane.smith@example.com', N'Jane Smith'),
(CAST(13 AS bigint), 3, NULL, N'bob.johnson@example.com', N'Bob Johnson');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'LId', N'CId', N'ClassCId', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Lecturers]'))
    SET IDENTITY_INSERT [Lecturers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SId', N'CId', N'ClassCId', N'DateOfBirth', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Students]'))
    SET IDENTITY_INSERT [Students] ON;
INSERT INTO [Students] ([SId], [CId], [ClassCId], [DateOfBirth], [Email], [FirstName], [LastName])
VALUES (1000, 1, NULL, '2000-01-01T00:00:00.0000000', N'johndoe@example.com', N'John', N'Doe'),
(1001, 2, NULL, '2002-02-02T00:00:00.0000000', N'janedoe@example.com', N'Jane', N'Doe'),
(1003, 3, NULL, '2002-03-03T00:00:00.0000000', N'charlie.brown@example.com', N'Charlie', N'Brown'),
(1004, 1, NULL, '2003-04-04T00:00:00.0000000', N'david.davis@example.com', N'David', N'Davis'),
(1005, 2, NULL, '2004-05-05T00:00:00.0000000', N'emily.moore@example.com', N'Emily', N'Moore'),
(1006, 3, NULL, '2005-06-06T00:00:00.0000000', N'frank.adams@example.com', N'Frank', N'Adams'),
(1007, 1, NULL, '2006-07-07T00:00:00.0000000', N'grace.wright@example.com', N'Grace', N'Wright'),
(1008, 2, NULL, '2007-08-08T00:00:00.0000000', N'henry.scott@example.com', N'Henry', N'Scott'),
(1009, 3, NULL, '2008-09-09T00:00:00.0000000', N'isabella.taylor@example.com', N'Isabella', N'Taylor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SId', N'CId', N'ClassCId', N'DateOfBirth', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Students]'))
    SET IDENTITY_INSERT [Students] OFF;
GO

ALTER TABLE [Lecturers] ADD CONSTRAINT [FK_Lecturers_Classes_ClassCId] FOREIGN KEY ([ClassCId]) REFERENCES [Classes] ([CId]);
GO

ALTER TABLE [Students] ADD CONSTRAINT [FK_Students_Classes_ClassCId] FOREIGN KEY ([ClassCId]) REFERENCES [Classes] ([CId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230509081610_StudentManagement.Models.DBContextseed', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230509091648_StudentManagement.Models.try', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230511040855_StudentManagement.Models.success', N'7.0.5');
GO

COMMIT;
GO

