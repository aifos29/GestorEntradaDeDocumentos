USE[procedureDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getStadisticByDateForPlataformer
(	
	@from varchar(50),@to varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	Select plat.name,COUNT(proce.date) Cantidad from [procedure] as proce
	inner join Plataformers as plat
	on proce.idPlatformers = plat.idPlataformers
	where date between @from and @to
	group by plat.name

)
GO
