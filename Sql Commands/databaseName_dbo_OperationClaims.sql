create table OperationClaims
(
    Id   int identity
        primary key,
    Name varchar(250) not null
)
go

INSERT INTO databaseName.dbo.OperationClaims (Id, Name) VALUES (1, N'user');