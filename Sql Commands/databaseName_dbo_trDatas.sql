create table trDatas
(
    Id          int not null
        constraint trDatas_pk
            primary key nonclustered,
    dc_Zaman    nvarchar(max),
    dc_Kategori nvarchar(max),
    dc_Olay     nvarchar(max)
)
go
