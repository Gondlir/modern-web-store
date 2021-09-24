using System;
using System.Collections.Generic;
using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    public class RegisterOrderCommand : ICommand
    {
        public Guid Customer { get; set; }
        public decimal DeliverPrice { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }
    }
}
