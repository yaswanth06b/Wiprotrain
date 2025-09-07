--Users
INSERT INTO users (FullName, Email, PasswordHash, Role, IsActive, CreatedAt) VALUES
(N'Amit Sharma', 'amit.sharma@example.in', CONVERT(VARBINARY(MAX), 'hash1'), 'Student', 1, SYSUTCDATETIME()),
(N'Sneha Patel', 'sneha.patel@example.in', CONVERT(VARBINARY(MAX), 'hash2'), 'Student', 1, SYSUTCDATETIME()),
(N'Arjun Kumar', 'arjun.kumar@example.in', CONVERT(VARBINARY(MAX), 'hash3'), 'Instructor', 1, SYSUTCDATETIME()),
(N'Priya Singh', 'priya.singh@example.in', CONVERT(VARBINARY(MAX), 'hash4'), 'Student', 1, SYSUTCDATETIME()),
(N'Rajesh Gupta', 'rajesh.gupta@example.in', CONVERT(VARBINARY(MAX), 'hash5'), 'Instructor', 1, SYSUTCDATETIME()),
(N'Neha Joshi', 'neha.joshi@example.in', CONVERT(VARBINARY(MAX), 'hash6'), 'Student', 1, SYSUTCDATETIME()),
(N'Vikram Reddy', 'vikram.reddy@example.in', CONVERT(VARBINARY(MAX), 'hash7'), 'Student', 1, SYSUTCDATETIME()),
(N'Anjali Desai', 'anjali.desai@example.in', CONVERT(VARBINARY(MAX), 'hash8'), 'Admin', 1, SYSUTCDATETIME()),
(N'Karan Mehta', 'karan.mehta@example.in', CONVERT(VARBINARY(MAX), 'hash9'), 'Student', 1, SYSUTCDATETIME()),
(N'Sudha Iyer', 'sudha.iyer@example.in', CONVERT(VARBINARY(MAX), 'hash10'), 'Instructor', 1, SYSUTCDATETIME());



--Courses
INSERT INTO courses (Title, Description, Category, Difficulty, Price, IsPublished, InstructorID, CreatedAt) VALUES
(N'Python for Beginners', N'Learn Python programming from scratch.', N'Programming', 'Beginner', 999.00, 1, 3, SYSUTCDATETIME()),
(N'Advanced Java Concepts', N'Deep dive into Java programming.', N'Programming', 'Advanced', 1499.00, 1, 5, SYSUTCDATETIME()),
(N'Web Development Basics', N'HTML, CSS and JavaScript fundamentals.', N'Web Development', 'Beginner', 799.00, 1, 9, SYSUTCDATETIME()),
(N'Database Design and SQL', N'Learn database design principles and SQL.', N'Database', 'Intermediate', 1199.00, 1, 3, SYSUTCDATETIME()),
(N'Machine Learning Essentials', N'Intro to machine learning algorithms.', N'Data Science', 'Intermediate', 1999.00, 0, 9, SYSUTCDATETIME()),
(N'C# Programming Complete Guide', N'Comprehensive course on C#.', N'Programming', 'Beginner', 1099.00, 1, 5, SYSUTCDATETIME()),
(N'React for Beginners', N'Build dynamic UI using React.', N'Web Development', 'Beginner', 899.00, 0, 3, SYSUTCDATETIME()),
(N'Data Structures and Algorithms', N'In-depth data structure study.', N'Programming', 'Advanced', 1599.00, 1, 9, SYSUTCDATETIME()),
(N'Cloud Computing Foundations', N'Basics of cloud platforms.', N'Cloud', 'Beginner', 1299.00, 1, 5, SYSUTCDATETIME()),
(N'Cybersecurity Fundamentals', N'Learning principles of cybersecurity.', N'Security', 'Intermediate', 1399.00, 0, 3, SYSUTCDATETIME());


