																																							USE [procedureDB]
																																							GO
																																							CREATE FUNCTION getDepartments()
																																							RETURNS table AS
																																							RETURN(
																																								Select * from [dbo].[department]
																																							)