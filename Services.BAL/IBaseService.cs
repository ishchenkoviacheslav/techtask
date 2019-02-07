using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    /// <summary>
    /// If your model have some parameter(s)
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public interface IBaseService<TInterface>
    {
        void CallService(TInterface properties);
    }

    public interface IBaseService
    {
        void CallService();
    }
}
