using System;
using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    public class RegisterOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}
