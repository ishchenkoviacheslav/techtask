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
            //CoreLogic.RegisterationOfModelServicesPair(new Book(), new List<Type>() { new BookService().GetType(), new DeliveryService().GetType(), new GenerateCommissionPaymentService().GetType() });
            //CoreLogic.RegisterationOfModelServicesPair(new VideoLesson(), new List<Type> { new VideoLessonService().GetType() });
            CoreLogic.RegisterationOfModelServicesPair(new Person(), new List<Type> { new MembershipService().GetType() });

            //Book book = new Book() { Author = "Tolkien", Name = "Hobbit", Address = "street", Id = 8, ImportantNumber = 234, Sum = (float)4.6 };
            //CoreLogic.NewRequest(book);

            //VideoLesson lesson = new VideoLesson() { Author = "Smith", Name = "John", Id = 123 };
            //CoreLogic.NewRequest(lesson);

            Person person = new Person() { Name = "Jon", MembershipAction = MembershipAction.MakeNew, DayOfstart = DateTime.Now };
            CoreLogic.NewRequest(person);

            //CoreLogic.RemoveModelFromModelServicePair(book);
        }
    }
}
