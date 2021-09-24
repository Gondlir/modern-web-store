using System;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string document, DateTime birthDate, string email, User user)
        {

            Name = name;
            Document = document;
            BirthDate = birthDate;
            Email = email;
            User = user;
        }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}