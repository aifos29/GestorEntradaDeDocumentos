USE[procedureDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getStadisticByPlataformer
(	
	@code varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT  MONTH(date) as position,datename(month, date) as Mes,COUNT(MONTH(date)) cantidad from [procedure] as proce
	inner join Plataformers platf
	on proce.idPlatformers = platf.idPlataformers
	where platf.name = @code
	group by MONTH(date),DATENAME(month,date) 
)
GO
