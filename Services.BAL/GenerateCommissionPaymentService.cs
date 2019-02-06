using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class GenerateCommissionPaymentService: IService<float>
    {
        public void CallService(float sum)
        {
            GenerateCommission(sum);
        }

        public void GenerateCommission(float sum)
        {
            Console.WriteLine(nameof(GenerateCommission) + " " + sum);
        }
    }
}
