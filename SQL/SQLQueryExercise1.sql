use EmpSample_#OK

select * from INFORMATION_SCHEMA.TABLES
GO

sp_help tblEmployees
GO

select * from tblEmployees
go

-- 1
select DOB, Name from dbo.tblEmployees where Name not like '% %'
go



--2 
select Name
from dbo.tblEmployees 
where Name like '[a-z]%[ ][a-z]%[ ][a-z]%' and Name not like '[a-z]%[ ][a-z]%[ ][a-z]%[ ][a-z]%'
go

--3 



--5

select * from dbo.tblCentreMaster
go

--6
select * from dbo.tblEmployeeTypes
go

--7
--a
select DOB, Name,FatherName, PresentBasic from dbo.tblEmployees where PresentBasic >3000
go

--b
select DOB, Name,FatherName, PresentBasic from dbo.tblEmployees where PresentBasic <3000
go

--c
select DOB, Name,FatherName, PresentBasic from dbo.tblEmployees where PresentBasic between 3000 and 5000
go

--8
--a
select  Name from dbo.tblEmployees where Name like '%khan'
go

--b
select  Name from dbo.tblEmployees where Name like 'chandra%'
go

--c
select Name from dbo.tblEmployees where Name like '%ramesh'
and left(Name,1) between 'a' and 't'
go

--and

select emp.Name 
from dbo.tblEmployees emp
where emp.Name like '[a-t][.]Ramesh';