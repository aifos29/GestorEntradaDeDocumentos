SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[androidLogin] 
---se declaran los parametros que usaremos
@email varchar(50),@password varchar(50),@result int Output

as
Declare @loginID int;
Declare @isPlatafomer int;
Declare @PassEncode As nvarchar(300)
Declare @PassDecode As nvarchar(50)

Select @PassEncode = password From dbo.logging Where email = @email
Set @PassDecode = DECRYPTBYPASSPHRASE('password', @PassEncode)

---se hace un insert a la tabla usuarios y se envian los parametros

Select @loginID=idLogging from dbo.logging where email = @email and @PassDecode = @password;

Set @isPlatafomer = (Select COUNT(idLogging) from dbo.Plataformers where idLogging = @loginID);

if (@isPlatafomer = 1)
	Select @result = idPlataformers from Plataformers where idLogging = @loginID;
else
	set @result = 0 ;

return @result