using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
namespace Lemonbeat
{
    public static class CoreLogic
    {

        //Register. Binds Model(I+NameOfService+Model) with services (IService<> or IService)
        private static Dictionary<Guid, List<Type>> MainRegister = new Dictionary<Guid, List<Type>>();

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

        //required in relation to services. Than if no services(forgot include), no requirement
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

        public static void RemoveModelFromModelServicePair<TModel>(TModel model)
        {
            if (model==null)
            {
                Console.WriteLine("Model can't be null!");
            }
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
        /// <summary>
        /// Unbind model from some or all service(s).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="listOfServices"></param>
        public static  void UnRegisterationOfModelServicesPair<TModel>(TModel model, List<Type> listOfServices)
        {
            if (model == null || listOfServices == null)
            {
                Console.WriteLine($"Model and list of services can not be null!");
                return;
            }
            if (MainRegister.ContainsKey(model.GetType().GUID))
            {
                List<Type> oldListOfService = MainRegister[model.GetType().GUID];
                //lists must be same (by data, not only by count) 
                if(listOfServices.Count == oldListOfService.Count)
                {
                    //OldListOfService must has more services than list from parameter(listOfService) and include all services which include list from parameter
                    var notSameService = listOfServices.Except(oldListOfService);
                    if (notSameService?.Count()==0)
                    {
                        Console.WriteLine("You want to unregister all services, your Model-Service bind will remove totally");
                        RemoveModelFromModelServicePair(model);
                        return;
                    }
                    Console.WriteLine("Your set of services is different from set of registered services!");
                    return;
                }
                List<Type> updatedListOfServices = (List<Type>)oldListOfService.Except(listOfServices);
                MainRegister.Remove(model.GetType().GUID);
                MainRegister[model.GetType().GUID] = updatedListOfServices;
                Console.WriteLine($"Model-Service(s) pair has been unregistered");
            }
            else
            {
                Console.WriteLine($"Can't unregistered. Model-Service pair not found for current Model.");
            }
        }

        public static void AddNewServiceToModel<TModel>(TModel model, List<Type> listOfServices)
        {
            if (model == null || listOfServices == null)
            {
                Console.WriteLine($"Model and list of services can not be null!");
                return;
            }
            if (MainRegister.ContainsKey(model.GetType().GUID))
            {
                //проверить может быть сервисы уже содержаться
                //если все сервисы новые, значит проверить CheckModelHasAllRequiredInterfaces
                //если и тут ОК, совместить коллекции с сервисами и перезаписть в словарь
            }
            else
            {
                Console.WriteLine($"Can't add new service. Model-Service pair not found for current Model.");
            }
        }

        /// <summary>
        /// Befor you need register(bind) your model for some service(s)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Model must implemented IModel interface for bind with service</param>
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


  
}
