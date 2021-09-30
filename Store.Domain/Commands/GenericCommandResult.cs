using System;
using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Message { get; set; }
    }
}
