

Create PROCEDURE [dbo].[transferProcedure]
(
	@idDep int,
	@code nvarchar(50)
)
AS
BEGIN
    BEGIN TRY
		UPDATE [procedureDB].[dbo].[procedure]
		SET  [idDepartment] = @idDep 

		WHERE [dbo].[procedure].code = @code
		
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END

GO


