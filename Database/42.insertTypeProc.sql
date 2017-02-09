
Create PROCEDURE [dbo].[insertTypeProc]
(
	@TypeOfProcedur nvarchar(50)
)
AS
BEGIN

    Declare @message varchar(100);
INSERT INTO [procedureDB].[dbo].[typeOfProcedure]
           ([TypeOfProcedure])
     VALUES
           (@TypeOfProcedur)		
END

GO