--enrollments
INSERT INTO enrolments (StudentID, CourseID, EnrollmentDate, ProgressPercent, Status) VALUES
(2, 1, SYSUTCDATETIME(), 10.00, 'Active'),
(3, 1, SYSUTCDATETIME(), 45.50, 'Active'),
(5, 2, SYSUTCDATETIME(), 100.00, 'Completed'),
(6, 3, SYSUTCDATETIME(), 75.25, 'Active'),
(7, 4, SYSUTCDATETIME(), 0.00, 'Cancelled'),
(8, 5, SYSUTCDATETIME(), 55.00, 'Active'),
(10, 1, SYSUTCDATETIME(), 100.00, 'Completed'),
(9, 6, SYSUTCDATETIME(), 20.00, 'Active'),
(7, 7, SYSUTCDATETIME(), 0.00, 'Active'),
(3, 8, SYSUTCDATETIME(), 80.00, 'Active');


--Assignments
INSERT INTO Assignments (CourseID, Title, Description, DueDate, MaxScore, CreatedAt) VALUES
(1, N'Python Basics Project', N'Create a simple Python program to solve a problem.', DATEADD(day, 10, SYSUTCDATETIME()), 100, SYSUTCDATETIME()),
(1, N'Python Data Types Quiz', N'A quiz covering Python data types and variables.', DATEADD(day, 5, SYSUTCDATETIME()), 50, SYSUTCDATETIME()),
(2, N'Java OOP Assignment', N'Implement classes and inheritance in Java.', DATEADD(day, 15, SYSUTCDATETIME()), 100, SYSUTCDATETIME()),
(3, N'HTML & CSS Webpage', N'Build a responsive webpage using HTML and CSS.', DATEADD(day, 7, SYSUTCDATETIME()), 75, SYSUTCDATETIME()),
(4, N'Database Design ER Diagram', N'Design an ER diagram for a sample case study.', DATEADD(day, 12, SYSUTCDATETIME()), 80, SYSUTCDATETIME()),
(5, N'Machine Learning Model', N'Train a classification model using provided dataset.', DATEADD(day, 20, SYSUTCDATETIME()), 100, SYSUTCDATETIME()),
(6, N'C# Console App', N'Develop a console app implementing key features.', DATEADD(day, 14, SYSUTCDATETIME()), 90, SYSUTCDATETIME()),
(7, N'React To-Do App', N'Create a To-Do list application using React.', DATEADD(day, 10, SYSUTCDATETIME()), 85, SYSUTCDATETIME()),
(8, N'Algorithm Implementation', N'Implement sorting and searching algorithms.', DATEADD(day, 18, SYSUTCDATETIME()), 100, SYSUTCDATETIME()),
(9, N'Cloud Service Setup', N'Deploy a web app using cloud infrastructure.', DATEADD(day, 25, SYSUTCDATETIME()), 100, SYSUTCDATETIME());



-- Quizzes
INSERT INTO Quizzes (CourseID, Title, Instructions, IsPublished, CreatedAt) VALUES
(1, N'Python Basics Quiz', N'Answer all questions to test your Python fundamentals.', 1, SYSUTCDATETIME()),
(2, N'Java OOP Quiz', N'Test your understanding of Java classes and objects.', 1, SYSUTCDATETIME()),
(3, N'Web Development Quiz', N'Quiz on HTML, CSS, and JavaScript basics.', 0, SYSUTCDATETIME()),
(4, N'Database Design Quiz', N'Quiz covering ER diagrams and normalization.', 1, SYSUTCDATETIME()),
(5, N'Machine Learning Quiz', N'Questions on supervised and unsupervised learning.', 0, SYSUTCDATETIME()),
(6, N'C# Fundamentals Quiz', N'Basics of C# programming language.', 1, SYSUTCDATETIME()),
(7, N'React Framework Quiz', N'Quiz on React components and state management.', 0, SYSUTCDATETIME()),
(8, N'Data Structures Quiz', N'Quiz on arrays, lists, trees, and graphs.', 1, SYSUTCDATETIME()),
(9, N'Cloud Computing Quiz', N'Quiz on cloud service models and deployment.', 1, SYSUTCDATETIME()),
(10, N'Cybersecurity Quiz', N'Quiz on basic cybersecurity principles.', 0, SYSUTCDATETIME());

