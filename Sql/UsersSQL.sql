Create database BookStore

use BookStore

Create Table Users
(
UserId int identity(1,1) Primary key,
FullName varchar(250) not null,
Email varchar(180) not null,
Password varchar(50) not null,
MobileNumber bigint not null
)

Select * from Users


-------------- Store procedure for registeration -------------
Create proc UserRegister
(
@FullName varchar(250),
@Email varchar(180),
@Password varchar(50),
@MobileNumber bigint
)
As
Begin
	insert Users
	values (@FullName, @Email, @Password, @MobileNumber)
End;
-----STORED PROCEDURE FOR GET ALL USERS-----

CREATE PROCEDURE GetAllUsersSP
As
Begin
select * from Users
end


------------- Store Procedure for Login---------------
ALTER proc LogIn
(
@Email varchar(180),
@Password varchar(50)
)
As
Begin try
select * from Users where Email=@Email and Password=@Password
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH
------------------stored procedure for ForgotPassword------------------
create procedure SPForgotPassword(
@Email varchar(255)
)
As
Begin try
select * from Users where Email=@Email
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

-----------------------------------stored procedure for ResetPassword----------------------------------------
create procedure SPResetPassword(
@Email varchar(255),
@Password varchar(255)
)
AS
BEGIN TRY
update Users set Password=@Password where Email=@Email
END TRY
BEGIN CATCH
SELECT
      ERROR_NUMBER() AS ErrorNumber,
	  ERROR_STATE() AS ErrorState,
	  ERROR_PROCEDURE() AS ErrorProcedure,
	  ERROR_LINE() AS ErrorLine,
	  ERROR_MESSAGE() AS ErrorMessage
END CATCH
