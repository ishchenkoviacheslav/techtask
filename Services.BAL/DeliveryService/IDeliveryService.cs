using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public interface IDeliveryService: IBaseService
    {
        void AddDelivery(string adress);
    }
}
