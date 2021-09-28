using System;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class Product : Notifiable
    {
        protected Product()
        {

        }
        public Product(string title, decimal price, string image, int quantityInBase)
        {
            Id = Guid.NewGuid();
            Title = title;
            Price = price;
            Image = image;
            QuantityInBase = quantityInBase;
        }
        public Guid Id { get; private set; }
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