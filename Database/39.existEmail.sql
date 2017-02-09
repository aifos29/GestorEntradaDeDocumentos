Create Function existEmail(@email nvarchar(50))
Returns INT
AS
BEGIN
	Declare @answ INT;
	Select @answ = idLogging from dbo.logging where email = @email 
	IF @answ is NULL
		set @answ = 0
	ELSE
		set @answ = 1
	RETURN @answ

END	