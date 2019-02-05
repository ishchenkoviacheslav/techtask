using Services.BLL.BooksService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL.PhisicalProduct
{
    public interface IPhisicalProduct: IBaseService
    {
        bool MakePackingForShipping(int importantNummer);
    }
}
