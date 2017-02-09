Create PROCEDURE [dbo].[insertSecretary]
(
	@name nvarchar(50),
	@idLoggingin int,
	@idDepartment int
	
)
AS
BEGIN

    Declare @message varchar(100);
    
INSERT INTO [procedureDB].[dbo].[Secretary]
           ([name]
           ,[idLogging]
           ,[idDepartment])
     VALUES
           (@name
           ,@idLoggingin
           ,@idDepartment)
		
END

GO
