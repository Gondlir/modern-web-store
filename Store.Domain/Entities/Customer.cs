using System;
using Flunt.Validations;
using Store.Domain.ValueObjects;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class Customer
    {
        protected Customer()
        {

        }
        public Customer(Name name, Document document, Email email, User user)
        {
            Id = Guid.NewGuid();
            Name = name;
            Document = document;
            BirthDate = null;
            Email = email;
            User = user;
        }
        public Guid Id { get; private set; }
        public virtual Name Name { get; private set; }
        public virtual Document Document { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public virtual Email Email { get; private set; }
        public virtual User User { get; private set; }
        public override string ToString()
        {
            return $"{Name}";
        }
        public void UpdateCustomer(Name name, DateTime birthdate)
        {
            Name = name;
            BirthDate = birthdate;
        }
    }
}