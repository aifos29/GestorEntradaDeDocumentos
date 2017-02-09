Create Function [dbo].[searchInDepartment]
(
	@dep nvarchar(50)
)
RETURNS INT AS
BEGIN

    Declare @id INT
    
        Select @id = idDepartment from dbo.Department where department = @dep 
						
		IF @id is NULL
		set @id = 0
	RETURN @id

END
