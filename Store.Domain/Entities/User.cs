using Flunt.Validations;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password)
        {

            Username = username;
            Password = password;
            AddNotifications(new Contract().Requires()
            .HasMinLen(Username, 3, "Username", "O User Name deve conter ao mínimo 3 caracteres !")
            .HasMaxLen(Username, 8, "Username", "O User Name conter ao máximo 8 caracteres !")
            .IsNotNullOrEmpty(Username, "Username", "O User Name não pode ser vazio !")
            .HasMaxLen(Password, 12, "Password", "A senha deve ter até 12 caracteres !")
            .HasMinLen(Password, 8, "Password", "A senha deve ter no mínimo até 8 caracteres !")
            .IsNotNullOrEmpty(Password, "Password", "A senha não pode ser vazia !")
            );
        }


        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;
        public void Desactivate() => Active = false;

        public override string ToString()
        {
            return $"{Username}";
        }

    }
}