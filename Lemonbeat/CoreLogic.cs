using Services.BLL.BooksService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonbeat
{
    public static class CoreLogic
    {
        //add every new Interface/service. All interfaces must inherited from IBaseService
        public static List<IBaseService> AllServices = new List<IBaseService>();
        //register. Binds of object with his service(s)
        //Book - IBookService
        public static Dictionary<string, List<IBaseService>> Register = new Dictionary<string, List<IBaseService>>();
        public static void NewRequest<T>(T model, string type)
        {
            if(model.GetType().Name != type)
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
                Console.WriteLine(Register[type][0].GetType().Name);
            }
        }
    }
}
