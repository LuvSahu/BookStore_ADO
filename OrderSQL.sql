use Bookstore

create table Orders(
OrderId int primary key identity,
UserId int not null FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId int not null FOREIGN KEY (BookId) REFERENCES Books(BookId),
AddressId int not null FOREIGN KEY (AddressId) REFERENCES Address(AddressId),
OrderQuantity int not null,
TotalOrderPrice money not null,
OrderDate datetime Default getdate()   --sysdatetime and getdate will give same output 
)

select * from Orders
drop table Orders

alter procedure SPAddOrder(
@CartId int,
@AddressId int
)
As
Begin try
Select c.CartId,c.UserId,c.BookId,b.Quantity,b.DiscountPrice,c.BookQuantity into tempdetails from Cart c Inner join Books b on c.BookId = b.BookId where CartId = @CartId
Declare @UserId int = (select UserId from tempdetails)
Declare @BookId int = (select BookId from tempdetails)
DECLARE @BookPrice float =(select DiscountPrice from tempdetails)
DECLARE @QuantityAvail int =(select Quantity from tempdetails)
Declare @OrderQuantity int = (select BookQuantity from tempdetails)

IF ((@UserId != 0) AND (@QuantityAvail > @OrderQuantity))
BEGIN
    Declare @TotalOrderPrice money = (@BookPrice * @OrderQuantity)
	DECLARE @BookPresentInWishList int =(select Count(WishListId) from WishList where BookId= @BookId)	
	IF(@BookPresentInWishList>0)
	BEGIN
	 delete from WishList where BookId = @BookId and UserId=@UserId
    END
	 insert into Orders(UserId,BookId,AddressId,OrderQuantity,TotalOrderPrice) values(@UserId,@BookId,1,@OrderQuantity,@TotalOrderPrice)
	 IF(@@ROWCOUNT > 0)
	 BEGIN
	   delete from Cart where CartId = @CartId
	   DECLARE @Booksleft int = @QuantityAvail - @OrderQuantity
	   update Books SET Quantity = @Booksleft where BookId = @BookId
	 END
	 drop table tempdetails
END
ELSE
	drop table tempdetails
    print 'Books available in stock are only'+CAST(@BookId AS VARCHAR(255))
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

select * from tempdetails
select * from Books
select * from WishList
select * from Address
select * from orders
truncate table orders
select * from Cart
truncate table Cart
truncate table WishList
drop procedure AddOrderSP

--======================================================================

--stored procedure for GetAllOrders
create procedure SPGetAllOrders(
@UserId int
)
As
Begin try
select 
o.OrderId,o.UserId,o.BookId,o.AddressId,o.OrderQuantity,o.TotalOrderPrice,o.OrderDate,b.BookName,b.Author,b.BookImg
from Orders o INNER JOIN Books b ON o.BookId = b.BookId where UserId = @UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

