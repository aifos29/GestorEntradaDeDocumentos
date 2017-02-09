USE [procedureDB]
GO
insert into [dbo].[department] (department, code)
values ('Administración Tributaria','AT');

insert into [dbo].[department] (department, code)
values ('Administración General','ADM GEN');

insert into [dbo].[department] (department, code)
values ('Alcaldía','ALC');

insert into [dbo].[department] (department, code)
values ('Vice Alcaldía','VICE-ALC');

insert into [dbo].[department] (department, code)
values ('Asesoría Legal','ASES-LEG');

insert into [dbo].[department] (department, code)
values ('Auditoría','AUD');

insert into [dbo].[department] (department, code)
values ('Bienes Inmuebles','BI');

insert into [dbo].[department] (department, code)
values ('Catastro','CATA');

insert into [dbo].[department] (department, code)
values ('Cementerio','CEM');

insert into [dbo].[department] (department, code)
values ('Concejo','CONCEJO');

insert into [dbo].[department] (department, code)
values ('Contabilidad','CONTA');

insert into [dbo].[department] (department, code)
values ('Gestión Ambiental','G AMB');

insert into [dbo].[department] (department, code)
values ('Gestión Cultural','G CULT');

insert into [dbo].[department] (department, code)
values ('Informática','INF');

insert into [dbo].[department] (department, code)
values ('Ingeniería','ING');

insert into [dbo].[department] (department, code)
values ('Inspección','INSP');

insert into [dbo].[department] (department, code)
values ('Junta Vial','JV');

insert into [dbo].[department] (department, code)
values ('Oficina de la Mujer','OFIC MUJ');

insert into [dbo].[department] (department, code)
values ('Patentes','PAT');

insert into [dbo].[department] (department, code)
values ('Planificación','PLANI');

insert into [dbo].[department] (department, code)
values ('Proveeduría','PROVEE');

insert into [dbo].[department] (department, code)
values ('Recursos Humanos','RH');

insert into [dbo].[department] (department, code)
values ('Tesorería','TESO');

insert into [dbo].[department] (department, code)
values ('Unidad Técnica de Gestión Vial','UTGV');

insert into [dbo].[department] (department, code)
values ('Plataforma','PLAT');
	   
insert into [dbo].[typeOfProcedure] (TypeOfProcedure)
values ('Inquietud');
insert into [dbo].[typeOfProcedure] (TypeOfProcedure)
values('Solicitud');
	   
insert into [dbo].[typeOfIdentify] (TypeOfIdentify)
values ('Nacional');
insert into [dbo].[typeOfIdentify] (TypeOfIdentify)
values ('Extranjero');
insert into [dbo].[typeOfIdentify] (TypeOfIdentify)
values ('Pasaporte');

insert into [dbo].[consecutive] (consecutiveNumber,consecutiveYear)
values (0,2017);

insert into [dbo].[status] (status)
values ('Nuevo');
insert into [dbo].[status] (status)
values ('En Proceso');
insert into [dbo].[status] (status)
values ('Finalizado');
