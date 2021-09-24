using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Handlers.Contracts;
using Store.Domain.Repositories;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable, IHandler<RegisterOrderCommand>
    {
        private readonly IProductRepository _productRepo;
        private readonly ICustomerRepository _customerRepo;
        public OrderHandler(IProductRepository productRepository, ICustomerRepository customerRepo)
        {
            _productRepo = productRepository;
            _customerRepo = customerRepo;
        }
        public void Handle(RegisterOrderCommand command)
        {

        }
    }
}