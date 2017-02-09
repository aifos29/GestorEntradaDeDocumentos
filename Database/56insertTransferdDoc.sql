USE [procedureDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[insertTransferdDoc]
(
			@justification nvarchar(300)
           ,@idSender_Secretary int
           ,@idReceiver_Department int
           ,@idProcedure int
)
AS
BEGIN


    
INSERT INTO [procedureDB].[dbo].[transferredDocuments]
           ([justification]
           ,[idSender_Secretary]
           ,[idReceiver_Department]
           ,[idProcedure])
     VALUES
           (@justification
           ,@idSender_Secretary
           ,@idReceiver_Department
           ,@idProcedure)
		
END


GO


