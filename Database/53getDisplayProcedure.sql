USE [procedureDB]
GO
CREATE FUNCTION getDisplayProcedures(
	@departmentId int
)
RETURNS table AS
RETURN(
	Select pr.date as "Fecha" ,pr.code as "Consecutivo",pr.identifyCode as "Cèdula",
		tp.TypeOfProcedure as "Tipo de Procedimiento", pr.contact as "Contacto",plat.name as "Plataformista", pr.idProcedure as "id",
		st.status as "Estado"
	FROM dbo.[procedure] pr
	INNER JOIN dbo.[Department] dep on pr.idDepartment = dep.idDepartment
	INNER JOIN dbo.[typeOfProcedure] tp on pr.idTypeOfProcedure = tp.idTypeOfProcedure
	INNER JOIN dbo.[typeOfIdentify] ti on pr.idTypeOfIdentify = ti.idTypeOfIdentify
	INNER JOIN dbo.[Plataformers] plat on pr.idPlatformers = plat.idPlataformers
	INNER JOIN dbo.[status] st on pr.idStatus = st.idStatus	
	where pr.idDepartment = @departmentId
)