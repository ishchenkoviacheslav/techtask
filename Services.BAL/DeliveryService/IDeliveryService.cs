using Services.BLL.BooksService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL.DeliveryService
{
    public interface IDeliveryService: IBaseService
    {
        void AddDelivery(string adress);
    }
}
