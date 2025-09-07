SELECT TOP (1000) [EnrollmentID]
      ,[StudentID]
      ,[CourseID]
      ,[EnrollmentDate]
      ,[ProgressPercent]
      ,[Status]
  FROM [learning_platform].[dbo].[enrolments]
   EXEC sp_rename 'enrolments.StudentId', 'UserId', 'COLUMN';
