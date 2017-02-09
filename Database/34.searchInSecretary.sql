Create Function [dbo].[seacrhInSecretary] (@idSearch INT)
Returns INT As
Begin

    Declare @answ as INT
    
	Select @answ = idSecretary from dbo.Secretary where idLogging = @idSearch
	IF @answ is NULL
		set @answ = 0
	RETURN @answ

END
GO