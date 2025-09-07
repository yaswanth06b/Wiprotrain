use EmpSample_#OK

select * from INFORMATION_SCHEMA.TABLES
GO

sp_help tblEmployees
GO

select * from tblEmployees

-- 1
select  sum(PresentBasic) as TotalPresentBasic, DepartmentCode from tblEmployees
group by DepartmentCode having sum(PresentBasic) >30000
order by DepartmentCode asc
go

--2. 

SELECT CentreCode,ServiceType,ServiceStatus,
    -- Max Age
    MAX(DATEDIFF(MONTH, DOB, GETDATE())) / 12 +
    MAX(DATEDIFF(MONTH, DOB, GETDATE())) % 12 AS MaxAge,

    -- Min Age
    MIN(DATEDIFF(MONTH, DOB, GETDATE())) / 12 +
    MIN(DATEDIFF(MONTH, DOB, GETDATE())) % 12 AS MinAge,

    -- Average Age
    AVG(DATEDIFF(MONTH, DOB, GETDATE())) / 12 +
    AVG(DATEDIFF(MONTH, DOB, GETDATE())) % 12 AS AvgAge

FROM dbo.tblEmployees
GROUP BY CentreCode, ServiceType, ServiceStatus
ORDER BY CentreCode, ServiceType, ServiceStatus;

--3

select 
CentreCode,ServiceType,ServiceStatus,
	MAX(DATEDIFF(MONTH, DOJ, GETDATE())) / 12 +
    MAX(DATEDIFF(MONTH, DOJ, GETDATE())) % 12 AS MaxService,

    -- Min Service
    MIN(DATEDIFF(MONTH, DOJ, GETDATE())) / 12+
    MIN(DATEDIFF(MONTH, DOJ, GETDATE())) % 12 AS MinServ,

    -- Avg Service
    AVG(DATEDIFF(MONTH, DOJ, GETDATE())) / 12 +
    AVG(DATEDIFF(MONTH, DOJ, GETDATE())) % 12 AS AvgServ
from dbo.tblEmployees 
group by CentreCode,ServiceType,ServiceStatus
order by CentreCode,ServiceType,ServiceStatus;

--4

select DepartmentCode,sum(PresentBasic)
from dbo.tblEmployees 
group by DepartmentCode
having sum(PresentBasic)> 3*avg(PresentBasic);

--5

select DepartmentCode,sum(PresentBasic) as TotalSalary
from dbo.tblEmployees
group by DepartmentCode
having sum(PresentBasic)> 2*avg(PresentBasic) and max(PresentBasic)>=3*min(PresentBasic);



       
--6

select CentreCode
from dbo.tblEmployees 
group by CentreCode
having max(len(Name))=2*min(len(Name));   

--7

select CentreCode,ServiceType,ServiceStatus,            
MAX(DATEDIFF(HH,DOJ,GETDATE())) as MaxServ ,                        
MIN(DATEDIFF(HH,DOJ,GETDATE())) as MinServ,            
AVG(DATEDIFF(HH,DOJ,GETDATE())) as AvgServ            
from dbo.tblEmployees 
group by CentreCode,ServiceType,ServiceStatus
order by CentreCode,ServiceType,ServiceStatus;    

--8

select Name
from dbo.tblEmployees 
where Name like '[ ]%' or Name like '%[ ]'

--9

select Name  
from dbo.tblEmployees
where Name like '%[a-z]%[ ][ ]%[a-z]%';

--10

select LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(Name,'.',' '),' ',' %'),'% ',''),'%','') )) as Name                           
from dbo.tblEmployees 


--11

select DummyTable.FormatedName,LEN(DummyTable.FormatedName)-LEN(REPLACE(DummyTable.FormatedName,' ',''))+1
from 
    (
        select LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(emp.Name,'.',' '),' ',' %'),'% ',''),'%','') )) FormatedName                            
        from dbo.tblEmployees emp
    )DummyTable
    

--12

select Name from dbo.tblEmployees
WHERE LEFT(LTRIM(RTRIM(Name)), 1) = RIGHT(LTRIM(RTRIM(Name)), 1);

--13

SELECT *
FROM (
        select LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(emp.Name,'.',' '),' ',' %'),'% ',''),'%','') )) FormatedName                            
        from dbo.tblEmployees emp
      )DummyTable  
where LEFT(DummyTable.FormatedName,1)=SUBSTRING(DummyTable.FormatedName,PATINDEX('%[ ]%',DummyTable.FormatedName)+1,1)        
       AND DummyTable.FormatedName LIKE '%[A-Z]%[ ][A-Z]%'; 
       
--14

SELECT *
FROM (
        select LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(emp.Name,'.',' '),' ',' %'),'% ',''),'%','') )) FormatedName                            
        from dbo.tblEmployees emp
    )DummyTable 
    
