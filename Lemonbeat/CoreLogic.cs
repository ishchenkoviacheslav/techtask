using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
namespace Lemonbeat
{
    public static class CoreLogic
    {
        /// <summary>
        /// Registration of Model-Services pair. Back error if current Model is already registered
        /// </summary>
        /// <param name="typeModel">Type object of your Model. Ex: myBook.GetType() </param>
        /// <param name="listOfServices">List of services for current Model. Model must has implementation of model's Interface required of service</param>
        public static void RegisterationOfModelServicesPair<TModel>(TModel model, List<Type> listOfServices)
        {
            if(model == null || listOfServices == null)
            {
                Console.WriteLine($"Model and list of services can not be null!");
                return;
            }
            if (MainRegister.ContainsKey(model.GetType().GUID))
            {
                Console.WriteLine($"Model {model} already registered!");
                return;
            }
            if(CheckModelHasAllRequiredInterfaces(model, listOfServices))
            {
                MainRegister.Add(model.GetType().GUID, listOfServices);
            }
            else
            {
                Console.WriteLine("Model implemented not all interfaces. Not Registered!");
            }

        }

        private static bool CheckModelHasAllRequiredInterfaces<TModel>(TModel model, List<Type> listOfServices)
        {
            bool IsAllOK = true;
            //check if model implemented all interfaces for each service
            foreach (Type service in listOfServices)
            {
                //here must be only one parameter and it must be interface 
                ParameterInfo[] parameters = service.GetMethod("CallService").GetParameters();
                if (parameters.Length > 0)
                {
                    Type[] allInterfaces = model.GetType().GetInterfaces();
                    //that interface must include into AllInterfaces
                    //parameters[0] because CallMethod always take only 1 parameter(some interface)
                    if (allInterfaces.FirstOrDefault(ai => ai.Name == parameters[0].ParameterType.Name) == null)
                    {
                        Console.WriteLine($"Interface {parameters[0].ParameterType.Name} not implemented!");
                        IsAllOK = false;
                        return IsAllOK;
                    }
                }
                else
                {
                    //some model may has no parameter required
                }
            }
            if(listOfServices.Count == 0)
                Console.WriteLine("Model required no one service! All OK");
            return IsAllOK;
        }

        public static void RemoveModelFromModelServicePair<T>(T model)
        {
            if (MainRegister.ContainsKey(model.GetType().GUID))
            {
                MainRegister.Remove(model.GetType().GUID);
                Console.WriteLine($"Model-Service pair has been removed");
            }
            else
            {
                Console.WriteLine($"Can't remove. Model-Service pair not found for current Model.");
            }
        }
        public static  void UnRegisterationOfModelServicesPair<T>(T model, LinkedList<Type> listOfServices)
        {

        }

        //Register. Binds Model(I+NameOfService+Model) with services (IService<> or IService)
        private static Dictionary<Guid, List<Type>> MainRegister = new Dictionary<Guid, List<Type>>();
        public static void NewRequest<T>(T model)
        {
            try
            {
                //check if Dictionary has collections of services for current model
                if (!MainRegister.ContainsKey(model.GetType().GUID))
                {
                    Console.WriteLine("Service for current type not be found!");
                    return;
                }
                else
                {
                    foreach (Type typeOfService in MainRegister[model.GetType().GUID])
                    {
                        object service = Activator.CreateInstance(typeOfService);
                        MethodInfo mi = typeOfService.GetMethod("CallService");
                        ParameterInfo[] parameters = mi.GetParameters();
                        if (parameters?.Length == 0)
                        {
                            mi.Invoke(service, null);
                        }
                        else
                        {
                            try
                            {
                                mi.Invoke(service, new object[] { model });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


    //public static class CoreLogic
    //{
    //    //register. Binds of object with his service(s)
    //    //Book - IBookService, IDeliveryService
    //    public static Dictionary<Guid, List<Type>> Register = new Dictionary<Guid, List<Type>>();
    //    public static void NewRequest<T>(T model)
    //    {
    //        //one item is name of interface and collection of properties names by order!
    //        Dictionary<string, List<string>> interfacesPropertiesNames = new Dictionary<string, List<string>>();
    //        foreach (Type interfaceType in model.GetType().GetInterfaces())
    //        {
    //            List<string> namesOfPropsByOrder = new List<string>();
    //            PropertyInfo[] propsInfo = interfaceType.GetProperties();
    //            for (int i = 0; i < propsInfo.Length; i++)
    //            {
    //                namesOfPropsByOrder.Add(propsInfo[i].Name);
    //            }
    //            interfacesPropertiesNames.Add(interfaceType.Name, namesOfPropsByOrder);
    //        }
    //        //check if Dictionary has collections of services for current model
    //        if (Register[model.GetType().GUID] is null)
    //        {
    //            Console.WriteLine("Service for current type not be found!");
    //            return;
    //        }
    //        else
    //        {
    //            foreach (Type typeOfService in Register[model.GetType().GUID])
    //            {
    //                //example: from BookService to IBookModel
    //                string currKey = "I" + typeOfService.Name.Replace("Service", "Model");
    //                List<string> currPropertiesNames = new List<string>();
    //                //search current interface(him properties names by order)
    //                //if no key will found(if model not implement interface) all still OK
    //                interfacesPropertiesNames.TryGetValue(currKey, out currPropertiesNames);
    //                object service = Activator.CreateInstance(typeOfService);
    //                MethodInfo mi = typeOfService.GetMethod("CallService");
    //                ParameterInfo[] parameters = mi.GetParameters();
    //                if (parameters?.Length == 0)
    //                {
    //                    mi.Invoke(service, null);
    //                }
    //                else
    //                {
    //                    List<object> parametersData = new List<object>();
    //                    if (parameters.Length != currPropertiesNames.Count)
    //                        Console.WriteLine("FATAL ERROR!");
    //                    for (int i = 0; i < parameters.Length; i++)
    //                    {
    //                        parametersData.Add(model.GetType().GetProperty(currPropertiesNames[i]).GetValue(model, null));
    //                    }
    //                    //properties for all services must still in one object, that's why we have only one parameter
    //                    //but one service can has few parameters
    //                    mi.Invoke(service, parametersData.ToArray());
    //                }
    //            }
    //        }
    //    }
    //}
}
