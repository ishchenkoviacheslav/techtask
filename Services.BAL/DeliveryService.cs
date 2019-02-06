using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class DeliveryService: IService<string>
    {
        public void AddDelivery(string adress)
        {
            Console.WriteLine(nameof(AddDelivery) + " " + nameof(adress)+ " " + adress);
        }
        public void CallService(string adress)
        {
            AddDelivery(adress);
        }
    }
}
