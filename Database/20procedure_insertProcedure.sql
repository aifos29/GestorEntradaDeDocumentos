USE [procedureDB]
GO
Create Procedure insertProcedure
(
    @date date,
	@departmentId int,
	@idTypeOfIdentify int,
	@personID varchar(50),
	@personName varchar(50),
	@personContact varchar(50),
	@idTypeOfProcedure int,
	@detail varchar(50),
	@userId int,
	@code varchar(50) OUT
)
AS
BEGIN
    Declare @statusId int;
    Declare @message varchar(100);
    
	Select @statusId = s.idStatus from [dbo].[status] as s 
	where s.status = 'Nuevo';
		
	Select @code = dbo.getConsecutive(@departmentId);
		
	insert into [dbo].[procedure](date,code,details,identifyCode,name,contact,idStatus,idDepartment, idTypeOfProcedure, idTypeOfIdentify,idPlatformers)
	values (@date,@code,@detail,@personID,@personName,@personContact,@statusId,@departmentId,@idTypeOfProcedure,@idTypeOfIdentify,@userId);
		
	update [dbo].[consecutive] 
	SET consecutiveNumber = consecutiveNumber + 1
	where consecutiveId = 1;
END
GO