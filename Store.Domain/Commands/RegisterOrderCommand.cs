using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    public class RegisterOrderCommand : Notifiable, ICommand
    {
        public Guid Customer { get; set; }
        public decimal DeliverPrice { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
                       .IsGreaterThan(DeliverPrice, 0, "DeliveryPrice", "Preço da entrega deve ser maior que zero")
                       .IsGreaterThan(Discount, -1, "Discounts", "Disconto precisa ser maior que zero")
                       );
        }
    }
}