WHERE lEFT(DummyTable.FormatedName,1)= SUBSTRING(DummyTable.FormatedName,PATINDEX('%[ ][A-Z]%',DummyTable.FormatedName)+1,1) AND     
   lEFT(DummyTable.FormatedName,1)= SUBSTRING(DummyTable.FormatedName,CHARINDEX(' ',DummyTable.FormatedName,CHARINDEX(' ',DummyTable.FormatedName)+1)+1,1)AND
   lEFT(DummyTable.FormatedName,1)= SUBSTRING(DummyTable.FormatedName,CHARINDEX(' ',DummyTable.FormatedName,CHARINDEX(' ',DummyTable.FormatedName,CHARINDEX(' ',DummyTable.FormatedName)+1)+1)+1,1)
   AND
   DummyTable.FormatedName LIKE '%[A-Z]%[ ][A-Z]%'       
   
--15

SELECT DummyTable.S      
      FROM (
               select LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(emp.Name,'.',' '),' ',' %'),'% ',''),'%','') )) S
               from dbo.tblEmployees emp
           )DummyTable             
      WHERE ( LEN(SUBSTRING(DummyTable.S,1,PATINDEX('%[ ]%',DummyTable.S)))>4 AND
              LEFT(DummyTable.S,1)= LEFT(REVERSE(SUBSTRING(DummyTable.S,1,PATINDEX('%[ ]%',DummyTable.S)-1)),1) )                 
               OR              
             (LEN(DummyTable.S)-LEN(REPLACE(DummyTable.S,' ',''))+1 = 2 AND LEFT(SUBSTRING(DummyTable.S, (CHARINDEX(' ',DummyTable.S)+1) ,LEN(DummyTable.S)-CHARINDEX(' ',DummyTable.S)),1) =   LEFT(REVERSE(SUBSTRING(DummyTable.S, (CHARINDEX(' ',DummyTable.S)+1) ,LEN(DummyTable.S)-CHARINDEX(' ',DummyTable.S))),1)   )             
             OR             
              ( LEN(DummyTable.S)-LEN(REPLACE(DummyTable.S,' ',''))+1 = 3 AND LEFT(SUBSTRING(DummyTable.S, (CHARINDEX(' ',DummyTable.S,CHARINDEX(' ',DummyTable.S)+1)+1) ,LEN(DummyTable.S)-CHARINDEX(' ',DummyTable.S,CHARINDEX(' ',DummyTable.S)+1)),1)=LEFT(REVERSE(SUBSTRING(DummyTable.S, (CHARINDEX(' ',DummyTable.S,CHARINDEX(' ',DummyTable.S)+1)+1) ,LEN(DummyTable.S)-CHARINDEX(' ',DummyTable.S,CHARINDEX(' ',DummyTable.S)+1))),1)   )   
              
--16

--16.1
select PresentBasic from dbo.tblEmployees 
WHERE round(PresentBasic,-2)=PresentBasic and PresentBasic<>0;              

--16.2

select Name,PresentBasic  from dbo.tblEmployees 
where floor(PresentBasic/100)=(PresentBasic/100) AND PresentBasic<>0;

--16.3

select Name,PresentBasic  from dbo.tblEmployees 
where (PresentBasic%100)=0 and PresentBasic<>0;

--16.4

select Name, PresentBasic  from dbo.tblEmployees 
where ceiling(PresentBasic/100)=(PresentBasic/100) AND PresentBasic<>0;


--17
SELECT Name, DepartmentCode
FROM dbo.tblEmployees
GROUP BY DepartmentCode
HAVING COUNT(*) = SUM(CASE WHEN PresentBasic % 100 = 0 THEN 1 ELSE 0 END);



--18     

SELECT emp.DepartmentCode,COUNT(emp.PresentBasic),
 COUNT(CASE
    WHEN ROUND(emp.PresentBasic,-2)!=emp.PresentBasic AND emp.PresentBasic<>0 THEN emp.PresentBasic
 END)
FROM dbo.tblEmployees emp
GROUP BY emp.DepartmentCode
HAVING COUNT(emp.PresentBasic)=COUNT(CASE
    WHEN ROUND(emp.PresentBasic,-2)!=emp.PresentBasic AND emp.PresentBasic<>0 THEN emp.PresentBasic
 END)
 
--19

