using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public interface IPhisicalProductService: IBaseService
    {
        bool MakePackingForShipping(int importantNummer);
    }
}
