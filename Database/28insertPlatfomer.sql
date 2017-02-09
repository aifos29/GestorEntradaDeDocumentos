USE [procedureDB]
GO
Create PROCEDURE insertPlatformers
(
	@name nvarchar(50),
	@isABoss int,
	@idLogging int
	
)
AS
BEGIN

    Declare @message varchar(100);
    
	INSERT INTO [procedureDB].[dbo].[Plataformers]
           ([name]
           ,[isABoss]
           ,[idLogging])
     VALUES
           (@name
           ,@isABoss
           ,@idLogging)
		
END
GO