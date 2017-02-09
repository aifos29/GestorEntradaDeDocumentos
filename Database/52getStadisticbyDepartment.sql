USE[procedureDB]
GO
---Estadisticas por departamento--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getStadisticbyDepartment
(	
	@code varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT  MONTH(date) as position,datename(month, date) as Mes,COUNT(MONTH(date)) cantidad from [procedure] as proce
	inner join Department dept
	on proce.idDepartment = dept.idDepartment
	where dept.department = @code
	group by MONTH(date),DATENAME(month,date) 
)
GO