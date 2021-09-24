using System;
using Flunt.Validations;
using Store.Domain.ValueObjects;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Document document, DateTime birthDate, Email email, User user)
        {

            Name = name;
            Document = document;
            BirthDate = birthDate;
            Email = email;
            User = user;
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; }
        public User User { get; private set; }
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