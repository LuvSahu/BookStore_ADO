using CommonLayer.BookModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBookBL
    {
        public BookDataModel AddBook(BookDataModel bookdataModel);
        public List<GetBookModel> GetAllBooks();

        public GetBookModel UpdateBooks(int BookId, BookDataModel bookdataModel);

        public GetBookModel GetBookById(int BookId);

        public bool DeleteBook(int BookId);
    }
}
