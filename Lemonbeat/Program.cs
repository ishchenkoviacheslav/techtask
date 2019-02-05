using Services.BLL.BooksService;
using Shared.Book;
using System;
using System.Collections.Generic;

namespace Lemonbeat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Core<Book> core = new Core<Book>();
            //core.Request(new Book {Author = "Anderson", Name = "My life" }, (int)BookOperations.BuyRealBook);
            Book book = new Book() { Author = "Tolkien", Name = "Hobbit" };
            Console.WriteLine(book.GetType().Name);
            CoreLogic.Register.Add(book.GetType().Name, new List<IBaseService>() { new BooksService()});
            Book newBook = new Book() { Author = "asf" };
            CoreLogic.NewRequest(book, book.GetType().Name);
        }
    }
}