-- Payments
INSERT INTO Payments (StudentID, CourseID, Amount, Currency, Status, Provider, ProviderSessionId, ProviderPaymentId, CreatedAt) VALUES
(2, 1, 999.00, 'INR', 'succeeded', 'Stripe', 'sess_001', 'pay_001', SYSUTCDATETIME()),
(3, 1, 999.00, 'INR', 'succeeded', 'Stripe', 'sess_002', 'pay_002', SYSUTCDATETIME()),
(5, 2, 1499.00, 'INR', 'pending', 'Stripe', 'sess_003', 'pay_003', SYSUTCDATETIME()),
(6, 3, 799.00, 'INR', 'failed', 'Stripe', 'sess_004', 'pay_004', SYSUTCDATETIME()),
(7, 4, 1199.00, 'INR', 'refunded', 'Stripe', 'sess_005', 'pay_005', SYSUTCDATETIME()),
(8, 5, 1999.00, 'INR', 'succeeded', 'Stripe', 'sess_006', 'pay_006', SYSUTCDATETIME()),
(10, 1, 999.00, 'INR', 'succeeded', 'Stripe', 'sess_007', 'pay_007', SYSUTCDATETIME()),
(9, 6, 1099.00, 'INR', 'pending', 'Stripe', 'sess_008', 'pay_008', SYSUTCDATETIME()),
(7, 7, 899.00, 'INR', 'succeeded', 'Stripe', 'sess_009', 'pay_009', SYSUTCDATETIME()),
(3, 8, 1599.00, 'INR', 'succeeded', 'Stripe', 'sess_010', 'pay_010', SYSUTCDATETIME());

-- Notifications
INSERT INTO dbo.Notifications (UserID, Type, Title, Message, IsRead, CreatedAt, MetadataJson) VALUES
(2, 'CourseUpdate', 'New Lesson Added', 'A new lesson has been added to your enrolled course.', 0, SYSUTCDATETIME(), N'{"courseId":1, "lessonId":5}'),
(3, 'AssignmentDue', 'Assignment Deadline Approaching', 'Your assignment "Python Basics Project" is due in 3 days.', 0, SYSUTCDATETIME(), N'{"assignmentId":1}'),
(5, 'Payment', 'Payment Received', 'Your payment for the course "Advanced Java" was successful.', 1, SYSUTCDATETIME(), N'{"paymentId":3}'),
(6, 'CourseUpdate', 'Course Published', 'The course "Web Development Basics" is now published.', 0, SYSUTCDATETIME(), N'{"courseId":3}'),
(7, 'AssignmentDue', 'Assignment Overdue', 'Your assignment "Database Design ER Diagram" is overdue.', 0, SYSUTCDATETIME(), N'{"assignmentId":5}'),
(8, 'Payment', 'Refund Processed', 'Your refund for the course "Machine Learning Essentials" has been processed.', 1, SYSUTCDATETIME(), N'{"paymentId":5}'),
(10, 'CourseUpdate', 'Quiz Published', 'A new quiz has been published for your course.', 0, SYSUTCDATETIME(), N'{"quizId":1}'),
(9, 'AssignmentDue', 'Assignment Submitted', 'Your assignment has been successfully submitted.', 1, SYSUTCDATETIME(), N'{"assignmentId":7}'),
(7, 'Payment', 'Payment Failed', 'Your recent payment attempt failed. Please retry.', 0, SYSUTCDATETIME(), N'{"paymentId":6}'),
(3, 'CourseUpdate', 'Course Cancelled', 'The course you enrolled in has been cancelled.', 0, SYSUTCDATETIME(), N'{"courseId":2}');

