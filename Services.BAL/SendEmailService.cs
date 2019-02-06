using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class SendEmailService : IService<string>
    {
        void SendEmail(string email)
        {
            Console.WriteLine($"send email to {email}");
        }
        public void CallService(string email)
        {
            SendEmail(email);
        }
    }
}
