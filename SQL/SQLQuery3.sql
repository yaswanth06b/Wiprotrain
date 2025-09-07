DECLARE @word VARCHAR(100) = 'misissipi';
SELECT LEN(@word) - LEN(REPLACE(@word, 'i', '')) AS CountOfI
go

DECLARE @FirstDay DATE = DATEADD(DAY, 1 - DAY(GETDATE()), CAST(GETDATE() AS DATE));
DECLARE @LastDay DATE = EOMONTH(GETDATE());

;WITH Fridays AS (
    SELECT DATEADD(DAY, (6 - DATEPART(WEEKDAY, @FirstDay) + @@DATEFIRST) % 7, @FirstDay) AS Friday
    UNION ALL
    SELECT DATEADD(WEEK, 1, Friday)
    FROM Fridays
    WHERE DATEADD(WEEK, 1, Friday) <= @LastDay
)
SELECT Friday
FROM Fridays
WHERE Friday BETWEEN @FirstDay AND @LastDay
OPTION (MAXRECURSION 5);