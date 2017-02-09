USE [procedureDB]
GO
Create PROCEDURE closeProcedure
(
	@state varchar(50),
	@observation varchar(300),
	@idProcedure int,
	@date date
)
AS
BEGIN
	DECLARE
		@stateId int
    BEGIN TRY
		Select @stateId = idStatus from [dbo].[status] where status = @state;
		
		insert into [dbo].[closed] (details, date, idProcedure)
		values(@observation, @date, @idProcedure);
		
		Update [dbo].[procedure] 
		SET idStatus = @stateId
		where idProcedure = @idProcedure;
		
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END
GO