USE [procedureDB]
GO
CREATE FUNCTION getProcedure
(
	@procedureCode varchar(50)
)
RETURNS table AS
RETURN(
	Select p.code,p.date,p.details,p.identifyCode,D.department,p.idTypeOfProcedure,p.idTypeOfIdentify,p.name, p.contact 
	from [dbo].[procedure] as p
	inner join [dbo].[department] as D on D.idDepartment = p.idDepartment
	where p.code = @procedureCode
)