USE [procedureDB]
GO

/****** Object:  UserDefinedFunction [dbo].[getDailyProcedures]    Script Date: 01/25/2017 08:48:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[getDailyProcedures](
	@departmentId int
)
RETURNS table AS
RETURN(
	Select pr.date as "Fecha" ,pr.code as "Consecutivo",pr.identifyCode as "Cèdula",
		tp.TypeOfProcedure as "Tipo de Procedimiento", plat.name as "Plataformista", pr.idProcedure as "id"
	FROM dbo.[procedure] pr
	INNER JOIN dbo.[Department] dep on pr.idDepartment = dep.idDepartment
	INNER JOIN dbo.[typeOfProcedure] tp on pr.idTypeOfProcedure = tp.idTypeOfProcedure
	INNER JOIN dbo.[typeOfIdentify] ti on pr.idTypeOfIdentify = ti.idTypeOfIdentify
	INNER JOIN dbo.[Plataformers] plat on pr.idPlatformers = plat.idPlataformers

	INNER JOIN dbo.[status] st on pr.idStatus = st.idStatus
	where pr.idDepartment = @departmentId 
	and pr.idStatus = 1
)

GO


