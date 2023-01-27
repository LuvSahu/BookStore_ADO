using BusinessLayer.Interfaces;
using CommonLayer.BookModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public BookDataModel AddBook(BookDataModel bookdataModel)
        {
            try
            {
                return this.bookRL.AddBook(bookdataModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GetBookModel> GetAllBooks()
        {
            try
            {
                return this.bookRL.GetAllBooks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetBookModel GetBookById(int BookId)
        {
            try
            {
                return this.bookRL.GetBookById(BookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetBookModel UpdateBooks(int BookId, BookDataModel bookdataModel)
        {
            try
            {
                return this.bookRL.UpdateBooks(BookId, bookdataModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteBook(int BookId)
        {
            try
            {
                return this.bookRL.DeleteBook(BookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
