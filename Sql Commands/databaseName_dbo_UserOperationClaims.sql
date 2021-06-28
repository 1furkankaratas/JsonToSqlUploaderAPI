create table UserOperationClaims
(
    Id               int identity
        primary key,
    UserId           int not null,
    OperationClaimId int not null
)
go

INSERT INTO databaseName.dbo.UserOperationClaims (Id, UserId, OperationClaimId) VALUES (1, 1, 1);