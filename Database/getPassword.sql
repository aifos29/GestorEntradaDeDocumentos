SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getPassword
(
  @clave NVARCHAR(3000)
)
RETURNS NVARCHAR(300)
AS
BEGIN
    DECLARE @pass AS NVARCHAR(300)
    ------------------------------------
    ------------------------------------
  
    SET @pass = DECRYPTBYPASSPHRASE('password',@clave)
    ------------------------------------
    ------------------------------------    
    RETURN @pass

END
GO

