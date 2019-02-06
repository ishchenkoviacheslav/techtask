using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    //every service must realize this func. Because this method is start point of service
    public interface IService<T>
    {
        void CallService(T obj);
    }
}
