use wiprojuly


CREATE TABLE Employ (
    empno INT PRIMARY KEY,         -- Matches public int Empno
    name VARCHAR(100),              -- Matches public string? Name
    gender VARCHAR(10),             -- Matches public string? Gender
    Dept VARCHAR(50),               -- Matches public string? Dept
    desig VARCHAR(50),              -- Matches public string? Desig
    basic DECIMAL(10, 2)            -- Matches public decimal Basic
);

-- Insert 10 sample rows
INSERT INTO Employ (Empno, Name, Gender, Dept, Desig, Basic)
VALUES
(1, 'John Smith', 'Male', 'HR', 'HR Manager', 55000.00),
(2, 'Jane Doe', 'Female', 'IT', 'Software Engineer', 70000.00),
(3, 'Robert Brown', 'Male', 'Finance', 'Accountant', 50000.00),
(4, 'Emily Davis', 'Female', 'IT', 'System Analyst', 65000.00),
(5, 'Michael Johnson', 'Male', 'Sales', 'Sales Executive', 48000.00),
(6, 'Sarah Wilson', 'Female', 'Marketing', 'Marketing Manager', 60000.00),
(7, 'David Lee', 'Male', 'Finance', 'Financial Analyst', 52000.00),
(8, 'Olivia Clark', 'Female', 'HR', 'Recruiter', 45000.00),
(9, 'James Walker', 'Male', 'IT', 'Network Administrator', 62000.00),
(10, 'Sophia Hall', 'Female', 'Sales', 'Sales Manager', 58000.00);

-- View data
SELECT * FROM Employ;
