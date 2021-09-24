using System;

namespace Store.Shared.Services
{
    public interface IEmailService
    {
        //usar SendGrid
        void Send(string name, string email, string subject, string body);
    }
}
