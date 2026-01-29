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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035052_InitialCreate'
)
BEGIN
    CREATE TABLE [Benefits] (
        [BenefitId] int NOT NULL IDENTITY,
        [BenefitName] nvarchar(max) NOT NULL,
        [BenefitType] nvarchar(max) NOT NULL,
        [ProviderName] nvarchar(max) NULL,
        [MonthlyPremium] decimal(18,2) NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Benefits] PRIMARY KEY ([BenefitId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035052_InitialCreate'
)
BEGIN
    CREATE TABLE [Retirees] (
        [RetireeId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [Email] nvarchar(max) NULL,
        [IsActive] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Retirees] PRIMARY KEY ([RetireeId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035052_InitialCreate'
)
BEGIN
    CREATE TABLE [RetireeBenefits] (
        [RetireeBenefitId] int NOT NULL IDENTITY,
        [RetireeId] int NOT NULL,
        [BenefitId] int NOT NULL,
        [CoverageStartDate] datetime2 NOT NULL,
        [CoverageEndDate] datetime2 NULL,
        [IsActive] bit NOT NULL,
        [EnrolledAt] datetime2 NOT NULL,
        CONSTRAINT [PK_RetireeBenefits] PRIMARY KEY ([RetireeBenefitId]),
        CONSTRAINT [FK_RetireeBenefits_Benefits_BenefitId] FOREIGN KEY ([BenefitId]) REFERENCES [Benefits] ([BenefitId]) ON DELETE CASCADE,
        CONSTRAINT [FK_RetireeBenefits_Retirees_RetireeId] FOREIGN KEY ([RetireeId]) REFERENCES [Retirees] ([RetireeId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035052_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_RetireeBenefits_BenefitId] ON [RetireeBenefits] ([BenefitId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035052_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_RetireeBenefits_RetireeId] ON [RetireeBenefits] ([RetireeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035052_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260129035052_InitialCreate', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035224_AddSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BenefitId', N'BenefitName', N'BenefitType', N'IsActive', N'MonthlyPremium', N'ProviderName') AND [object_id] = OBJECT_ID(N'[Benefits]'))
        SET IDENTITY_INSERT [Benefits] ON;
    EXEC(N'INSERT INTO [Benefits] ([BenefitId], [BenefitName], [BenefitType], [IsActive], [MonthlyPremium], [ProviderName])
    VALUES (1, N''Medicare Supplement Plan F'', N''Medical'', CAST(1 AS bit), 185.5, N''Blue Cross Blue Shield''),
    (2, N''Medicare Advantage HMO'', N''Medical'', CAST(1 AS bit), 0.0, N''UnitedHealthcare''),
    (3, N''Dental PPO'', N''Dental'', CAST(1 AS bit), 45.0, N''Delta Dental''),
    (4, N''Vision Plan'', N''Vision'', CAST(1 AS bit), 18.75, N''VSP''),
    (5, N''Prescription Drug Plan'', N''Pharmacy'', CAST(1 AS bit), 32.5, N''CVS Caremark'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BenefitId', N'BenefitName', N'BenefitType', N'IsActive', N'MonthlyPremium', N'ProviderName') AND [object_id] = OBJECT_ID(N'[Benefits]'))
        SET IDENTITY_INSERT [Benefits] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035224_AddSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RetireeId', N'CreatedAt', N'DateOfBirth', N'Email', N'FirstName', N'IsActive', N'LastName') AND [object_id] = OBJECT_ID(N'[Retirees]'))
        SET IDENTITY_INSERT [Retirees] ON;
    EXEC(N'INSERT INTO [Retirees] ([RetireeId], [CreatedAt], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName])
    VALUES (1, ''2024-01-10T00:00:00.0000000'', ''1955-03-15T00:00:00.0000000'', N''john.smith@email.com'', N''John'', CAST(1 AS bit), N''Smith''),
    (2, ''2024-02-15T00:00:00.0000000'', ''1958-07-22T00:00:00.0000000'', N''mary.johnson@email.com'', N''Mary'', CAST(1 AS bit), N''Johnson''),
    (3, ''2024-03-20T00:00:00.0000000'', ''1953-11-08T00:00:00.0000000'', N''robert.williams@email.com'', N''Robert'', CAST(1 AS bit), N''Williams''),
    (4, ''2024-04-05T00:00:00.0000000'', ''1960-05-30T00:00:00.0000000'', N''patricia.brown@email.com'', N''Patricia'', CAST(1 AS bit), N''Brown'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RetireeId', N'CreatedAt', N'DateOfBirth', N'Email', N'FirstName', N'IsActive', N'LastName') AND [object_id] = OBJECT_ID(N'[Retirees]'))
        SET IDENTITY_INSERT [Retirees] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035224_AddSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RetireeBenefitId', N'BenefitId', N'CoverageEndDate', N'CoverageStartDate', N'EnrolledAt', N'IsActive', N'RetireeId') AND [object_id] = OBJECT_ID(N'[RetireeBenefits]'))
        SET IDENTITY_INSERT [RetireeBenefits] ON;
    EXEC(N'INSERT INTO [RetireeBenefits] ([RetireeBenefitId], [BenefitId], [CoverageEndDate], [CoverageStartDate], [EnrolledAt], [IsActive], [RetireeId])
    VALUES (1, 1, NULL, ''2024-01-01T00:00:00.0000000'', ''2024-01-10T00:00:00.0000000'', CAST(1 AS bit), 1),
    (2, 3, NULL, ''2024-01-01T00:00:00.0000000'', ''2024-01-10T00:00:00.0000000'', CAST(1 AS bit), 1),
    (3, 2, NULL, ''2024-02-01T00:00:00.0000000'', ''2024-02-15T00:00:00.0000000'', CAST(1 AS bit), 2),
    (4, 4, NULL, ''2024-02-01T00:00:00.0000000'', ''2024-02-15T00:00:00.0000000'', CAST(1 AS bit), 2),
    (5, 1, NULL, ''2024-03-01T00:00:00.0000000'', ''2024-03-20T00:00:00.0000000'', CAST(1 AS bit), 3),
    (6, 5, NULL, ''2024-03-01T00:00:00.0000000'', ''2024-03-20T00:00:00.0000000'', CAST(1 AS bit), 3),
    (7, 2, NULL, ''2024-04-01T00:00:00.0000000'', ''2024-04-05T00:00:00.0000000'', CAST(1 AS bit), 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RetireeBenefitId', N'BenefitId', N'CoverageEndDate', N'CoverageStartDate', N'EnrolledAt', N'IsActive', N'RetireeId') AND [object_id] = OBJECT_ID(N'[RetireeBenefits]'))
        SET IDENTITY_INSERT [RetireeBenefits] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260129035224_AddSeedData'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260129035224_AddSeedData', N'9.0.1');
END;

COMMIT;
GO

