Create Function [dbo].[seacrhInAdministrator] (@idSearch INT)
Returns INT As
Begin

    Declare @answ as INT
    
	Select @answ = idAdministrator from dbo.Administrator where idLogging = @idSearch
	IF @answ is NULL
		set @answ = 0
	RETURN @answ

END
GO