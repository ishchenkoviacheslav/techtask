using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lemonbeat
{
    public static class CoreLogic
    {
        //register. Binds of object with his service(s)
        //Book - IBookService, IDeliveryService
        public static Dictionary<Guid, List<Type>> Register = new Dictionary<Guid, List<Type>>();
        public static void NewRequest<T>(T model)
        {
            //check if Dictionary has collections of services for current model
            if (Register[model.GetType().GUID] is null)
            {
                Console.WriteLine("Service for current type not be found!");
            }
            else
            {
                foreach (Type typeOfService in Register[model.GetType().GUID])
                {
                    object service = Activator.CreateInstance(typeOfService);
                    MethodInfo mi = typeOfService.GetMethod("CallService");
                    ParameterInfo[] parameters = mi.GetParameters();
                    if (parameters?.Length == 0)
                        mi.Invoke(service, null);
                    else
                    {

                        for (int i = 0; i < parameters.Length; i++)
                        {
                            //parameters[i]

                        }
                        //properties for all services must still in one object, that's why we have only one parameter
                        //but one service can has 
                            //how to know which parameter i need....
                            mi.Invoke(service, new object[] { });
                            Console.WriteLine("Error. Service has different type of parameter!");
                    }
                }
            }
        }
    }
}
