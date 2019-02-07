using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class SendEmailService: IBaseService<ISendEmailModel>
    {
        void SendEmail(string email)
        {
            Console.WriteLine($"send email to {email}");
        }
        public void CallService(ISendEmailModel sendMailModel)
        {
            SendEmail(sendMailModel.Email);
        }
    }
}
