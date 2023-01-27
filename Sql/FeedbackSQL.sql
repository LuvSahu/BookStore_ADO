Use BookStore

create table Feedbacks(
FeedbackId int primary key identity,
Rating float not null,
Comment varchar(max) not null,
BookId int not null foreign key (BookId) references Books(BookId),
UserId int not null foreign key (UserId) references Users(UserId)
)
-- stored procedure to AddFeedbacks
create proc SPAddFeedback(
@Rating float,
@Comment varchar(max),
@BookId int,
@UserId int
)
as
DECLARE @TotalRating float;
BEGIN TRY
	if(not exists(select * from Feedbacks where BookId=@BookId and UserId=@UserId))
	BEGIN
		insert into Feedbacks(Rating,Comment,BookId,UserId) values(@Rating,@Comment,@BookId,@UserId)
		set @TotalRating = (select AVG(TotalRating) from Books where BookId = @BookId);
		Update Books set TotalRating = @TotalRating, RatingCount = (RatingCount+1) where BookId = @BookId;
	END
END TRY
BEGIN CATCH
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


select * from Feedbacks
select * from Books

--=================================================================

-- stored procedures to GetAllFeddbacksbyBookId
create proc GetFeedbackByBookId(
@BookId int
)
As
BEGIN TRY
	select f.FeedbackId,f.Comment,f.BookId,f.Rating,f.UserId,u.FullName
	from Feedbacks f inner join Users u on f.UserId = u.UserId where BookId = @BookId
END TRY
BEGIN CATCH
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

--======================================================================

--stored procedure for deleteFeedback ByBookId for a Book
create procedure SPDeleteFeedbackById(
@FeedbackId int
)
As
Begin try
delete from Feedbacks where FeedbackId = @FeedbackId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH