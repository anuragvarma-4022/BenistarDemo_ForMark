/* database */
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'BenistarDemoDb')
BEGIN
    CREATE DATABASE BenistarDemoDb;
END
GO

USE BenistarDemoDb;
GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'dbo')
BEGIN
    EXEC('CREATE SCHEMA dbo');
END
GO

/* tables */
if not exists (select 1 from sys.tables where name = 'Retirees' and schema_id = schema_id('dbo'))
begin
    create table dbo.Retirees
    (
        RetireeId   int identity(1,1) not null,
        FirstName   nvarchar(100) not null,
        LastName    nvarchar(100) not null,
        DateOfBirth date not null,
        Email       nvarchar(255) null,
        IsActive    bit not null constraint DF_Retirees_IsActive default (1),
        CreatedDate datetime2 not null constraint DF_Retirees_CreatedDate default (sysutcdatetime()),
        constraint PK_Retirees primary key clustered (RetireeId)
    );
end
go

if not exists (select 1 from sys.tables where name = 'Benefits' and schema_id = schema_id('dbo'))
begin
    create table dbo.Benefits
    (
        BenefitId   int identity(1,1) not null,
        BenefitName nvarchar(200) not null,
        Description nvarchar(500) null,
        IsActive    bit not null constraint DF_Benefits_IsActive default (1),
        CreatedDate datetime2 not null constraint DF_Benefits_CreatedDate default (sysutcdatetime()),
        constraint PK_Benefits primary key clustered (BenefitId)
    );
end
go

if not exists (select 1 from sys.tables where name = 'RetireeBenefits' and schema_id = schema_id('dbo'))
begin
    create table dbo.RetireeBenefits
    (
        RetireeBenefitId int identity(1,1) not null,
        RetireeId        int not null,
        BenefitId        int not null,
        EffectiveDate    date not null,
        EndDate          date null,
        IsActive         bit not null constraint DF_RetireeBenefits_IsActive default (1),
        CreatedDate      datetime2 not null constraint DF_RetireeBenefits_CreatedDate default (sysutcdatetime()),
        constraint PK_RetireeBenefits primary key clustered (RetireeBenefitId),
        constraint FK_RetireeBenefits_Retirees foreign key (RetireeId) references dbo.Retirees (RetireeId),
        constraint FK_RetireeBenefits_Benefits foreign key (BenefitId) references dbo.Benefits (BenefitId)
    );
end
go

/* indexes */
if not exists (select 1 from sys.indexes where name = 'IX_Retirees_LastName' and object_id = object_id(N'dbo.Retirees'))
begin
    create nonclustered index IX_Retirees_LastName on dbo.Retirees (LastName, FirstName);
end
go

if not exists (select 1 from sys.indexes where name = 'IX_Benefits_BenefitName' and object_id = object_id(N'dbo.Benefits'))
begin
    create nonclustered index IX_Benefits_BenefitName on dbo.Benefits (BenefitName);
end
go

if not exists (select 1 from sys.indexes where name = 'IX_RetireeBenefits_RetireeId' and object_id = object_id(N'dbo.RetireeBenefits'))
begin
    create nonclustered index IX_RetireeBenefits_RetireeId on dbo.RetireeBenefits (RetireeId);
end
go

if not exists (select 1 from sys.indexes where name = 'IX_RetireeBenefits_BenefitId' and object_id = object_id(N'dbo.RetireeBenefits'))
begin
    create nonclustered index IX_RetireeBenefits_BenefitId on dbo.RetireeBenefits (BenefitId);
end
go

/* overkill */
if not exists (select 1 from sys.indexes where name = 'UX_RetireeBenefits_Active' and object_id = object_id(N'dbo.RetireeBenefits'))
begin
    create unique nonclustered index UX_RetireeBenefits_Active
        on dbo.RetireeBenefits (RetireeId, BenefitId)
        where IsActive = 1;
end
go

/* maybe not necessary but... */
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Retirees TO dbo;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Benefits TO dbo;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.RetireeBenefits TO dbo;
GO
