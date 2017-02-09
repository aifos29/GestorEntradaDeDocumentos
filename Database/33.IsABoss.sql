Create Function [dbo].[IsABoss] (@platID INT)
Returns INT As
Begin

    Declare @answ as INT
    
	select @answ = IsABoss from dbo.Plataformers where idPlataformers = @platID

    RETURN @answ
END