use sqlpractice 
Go

-- Display List of tables avaialble in current database 

select * from INFORMATION_SCHEMA.TABLES
GO

-- Display information about Emp Table 

sp_help Emp
GO

select* from EMp;
go

select * from EMp where desig ='programmer';
go

select* from EMp where basic between '40000' and '60000';
go

select * from EMp where nam like '%h';
go

