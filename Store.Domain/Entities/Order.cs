using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using Store.Domain.Enums;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        public Order(Customer customer, decimal deliveryPrice, decimal discounts)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Status = EOrderStatus.Created;
            DeliveryPrice = deliveryPrice;
            Discounts = discounts;

            _items = new List<OrderItem>();

            AddNotifications(new Contract().Requires()
            .IsGreaterThan(DeliveryPrice, 0, "DeliveryPrice", "Preço da entrega deve ser maior que zero")
            .IsGreaterThan(Discounts, -1, "Discounts", "Disconto precisa ser maior que zero")
            );
        }

        public Customer Customer { get; private set; }

        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public decimal DeliveryPrice { get; private set; }
        public decimal Discounts { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());

        public decimal Total() => SubTotal() + DeliveryPrice - Discounts;

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            if (item.Valid)
            {
                _items.Add(item);
            }
        }
        public void PlaceOrder()
        {

        }

    }
}