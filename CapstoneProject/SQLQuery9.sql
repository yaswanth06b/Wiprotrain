SELECT TOP (1000) [PaymentID]
      ,[StudentID]
      ,[CourseID]
      ,[Amount]
      ,[Currency]
      ,[Status]
      ,[Provider]
      ,[ProviderSessionId]
      ,[ProviderPaymentId]
      ,[CreatedAt]
  FROM [learning_platform].[dbo].[Payments]

  EXEC sp_rename 'payments.StudentId', 'UserId', 'COLUMN';