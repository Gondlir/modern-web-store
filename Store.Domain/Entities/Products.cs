using Flunt.Validations;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, decimal price, string image, int quantityInBase)
        {
            Title = title;
            Price = price;
            Image = image;
            QuantityInBase = quantityInBase;
        }

        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public int QuantityInBase { get; set; }

        public void DecreaseQuantity(int quantity)
        {
            QuantityInBase -= quantity;
        }

    }
}