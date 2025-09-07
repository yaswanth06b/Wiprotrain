CREATE DATABASE learning_platform;
USE learning_platform;

-- Users table
CREATE TABLE users (
 UserID           INT IDENTITY(1,1) PRIMARY KEY,
    FullName         NVARCHAR(150)       NOT NULL,
    Email            NVARCHAR(256)       NOT NULL UNIQUE,
    PasswordHash     VARBINARY(MAX)      NOT NULL,   -- or NVARCHAR if you store hash as text
    Role             VARCHAR(20)         NOT NULL,   -- Admin / Instructor / Student
    IsActive         BIT                 NOT NULL DEFAULT (1),
    CreatedAt        DATETIME2(0)        NOT NULL DEFAULT (SYSUTCDATETIME()),
    UpdatedAt        DATETIME2(0)        NULL
);


-- Courses table
CREATE TABLE courses (
        CourseID         INT IDENTITY(1,1) PRIMARY KEY,
    Title            NVARCHAR(200)       NOT NULL,
    Description      NVARCHAR(MAX)       NULL,
    Category         NVARCHAR(100)       NULL,
    Difficulty       VARCHAR(20)         NULL,       -- Beginner / Intermediate / Advanced
    Price            DECIMAL(10,2)       NOT NULL DEFAULT (0.00),
    IsPublished      BIT                 NOT NULL DEFAULT (0),
    InstructorID     INT                 NOT NULL,
    CreatedAt        DATETIME2(0)        NOT NULL DEFAULT (SYSUTCDATETIME()),
    UpdatedAt        DATETIME2(0)        NULL,
    CONSTRAINT FK_Courses_Instructor
        FOREIGN KEY (InstructorID) REFERENCES dbo.Users(UserID)
            ON UPDATE CASCADE ON DELETE NO ACTION
);
ALTER TABLE dbo.Courses ADD CONSTRAINT CK_Courses_Difficulty
CHECK (Difficulty IS NULL OR Difficulty IN ('Beginner','Intermediate','Advanced'));
GO


-- Enrollments table
CREATE TABLE enrolments (

    EnrollmentID     INT IDENTITY(1,1) PRIMARY KEY,
    StudentID        INT                 NOT NULL,
    CourseID         INT                 NOT NULL,
    EnrollmentDate   DATETIME2(0)        NOT NULL DEFAULT (SYSUTCDATETIME()),
    ProgressPercent  DECIMAL(5,2)        NOT NULL DEFAULT (0), -- 0 to 100
    Status           VARCHAR(20)         NOT NULL DEFAULT ('Active'), -- Active/Completed/Cancelled
 CONSTRAINT FK_Enrollments_Student  FOREIGN KEY (StudentID) REFERENCES dbo.Users(UserID)
       ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_Enrollments_Course   FOREIGN KEY (CourseID)  REFERENCES dbo.Courses(CourseID)
      ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT UQ_Enrollments UNIQUE (StudentID, CourseID),
    CONSTRAINT CK_Enrollments_Progress CHECK (ProgressPercent BETWEEN 0 AND 100),
    CONSTRAINT CK_Enrollments_Status   CHECK (Status IN ('Active','Completed','Cancelled'))
);
GO

/* 5) Assignments */
CREATE TABLE Assignments (
    AssignmentID     INT IDENTITY(1,1) PRIMARY KEY,
    CourseID         INT                 NOT NULL,
    Title            NVARCHAR(200)       NOT NULL,
    Description      NVARCHAR(MAX)       NULL,
    DueDate          DATETIME2(0)        NULL,
    MaxScore         DECIMAL(10,2)       NOT NULL DEFAULT (100),
    CreatedAt        DATETIME2(0)        NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT FK_Assignments_Course FOREIGN KEY (CourseID) REFERENCES dbo.Courses(CourseID)
        ON UPDATE CASCADE ON DELETE CASCADE
);
GO


/* 6) Quizzes */
CREATE TABLE Quizzes (
    QuizID           INT IDENTITY(1,1) PRIMARY KEY,
    CourseID         INT                 NOT NULL,
    Title            NVARCHAR(200)       NOT NULL,
    Instructions     NVARCHAR(MAX)       NULL,
    IsPublished      BIT                 NOT NULL DEFAULT (0),
    CreatedAt        DATETIME2(0)        NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT FK_Quizzes_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
        ON UPDATE CASCADE ON DELETE CASCADE
);
GO

/* 7) Payments */
CREATE TABLE Payments (
    PaymentID        INT IDENTITY(1,1) PRIMARY KEY,
    StudentID        INT                 NOT NULL,
    CourseID         INT                 NOT NULL,
    Amount           DECIMAL(10,2)       NOT NULL,
    Currency         CHAR(3)             NOT NULL DEFAULT ('INR'),
    Status           VARCHAR(20)         NOT NULL,   -- pending/succeeded/failed/refunded
    Provider         VARCHAR(50)         NOT NULL DEFAULT ('Stripe'),
    ProviderSessionId NVARCHAR(200)      NULL,       -- e.g., Stripe Checkout Session ID
    ProviderPaymentId NVARCHAR(200)      NULL,       -- e.g., Stripe PaymentIntent ID
    CreatedAt        DATETIME2(0)        NOT NULL DEFAULT (SYSUTCDATETIME()),
     CONSTRAINT FK_Payments_Student FOREIGN KEY (StudentID) REFERENCES dbo.Users(UserID)
        ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT FK_Payments_Course  FOREIGN KEY (CourseID)  REFERENCES dbo.Courses(CourseID)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT CK_Payments_Status CHECK (Status IN ('pending','succeeded','failed','refunded'))
);
CREATE INDEX IX_Payments_Student_Course ON dbo.Payments (StudentID, CourseID);
GO

/* 8) Notifications */
CREATE TABLE dbo.Notifications (
    NotificationID   INT IDENTITY(1,1) PRIMARY KEY,
    UserID           INT                 NOT NULL,
    Type             VARCHAR(50)         NOT NULL,   -- e.g., 'CourseUpdate','AssignmentDue','Payment'
    Title            NVARCHAR(200)       NOT NULL,
    Message          NVARCHAR(MAX)       NOT NULL,
    IsRead           BIT                 NOT NULL DEFAULT (0),
    CreatedAt        DATETIME2(0)        NOT NULL DEFAULT (SYSUTCDATETIME()),
    MetadataJson     NVARCHAR(MAX)       NULL,       -- optional payload
    CONSTRAINT FK_Notifications_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
        ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Cred
(
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);

INSERT INTO Cred (Username, Password)
VALUES ('yaswanth', 'bunty06');