using System;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{

    public class OrderItem : Notifiable
    {
        protected OrderItem()
        {

        }
        public OrderItem(Product product, int quantity)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            if (Product.QuantityInBase <= quantity)
            {
                AddNotification("Quantidade", "A quantidade não tem no estoque !");
            }

            AddNotifications(new Contract().Requires()
            .IsGreaterThan(Quantity, 1, "Quantity", "Quantidade não pode ser menor que um !")
            );
            Product.DecreaseQuantity(quantity);
        }
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal Total() => Price * Quantity;
    }
}