using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Contracts;
using Store.Domain.Entities;
using Store.Domain.Handlers.Contracts;
using Store.Domain.Repositories;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable, IHandler<RegisterOrderCommand>
    {
        private readonly IProductRepository _productRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IOrderRepository _orderRepo;
        public OrderHandler(IProductRepository productRepository, ICustomerRepository customerRepo, IOrderRepository orderRepo)
        {
            _productRepo = productRepository;
            _customerRepo = customerRepo;
            _orderRepo = orderRepo;
        }
        public ICommandResult Handle(RegisterOrderCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Opaa, parece que deu algo errado no registro !", command.Notifications);
            }
            var customer = _customerRepo.GetCustomer(command.Customer);
            var order = new Order(customer, command.DeliverPrice, command.Discount);

            foreach (var item in command.Items)
            {
                var product = _productRepo.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            _orderRepo.Save(order);
            return new GenericCommandResult(true, "Ordem cadastrada com sucesso !", command.Notifications);
        }
    }
}