using DB.DAL;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL.BooksService
{
    public static class BooksService 
    {
        private static DbContext context = new DbContext();
       public static BookException Process(List<string> actions, Book book)
        {
            try
            {
                book.Validate();
                context.Books.Add(book);
                context.Save();
                return null;
            }
            catch (BookException bookEx)
            {
                return bookEx;
            }
            
        }
    }
}
