USE [procedureDB]
GO
CREATE FUNCTION getProcedureType()
RETURNS table AS
RETURN(
	Select * from [dbo].[typeOfProcedure]
)