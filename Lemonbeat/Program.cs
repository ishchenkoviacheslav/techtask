using Services.BLL;
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
            List<Type> services = new List<Type>() { new BooksService().GetType(), new DeliveryService().GetType(), new PhisicalProductService().GetType() };
            CoreLogic.Register.Add(someBook.GetType().MetadataToken, services);

            Book book = new Book() { Author = "Tolkien", Name = "Hobbit" };
            CoreLogic.NewRequest(book);
        }
    }
}
