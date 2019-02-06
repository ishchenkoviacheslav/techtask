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
        public static Dictionary<int, List<Type>> Register = new Dictionary<int, List<Type>>();
        public static void NewRequest<T>(T model)
        {
            //check if Dictionary has collections of services for current model
            if (Register[model.GetType().MetadataToken] is null)
            {
                Console.WriteLine("Service for current type not be found!");
            }
            else
            {
                foreach (Type typeOfService in Register[model.GetType().MetadataToken])
                {
                    object service = Activator.CreateInstance(typeOfService);
                    MethodInfo mi = typeOfService.GetMethod("CallService");
                    ParameterInfo[] parameters = mi.GetParameters();
                    if (parameters?.Length == 0)
                        mi.Invoke(service, null);
                    else
                    {
                        string parm = parameters[0].Name;
                        string parm2 = model.GetType().Name;
                        //can i send model to method paremeter?
                        if ( parameters[0].MetadataToken == model.GetType().MetadataToken)
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
