USE [procedureDB]
GO
CREATE FUNCTION getPlatformers()
RETURNS table AS
RETURN(
	Select idPlataformers,name from [dbo].[Plataformers]
)