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
                        //can i send model to method paremeter? Is it same type?
                        //now work only with 1 parameter
                        //properties for all services must still in one object, that's why we have only one parameter
                        if (parameters[0].ParameterType.FullName == model.ToString())
                        {
                            mi.Invoke(service, new object[] { model});
                        }
                        else
                        {
                            Console.WriteLine("Error. Service has different type of parameter!");
                        }
                    }
                }
            }
        }
    }
}
