-- 1. Create the database
CREATE DATABASE EmployeeDB;

-- 2. Use the database
USE EmployeeDB;

-- 3. Create the Employees table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    Position VARCHAR(50),
    Salary DECIMAL(10,2),
    HireDate DATE
);

-- 4. Insert 10 sample employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, Department, Position, Salary, HireDate)
VALUES
(1, 'John', 'Smith', 'HR', 'HR Manager', 55000.00, '2020-01-15'),
(2, 'Jane', 'Doe', 'IT', 'Software Engineer', 70000.00, '2021-03-10'),
(3, 'Robert', 'Brown', 'Finance', 'Accountant', 50000.00, '2019-07-20'),
(4, 'Emily', 'Davis', 'IT', 'System Analyst', 65000.00, '2022-05-01'),
(5, 'Michael', 'Johnson', 'Sales', 'Sales Executive', 48000.00, '2018-09-12'),
(6, 'Sarah', 'Wilson', 'Marketing', 'Marketing Manager', 60000.00, '2020-11-05'),
(7, 'David', 'Lee', 'Finance', 'Financial Analyst', 52000.00, '2019-12-25'),
(8, 'Olivia', 'Clark', 'HR', 'Recruiter', 45000.00, '2021-06-17'),
(9, 'James', 'Walker', 'IT', 'Network Administrator', 62000.00, '2022-01-09'),
(10, 'Sophia', 'Hall', 'Sales', 'Sales Manager', 58000.00, '2018-03-30');

-- 5. View inserted data
SELECT * FROM Employees;
