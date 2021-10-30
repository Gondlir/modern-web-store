using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands;
using Store.Domain.Handlers;

namespace Store.Api
{
    public class OrderController
    {
        private readonly OrderHandler _handler;
        public OrderController(OrderHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/orders")]
        public GenericCommandResult PostOrder([FromBody] RegisterOrderCommand command, [FromServices] OrderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}