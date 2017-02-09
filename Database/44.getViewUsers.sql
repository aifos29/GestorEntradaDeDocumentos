USE [procedureDB]
GO

/****** Object:  UserDefinedFunction [dbo].[getViewOfUser]    Script Date: 01/24/2017 02:14:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[getViewOfUser]()
RETURNS table AS
RETURN(
	Select sec.idSecretary as "ID", sec.name as "Nombre", logg.email,dep.department as "Departamento"
			from dbo.Secretary as sec inner join dbo.Department as dep on dep.idDepartment = sec.idDepartment
									  inner join dbo.logging as logg on sec.idLogging = logg.idLogging
									  where logg.isActive = 1
		UNION
		Select plat.idPlataformers,plat.name, logg.email,'Plataforma' from dbo.Plataformers as plat
										inner join dbo.logging as logg on plat.idLogging = logg.idLogging
										where logg.isActive = 1
)


GO


