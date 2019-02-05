using Services.BLL.BooksService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonbeat
{
    public static class CoreLogic
    {
        //register. Binds of object with his service(s)
        //Book - IBookService, IDeliveryService
        public static Dictionary<string, List<Type>> Register = new Dictionary<string, List<Type>>();
        public static void NewRequest<T>(T model, string type)
        {
            if(model.GetType().Namespace + "_" + model.GetType().Name != type)
            {
                Console.WriteLine("Back error");
                return;
            }
            if (Register[type] is null)
            {
                Console.WriteLine("Service for current type not be found!");
            }
            else
            {
                foreach (Type typeOfService in Register[type])
                {
                    var service = Activator.CreateInstance(typeOfService);
                    Console.WriteLine(service.GetType().Name);
                    //как вызывать методы
                    //
                }
            }
        }
    }
}
