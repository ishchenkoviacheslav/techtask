using Services.BLL.BooksService;
using Services.BLL.DeliveryService;
using Shared.Book;
using System;
using System.Collections.Generic;

namespace Lemonbeat
{
    class Program
    {
        static void Main(string[] args)
        {
            Book someBook = new Book();
            List <Type> services = new List<Type>() { new BooksService().GetType(), new DeliveryService().GetType() };
            CoreLogic.Register.Add(someBook.GetType().Namespace + "_" + someBook.GetType().Name, services);

            Book book = new Book() { Author = "Tolkien", Name = "Hobbit" };
            CoreLogic.NewRequest(book, book.GetType().Namespace + "_" + book.GetType().Name);
        }
    }
}
