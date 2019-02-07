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
            //one item is name of interface and collection of properties names by order!
            Dictionary<string, List<string>> interfacesPropertiesNames = new Dictionary<string, List<string>>();
            foreach (Type interfaceType in model.GetType().GetInterfaces())
            {
                List<string> namesOfPropsByOrder = new List<string>();
                PropertyInfo[] propsInfo = interfaceType.GetProperties();
                for (int i = 0; i < propsInfo.Length; i++)
                {
                    namesOfPropsByOrder.Add(propsInfo[i].Name);
                }
                interfacesPropertiesNames.Add(interfaceType.Name, namesOfPropsByOrder);
            }
            //check if Dictionary has collections of services for current model
            if (Register[model.GetType().GUID] is null)
            {
                Console.WriteLine("Service for current type not be found!");
                return;
            }
            else
            {
                foreach (Type typeOfService in Register[model.GetType().GUID])
                {
                    //example: from BookService to IBookModel
                    string currKey = "I" + typeOfService.Name.Replace("Service", "Model");
                    List<string> currPropertiesNames = new List<string>();
                    //search current interface(him properties names by order)
                    //if no key will found(if model not implement interface) all still OK
                    interfacesPropertiesNames.TryGetValue(currKey,out currPropertiesNames);
                    object service = Activator.CreateInstance(typeOfService);
                    MethodInfo mi = typeOfService.GetMethod("CallService");
                    ParameterInfo[] parameters = mi.GetParameters();
                    if (parameters?.Length == 0)
                    {
                        mi.Invoke(service, null);
                    }
                    else
                    {
                        List<object> parametersData = new List<object>();
                        if(parameters.Length != currPropertiesNames.Count)
                            Console.WriteLine("FATAL ERROR!");
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            parametersData.Add(model.GetType().GetProperty(currPropertiesNames[i]).GetValue(model, null));
                        }
                        //properties for all services must still in one object, that's why we have only one parameter
                        //but one service can has few parameters
                        mi.Invoke(service, parametersData.ToArray());
                    }
                }
            }
        }
    }
}
