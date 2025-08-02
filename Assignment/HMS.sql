
--Doctor Master
create table Doctor_Master (
    doctor_id Varchar(15) Primary key,
    doctor_name Varchar(15) NOT NULL,
    dept Varchar(15) NOT NULL);

INSERT INTO Doctor_Master (doctor_id, doctor_name, dept) VALUES
('D0001', 'Ram', 'ENT'),
('D0002', 'Rajan', 'ENT'),
('D0003', 'Smita', 'Eye'),
('D0004', 'Bhavan', 'Surgery'),
('D0005', 'Sheela', 'Surgery'),
('D0006', 'Nethra', 'Surgery');

select  *from Doctor_Master 


-- Room Master

create table Room_master(room_no Varchar(15) Unique not null,
room_type Varchar(15)  not null,
status Varchar(15)  not null);

insert into Room_master(room_no,room_type, status) values
('R0001', 'AC', 'occupied'),
('R0002', 'Suite', 'vacant'),
('R0003', 'NonAC', 'vacant'),
('R0004', 'NonAC', 'occupied'),
('R0005', 'AC', 'vacant'),
('R0006', 'AC', 'occupied');

select*from Room_Master


--Patient Master

CREATE TABLE Patient_Master (
    pid VARCHAR(15) PRIMARY KEY,              
    name VARCHAR(15) NOT NULL,                
    age NUMERIC(15) NOT NULL,                 
    weight NUMERIC(15) NOT NULL,             
    gender VARCHAR(10) NOT NULL,              
    address VARCHAR(50) NOT NULL,            
    phoneno VARCHAR(10) NOT NULL,            
    disease VARCHAR(50) NOT NULL,            
    doctor_id VARCHAR(15) NOT NULL,
	 FOREIGN KEY (doctor_id) REFERENCES Doctor_Master(doctor_id)
 );
INSERT INTO Patient_Master(pid, name, age, weight, gender, address, phoneno, disease, doctor_id) VALUES
('P0001', 'Gita', 35, 65, 'F', 'Chennai', '9867145678', 'Eye Infection', 'D0003'),
('P0002', 'Ashish', 40, 70, 'M', 'Delhi', '9845675678', 'Asthma', 'D0003'),
('P0003', 'Radha', 25, 60, 'F', 'Chennai', '9867166678', 'Pain in heart', 'D0005'),
('P0004', 'Chandra', 28, 55, 'F', 'Bangalore', '9978675567', 'Asthma', 'D0001'),
('P0005', 'Goyal', 42, 65, 'M', 'Delhi', '8967533223', 'Pain in Stomach', 'D0004');

select*from Patient_Master

--Room Allocation

CREATE TABLE Room_Alloca(
    room_no VARCHAR(15) NOT NULL,
    pid VARCHAR(15) NOT NULL,
    admission_date DATE NOT NULL,
    release_date DATE,
    FOREIGN KEY (room_no) REFERENCES Room_Master(room_no),
    FOREIGN KEY (pid) REFERENCES Patient_Master(pid)
);
INSERT INTO Room_Alloca(room_no, pid, admission_date, release_date) VALUES
('R0001', 'P0001', '2016-10-15', '2016-10-26'),
('R0002', 'P0002', '2016-11-15', '2016-11-26'),
('R0002', 'P0003', '2016-12-01', '2016-12-30'),
('R0004', 'P0001', '2017-01-01', '2017-01-30');



select*from Room_Alloca


---Questions


--1

select pid, admission_date from  Room_Alloca
where Month(admission_date )=1


--2
select *from Patient_Master where gender = 'F'
  and disease not like '%asthma%';


--3

select gender, count(*) as patient_count from Patient_Master
GROUP BY gender;
 

--4

select p.pid AS patient_id, p.name AS patient_name, d.doctor_id, d.doctor_name,
ra.room_no, rm.room_type, ra.admission_date
from Room_Alloca ra
JOIN Patient_master p ON ra.pid = p.pid
JOIN Doctor_Master d ON p.doctor_id = d.doctor_id
JOIN Room_Master rm ON ra.room_no = rm.room_no;



--5


select room_no from Room_master
WHERE room_no NOT IN ( select distinct  room_no from Room_Alloca);



--6

select rm.room_no, rm.room_type, count(ra.room_no) AS allocation_count
from Room_master rm
JOIN Room_Alloca ra ON rm.room_no = ra.room_no
group by rm.room_no, rm.room_type
having count(ra.room_no) > 1;

