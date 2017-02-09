Create Function seacrhInPlatformer (@idSearch INT)
Returns INT As
Begin

    Declare @answ as INT
    
	Select @answ = idPlataformers from dbo.Plataformers where idLogging = @idSearch
	IF @answ is NULL
		set @answ = 0
	RETURN @answ

END