Create Function LoginUsuario (@email nvarchar(50), @pass nvarchar(50))
Returns INT As
Begin
    Declare @PassEncode As nvarchar(300)
    Declare @PassDecode As nvarchar(50)
    Declare @answ as INT
    

    Select @PassEncode = password From dbo.logging Where email = @email
    Set @PassDecode = DECRYPTBYPASSPHRASE('password', @PassEncode)
    If @PassDecode = @pass
        Select @answ = idLogging From dbo.logging Where email = @email
    Else
        Set @answ = 0
    RETURN @answ
END