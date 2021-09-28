using System;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    public class RegisterOrderItemCommand : Notifiable, ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
                        .IsGreaterThan(Quantity, 1, "Quantity", "Quantidade não pode ser menor que um !")
                        );
        }
    }
}
