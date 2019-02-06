using Services.BLL;
using Shared.Book;
using Shared.VideoLesson;
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
            //to do: check if this type is registered
            // check if this type is realized requirement of interfaces
            CoreLogic.Register.Add(someBook.GetType().GUID, services);
            CoreLogic.Register.Add(new VideoLesson().GetType().GUID, new List<Type> { new VideoLessonService().GetType() });


            Book book = new Book() { Author = "Tolkien", Name = "Hobbit" };
            CoreLogic.NewRequest(book);
            VideoLesson lesson = new VideoLesson();
            CoreLogic.NewRequest(lesson);
        }
    }
}
