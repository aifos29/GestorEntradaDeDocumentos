USE [procedureDB]
GO

/****** Object:  StoredProcedure [dbo].[reInsertLogin]    Script Date: 01/23/2017 10:51:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[reInsertLogin]
(
	@id int,
	@email nvarchar(50)
)
AS
BEGIN
	Declare @pwd nvarchar(300);
	Select @pwd = log.password from dbo.logging as log where log.idLogging = @id
		UPDATE [procedureDB].[dbo].[logging]
		SET [email] = ' '
		,[password] = ' '
		 ,[isActive] = 0
		WHERE dbo.logging.idLogging =@id
		
		INSERT INTO [procedureDB].[dbo].[logging]
           ([email]
           ,[password]
           ,[isActive])
     VALUES
           (@email
           ,@pwd
           ,1)
	
	
		
END
GO


