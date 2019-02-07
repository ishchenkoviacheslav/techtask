using System;
using System.Collections.Generic;
using System.Text;
using Shared.IServiceModel;
namespace Services.BLL
{
    public class GenerateCommissionPaymentService: IService<IGenerateCommissionPaymentModel>
    {
        public void CallService(IGenerateCommissionPaymentModel generateCommissionPaymentModel)
        {
            GenerateCommission(generateCommissionPaymentModel.Sum);
        }

        public void GenerateCommission(float sum)
        {
            Console.WriteLine(nameof(GenerateCommission) + " " + sum);
        }
    }
}
