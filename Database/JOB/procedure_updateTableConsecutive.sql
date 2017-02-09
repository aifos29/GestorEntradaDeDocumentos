USE [procedureDB]
GO
Create PROCEDURE updateTableConsecutive 
AS
BEGIN
	DECLARE
		@month int,
		@day int,
		@year int

	Select @month = MONTH( GETDATE() );
	Select @day = DAY( GETDATE() );
	Select @year = YEAR( GETDATE() );
	
	IF @month = 1 AND @day = 1 
		Update [dbo].[consecutive] 
			SET consecutiveNumber = 0,
			consecutiveYear = @year
			where consecutiveId = 1
END