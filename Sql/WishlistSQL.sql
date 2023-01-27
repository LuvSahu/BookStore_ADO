use BookStore

create table WishList(
WishListId int primary key identity,
UserId int  not null FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId int  not null FOREIGN KEY (BookId) REFERENCES Books(BookId),
)
--------------------------------stored procedure for AddBook-----------------------------
alter procedure SPAddTOWishList(
@UserId int,
@BookId int
)
As
Begin try
DECLARE @Wcount int,@Ccount int;
SET @Ccount=(select count(CartId) from Cart where UserId IN (@UserId) AND BookId IN (@BookId))
SET @Wcount=(select count(WishListId) from WishList where UserId IN (@UserId) AND BookId IN (@BookId))
IF(@Ccount = 0)
  IF(@Wcount = 0)
   insert into WishList(UserId,BookId) values(@UserId,@BookId)
  ELSE
   print'Check if Book is available or Its already in WishList!!'
ElSE
  print'Your Book is already in cart!!'
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


---------------------------------******************************************************************---------------------------

-------------------------------------stored procedure for GetAllWishList------------------------------------------
create procedure SPGetAllWishList(
@UserId int
)
As
Begin try
select 
w.WishListId,b.BookId,b.BookName,b.Author,b.Description,b.Price,b.DiscountPrice,b.BookImg
from WishList w INNER JOIN Books b ON w.BookId = b.BookId where UserId = @UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

------------------------------**************************************************************--------------------------------

--stored procedure for DeleteWishListItem
create procedure SPDeleteWishListItem(
@WishListId int,
@UserId int
)
As
Begin try
delete from WishList where WishListId = @WishListId AND UserId = @UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

-------------------------------------*************************************************************************----------------------------------

-----------------------------stored procedure for GetWishListItemByBookId----------------------------
create procedure SPGetWishListItemByBookId(
@UserId int,
@WishListId int
)
As
Begin try
select 
w.WishListId,b.BookId,b.BookName,b.Author,b.Description,b.Price,b.DiscountPrice,b.BookImg
from WishList w INNER JOIN Books b ON w.BookId = b.BookId where UserId = @UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH



