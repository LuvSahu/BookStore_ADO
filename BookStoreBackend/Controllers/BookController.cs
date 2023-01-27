using BusinessLayer.Interfaces;
using CommonLayer.BookModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        [Authorize(Roles = Role.Users)]
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookDataModel bookdataModel)
        {
            try
            {
                var result = this.bookBL.AddBook(bookdataModel);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "Book Add Failed " });
                }

                return this.Ok(new { success = true, Message = "Book Added Sucessfully", data = "Book Added :- " + result.BookName });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = this.bookBL.GetAllBooks();
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "No Books Available!!" });
                }

                return this.Ok(new { success = true, Message = "Books records fetched Sucessfully...", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize(Roles = Role.Users)]
        [HttpPost("UpdateBooks")]
        public IActionResult UpdateBooks(int BookId, BookDataModel bookPostModel)
        {
            try
            {
                var result = this.bookBL.UpdateBooks(BookId, bookPostModel);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "Book update Failed" });
                }

                return this.Ok(new { success = true, Message = "Book Updated Sucessfully", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int BookId)
        {
            try
            {
                var result = this.bookBL.GetBookById(BookId);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "No Book with this Id Available!!" });
                }

                return this.Ok(new { success = true, Message = $"Book details fetched Sucessfully... BookId : {result.BookId}", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize(Roles = Role.Users)]
        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int BookId)
        {
            try
            {
                var result = this.bookBL.DeleteBook(BookId);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, Message = $"Something went wrong while deleting the book!! BookId : {BookId}" });
                }

                return this.Ok(new { success = true, Message = $"Book Deleted Sucessfully... BookId : {BookId}" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
