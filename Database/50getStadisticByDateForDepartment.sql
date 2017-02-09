USE[procedureDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getStadisticByDateForDeparment
(	
	@to varchar(50), @from varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	Select dept.department,COUNT(proce.date) Cantidad from [procedure] as proce
	inner join Department as dept
	on proce.idDepartment = dept.idDepartment
	where date between @to and @from
	group by dept.department
)
GO
