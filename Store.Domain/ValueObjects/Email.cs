using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract().Requires()
                 .IsEmail(Address, "Email", "E-mail inválido"));
        }

        public string Address { get; private set; }
    }
}