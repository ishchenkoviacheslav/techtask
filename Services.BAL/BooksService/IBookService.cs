using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public interface IBookService: IBaseService
    {
        void DuplicatePackingSlipForRoyalty();
        void GenerateCommission(float sum);
    }
}
