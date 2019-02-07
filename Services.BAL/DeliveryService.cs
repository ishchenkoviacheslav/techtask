using System;
using System.Collections.Generic;
using System.Text;
using Shared.Services;
namespace Services.BLL
{
    public class DeliveryService: IService<IDeliveryModel>
    {
        public void AddDelivery(string adress)
        {
            Console.WriteLine(nameof(AddDelivery) + " " + nameof(adress)+ " " + adress);
        }
        public void CallService(IDeliveryModel deliveryModel)
        {
            AddDelivery(deliveryModel.Address);
        }
    }
}
