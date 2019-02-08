using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    /// <summary>
    /// If your model have some parameter(s)
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public interface IService<TModelInterface>
    {
        void CallService(TModelInterface properties);
    }

    public interface IService
    {
        void CallService();
    }
}
