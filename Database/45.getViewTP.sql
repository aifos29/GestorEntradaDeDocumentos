CREATE FUNCTION [dbo].[getViewOfTypeProce]()
RETURNS table AS
RETURN(
	Select TP.TypeOfProcedure as "Tipo de Procedimiento" from dbo.typeOfProcedure as TP
)
GO
