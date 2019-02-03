using DB.DAL;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL.BooksService
{
    public static class BooksService 
    {
        private static DbContext context = new DbContext();
       public static bool Process(List<string> actions, Book book)
        {
            context.Books.Add(book);
            context.Save();
            return true;
        }
    }
}
