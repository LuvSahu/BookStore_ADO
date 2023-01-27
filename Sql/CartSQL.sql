Use BookStore

create table Cart(
CartId int primary key identity,
UserId int  not null FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId int  not null FOREIGN KEY (BookId) REFERENCES Books(BookId),
BookQuantity int not null
)
select * from Cart

-----------------------------*************************************************************************------------------------------------
create procedure SPAddBookTOCart(
@UserId int,
@BookId int,
@BookQuantity int
)
As
Begin try
DECLARE @count int;
SET @count=(select count(CartId) from Cart where UserId IN (@UserId) AND BookId IN (@BookId))
IF(@count = 0)
insert into Cart(UserId,BookId,BookQuantity) values(@UserId,@BookId,@BookQuantity)
ELSE
print'Check if Book is available or Its already in Cart!!'
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


---------------------------------------*********************************************************************************-----------------------------------------------

-----------------stored procedure for GetALlBookInCart-----------------------------
create procedure SPGetAllBooksInCart(
@UserId int
)
As
Begin try
select 
c.CartId,b.BookId,b.BookName,b.Author,b.Description,c.BookQuantity,b.Price,b.DiscountPrice,b.BookImg
from Cart c INNER JOIN Books b ON c.BookId = b.BookId where UserId = @UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

--------------------------------------======================================================================---------------------

--stored procedure for UpdateCartbyCartId
create procedure SPUpdateCartItem(
@UserId int,
@CartId int,
@BookId int,
@BookQuantity int
)
As
Begin try
update Cart set BookQuantity=@BookQuantity where CartId = @CartId and UserId = @UserId and BookId = @BookId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH



----------------------------------------======================================================================**************************************************

--stored procedure for deleteCartItem
create procedure SPDeleteCartItem(
@CartId int,
@UserId int
)
As
Begin try
delete from Cart where CartId=@CartId AND UserId=@UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

-------------------************************************************************************------------------------------

---------------------------------------stored procedure for GetCartItemByCartId-----------------------------------------
create procedure SPGetCartItemByCartId(
@UserId int,
@CartId int
)
As
Begin try
select 
c.CartId,b.BookId,b.BookName,b.Author,b.Description,c.BookQuantity,b.Price,b.DiscountPrice,b.BookImg
from Cart c INNER JOIN Books b ON c.BookId = b.BookId where UserId = @UserId and CartId = @CartId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


