using Services.BLL;
using Shared.Book;
using Shared.Models.Membership;
using Shared.VideoLesson;
using System;
using System.Collections.Generic;

namespace Lemonbeat
{
    class Program
    {
        static void Main(string[] args)
        {
            //to do: check if this type is registered
            // check if this type is implemented requirement of interfaces
            CoreLogic.Register.Add(new Book().GetType().GUID, new List<Type>() { new BookService().GetType(), new DeliveryService().GetType(), new GenerateCommissionPaymentService().GetType() });
            CoreLogic.Register.Add(new VideoLesson().GetType().GUID, new List<Type> { new VideoLessonService().GetType() });
            CoreLogic.Register.Add(new Person().GetType().GUID, new List<Type> { new MembershipService().GetType() });


            Book book = new Book() { Author = "Tolkien", Name = "Hobbit", Address = "street", Id = 8, ImportantNumber = 234, Sum = (float)4.6 };
            CoreLogic.NewRequest(book);
            VideoLesson lesson = new VideoLesson();
            CoreLogic.NewRequest(lesson);
            Person person = new Person() { Name = "Jon", MembershipAction = MembershipAction.MakeNew, DayOfstart = DateTime.Now };
            CoreLogic.NewRequest(person);
        }
    }
}
