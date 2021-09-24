using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        protected Name() { }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract().Requires()
                        .HasMinLen(FirstName, 3, "FirstName", "O User Name deve conter ao mínimo 3 caracteres !")
                        .HasMaxLen(FirstName, 60, "FirstName", "O User Name conter ao máximo 60 caracteres !")
                        .IsNotNullOrEmpty(FirstName, "FirstName", "O User Name não pode ser vazio !")
                        .HasMaxLen(LastName, 60, "LastName", "A senha deve ter até 12 caracteres !")
                        .HasMinLen(LastName, 3, "LastName", "A senha deve ter no mínimo até 8 caracteres !")
                        .IsNullOrEmpty(FirstName, "FirstName", "O nome não pode ser vazio !")
                        .IsNullOrEmpty(LastName, "FirstName", "O nome não pode ser vazio !")
                        );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
