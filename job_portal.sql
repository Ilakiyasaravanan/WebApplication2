---AccountDetails---
Create TABLE tbl_JOBPORTAL(
AccountId int Identity(1,1) Primary key,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20),
Address VARCHAR(50) Not null,
PhoneNumber bigint NOT Null,
Gender Varchar(10) Not null,
UserName bigint,
Password VARCHAR(20),
Role VARCHAR(10) NOT NULL,
Email Varchar(30)
);

---JobDetails----
CREATE TABLE tbl_JobDetails(
AccountId int Foreign key references tbl_JOBPORTAL(AccountId),
Salary int Not Null,
Position VARCHAR(30) NOT NULL,
Graduation VARCHAR(30) NOT NULL,
Type VARCHAR(10));



DROP TABLE tbl_JobDetails;
DROP TABLE tbl_JOBPORTAL;


Insert into tbl_JOBPORTAL VALUES ('Ilakiya','Saravanan','151-A,Saravanan Nagar,Salem-636008',9443322727,'Female',88888888,'ilakiya','Admin','ilakyaengi@gmail.com')


SELECT * FROM tbl_JOBPORTAL;
SELECT * FROM tbl_JobDetails;

create trigger tgr_JobDetails on tbl_JobPortal
After insert
as 
begin
Declare @accountId int;
select @accountId=i.AccountId from inserted i
Insert into tbl_JobDetails(AccountId,Salary,Position,Graduation,Type) VALUES(@accountId,3000,'Dev','BE','FT');
end






----ACCOUNTEXISTS VERIFY----
Alter PROC sp_USERNAMEEEXISTS

@UserName VARCHAR(30)

AS BEGIN
SELECT Role FROM tbl_JOBPORTAL WHERE UserName=@UserName;
END


---SIGUP INSERT DB----
ALTER PROC sp_SIGNUP
@Firstname VARCHAR(20),
@Lastname VARCHAR(20),
@Address VARCHAR(50),
@Phonenumber bigint,
@Email Varchar(30),
@AccountNumber bigint,
@Password VARCHAR(20),
@Role VARCHAR(10),
@Gender VARCHAR(10)
 
AS BEGIN
INSERT INTO tbl_JOBPORTAL(FirstName,LastName,Email,Address,PhoneNumber,UserName,Password,Role,Gender) VALUES(@Firstname,@Lastname,@Email,@Address,@Phonenumber,@AccountNumber,@Password,@Role,@Gender);
END


---LOGIN VERIFICATION----
ALTER PROC sp_LOGIN

@UserName bigint,
@Password VARCHAR(20),
@Role VARCHAR(10) OUTPUT

AS BEGIN
SELECT @Role=role FROM tbl_JOBPORTAL WHERE UserName=@UserName AND Password=@Password;
End


---INSERT DB INTO LIST----
CREATE PROC sp_JOBPORTALDB
AS BEGIN
SELECT * FROM JOBPORTAL;
End



---CRUD-UPDATE GRID---
ALTER PROC sp_JOBPORTALGRID_UPDATE
@firstname VARCHAR(30),
@lastname VARCHAR(30),
@phonenumber bigint,
@address VARCHAR(50),
@gender VARCHAR(10),
@role VARCHAR(10),
@password VARCHAR(20),
@email VARCHAR(30),
@id int
AS
BEGIN
Update tbl_JOBPORTAL SET FirstName=@firstname,LastName=@lastname,Address=@address,Gender=@gender,PhoneNumber=@phonenumber,Role=@Role,Password=@password,Email=@email WHERE AccountId=@id
END


---CRUD-VIEW GRID---
ALTER PROC sp_JOBPORTALGRID_VIEW

AS
BEGIN
select AccountId,FirstName,PhoneNumber,LastName,Address,Password,Gender,Role,Email,UserName from tbl_JOBPORTAL
END

---CRUD-DELETE GRID---
CREATE PROC sp_JOBPORTALGRID_DELETE
@Id bigint

AS
BEGIN
Delete from tbl_JOBPORTAL where AccountId = @Id;
END




DROP PROC sp_SIGNUP;
DROP TABLE tbl_JOBPORTAL;

DROP TABLE tbl_JOBPORTAL;