select emp.Name,emp.DOB, emp.DOJ DateOfJoining, 
DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))) as EligibleDate,
DATEADD(MONTH,1,DATEADD(DAY,-(DATEPART(dd,DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))-1),DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ)))))As BonusDate,
CONVERT(varchar(max),(DATEDIFF(MONTH,emp.DOB,DATEADD(MONTH,1,DATEADD(DAY,-(DATEPART(dd,DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))-1),DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))))/12))+' years '+
CONVERT(varchar(max),(DATEDIFF(MONTH,emp.DOB,DATEADD(MONTH,1,DATEADD(DAY,-(DATEPART(dd,DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))-1),DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))))%12))+' Months',
DATENAME(dw,DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))As WeekDayName,
DATENAME(Wk,DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))As WeekOfYear,
DATENAME(dy,DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))As DayOfYears,
(DATENAME(DD,DATEADD(DAY,15,DATEADD(MONTH,3,DATEADD(YEAR,1,emp.DOJ))))/7)+1 As WeekOfMonth         
from dbo.tblEmployees emp
 
 --20
 
 select emp.CentreCode,emp.ServiceType,emp.EmployeeType,
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOJ,GETDATE())/12))+' years '+
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOJ,GETDATE())%12))+' months' as MIN_SERVICE,            
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+' years '+
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+' months' as MIN_AGE                       
from dbo.tblEmployees emp   
where emp.ServiceType=1 AND emp.EmployeeType=1 AND (DATEDIFF(MM,EMP.DOJ,GETDATE())/12)>=10 AND CONVERT(int,(DATEDIFF(MM,GETDATE(),emp.RetirementDate)/12))>=15 AND DATEDIFF(YEAR,emp.DOB,emp.RetirementDate)>=60 

--20.2

select emp.CentreCode,emp.ServiceType,emp.EmployeeType,
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOJ,GETDATE())/12))+' years '+
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOJ,GETDATE())%12))+' months' as MIN_SERVICE,            
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+' years '+
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+' months' as MIN_AGE                       
from dbo.tblEmployees emp   
where emp.ServiceType=1 AND emp.EmployeeType=2 AND (DATEDIFF(MM,EMP.DOJ,GETDATE())/12)>=12 AND CONVERT(int,(DATEDIFF(MM,GETDATE(),emp.RetirementDate)/12))>=14 AND DATEDIFF(YEAR,emp.DOB,emp.RetirementDate)>=55

--20.3

select emp.CentreCode,emp.ServiceType,emp.EmployeeType,
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOJ,GETDATE())/12))+' years '+
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOJ,GETDATE())%12))+' months' as MIN_SERVICE,            
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+' years '+
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+' months' as MIN_AGE                       
from dbo.tblEmployees emp   
where emp.ServiceType=1 AND emp.EmployeeType=3 AND (DATEDIFF(MM,EMP.DOJ,GETDATE())/12)>=12 AND CONVERT(int,(DATEDIFF(MM,GETDATE(),emp.RetirementDate)/12))>=12 AND DATEDIFF(YEAR,emp.DOB,emp.RetirementDate)>=55

--20.4

select emp.CentreCode,emp.ServiceType,emp.EmployeeType,
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOJ,GETDATE())/12))+' years '+
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOJ,GETDATE())%12))+' months' as MIN_SERVICE,            
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+' years '+
CONVERT(varchar(10),(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+' months' as MIN_AGE                       
from dbo.tblEmployees emp   
where (emp.ServiceType=2 OR emp.ServiceType=2 OR emp.ServiceType=4) AND (DATEDIFF(MM,EMP.DOJ,GETDATE())/12)>=15 AND CONVERT(int,(DATEDIFF(MM,GETDATE(),emp.RetirementDate)/12))>=20 AND DATEDIFF(YEAR,emp.DOB,emp.RetirementDate)>=65

--21

SELECT CONVERT(VARCHAR(12),GETDATE(), 103)  
SELECT CONVERT(VARCHAR(12),GETDATE(), 105)
SELECT CONVERT(VARCHAR(12),GETDATE(), 104)  
SELECT CONVERT(VARCHAR(12),GETDATE(), 106)  
 SELECT CONVERT(VARCHAR(12),GETDATE(), 101)  
SELECT CONVERT(VARCHAR(12),GETDATE(), 110)  
SELECT CONVERT(VARCHAR(12),GETDATE(), 100)  
SELECT CONVERT(VARCHAR(12),GETDATE(), 107)  
SELECT CONVERT(VARCHAR(12),GETDATE(), 102)  
SELECT CONVERT(VARCHAR(12),GETDATE(), 111)  
SELECT CONVERT(VARCHAR(12),GETDATE(), 112)

--22

SELECT emp.EmployeeNumber,
SUM(CASE WHEN emp.TransValue=1 THEN emp.ActualAmount else -emp.ActualAmount END) As ActualSalary,
SUM(CASE WHEN emp.TransValue=1 THEN emp.Amount else -emp.Amount END)As NetSalary
FROM dbo.tblPayEmployeeparamDetails emp
GROUP BY emp.EmployeeNumber,emp.NoteNumber
having SUM(CASE WHEN emp.TransValue=1 THEN emp.ActualAmount else -emp.ActualAmount END) > SUM(CASE WHEN emp.TransValue=1 THEN emp.Amount else -emp.Amount END)
order by emp.EmployeeNumber