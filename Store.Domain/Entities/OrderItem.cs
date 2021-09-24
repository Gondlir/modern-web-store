using Flunt.Validations;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
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

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal Total() => Price * Quantity;
    }
}