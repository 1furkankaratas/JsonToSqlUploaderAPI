create table ItDatas
(
    Id           int not null
        constraint ItDatas_pk
            primary key nonclustered,
    dc_Orario    nvarchar(max),
    dc_Categoria nvarchar(max),
    dc_Evento    nvarchar(max)
)
go
