using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class PhisicalProductService
    {
        public bool MakePackingForShipping(int importantNummer)
        {
            Console.WriteLine(nameof(MakePackingForShipping) + " " + nameof(importantNummer) +":"+importantNummer);
            return true;
        }
        public void CallService(int number)
        {
            MakePackingForShipping(number);
        }
    }
}
