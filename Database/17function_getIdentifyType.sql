USE [procedureDB]
GO
CREATE FUNCTION getIdentifyType()
RETURNS table AS
RETURN(
	Select * from [dbo].[typeOfIdentify]
)