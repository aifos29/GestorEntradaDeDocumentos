Create Function [dbo].[existTypeOfProc](@type nvarchar(50))
Returns INT
AS
BEGIN
	Declare @answ INT;
	Select @answ = idTypeOfProcedure from dbo.typeOfProcedure where TypeOfProcedure = @type 
	IF @answ is NULL
		set @answ = 0
	ELSE
		set @answ = 1
	RETURN @answ

END	
GO

