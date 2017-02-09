USE msdb ;
GO
EXEC dbo.sp_add_job
    @job_name = N'Set consecutive number' ;
GO
EXEC sp_add_jobstep
    @job_name = N'Set consecutive number',
    @step_name = N'Update consecutive number',
    @subsystem = N'TSQL',
    @command = N'[procedureDB].[dbo].[updateTableConsecutive]', 
    @retry_attempts = 5,
    @retry_interval = 5 ;
GO
EXEC dbo.sp_add_schedule
    @schedule_name = N'RunDaily',
    @freq_type = 4,
    @freq_interval = 1,
    @active_start_time = 000000 ;
USE msdb ;
GO
EXEC sp_attach_schedule
   @job_name = N'Set consecutive number',
   @schedule_name = N'RunDaily';
GO
EXEC dbo.sp_add_jobserver
    @job_name = N'Set consecutive number';
GO