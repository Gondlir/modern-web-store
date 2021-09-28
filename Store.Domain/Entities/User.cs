using System;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class User : Notifiable
    {
        protected User()
        {

        }
        public User(string username, string password, string confirmpassword)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = EncryptPassword(password);
            ConfirmPassword = password;
            AddNotifications(new Contract().Requires()
            .HasMinLen(Username, 3, "Username", "O User Name deve conter ao mínimo 3 caracteres !")
            .HasMaxLen(Username, 8, "Username", "O User Name conter ao máximo 8 caracteres !")
            .IsNotNullOrEmpty(Username, "Username", "O User Name não pode ser vazio !")
            .HasMaxLen(Password, 12, "Password", "A senha deve ter até 12 caracteres !")
            .HasMinLen(Password, 8, "Password", "A senha deve ter no mínimo até 8 caracteres !")
            .IsNotNullOrEmpty(Password, "Password", "A senha não pode ser vazia !")
            .HasMaxLen(confirmpassword, 12, "confirmpassword", "A senha deve ter até 12 caracteres !")
            .HasMinLen(confirmpassword, 8, "confirmpassword", "A senha deve ter no mínimo até 8 caracteres !")
            .IsNotNullOrEmpty(confirmpassword, "confirmpassword", "A senha não pode ser vazia !")
            .AreEquals(Password, EncryptPassword(password), "Password", "Senhas não coincidem !")
            );
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;
        public void Desactivate() => Active = false;

        public override string ToString()
        {
            return $"{Username}";
        }
        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(Password)) return "";
            var password = (pass += "|82f6a4ce02b8ffe953bc05c8763549b5");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.GetEncoding("pt-BR").GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }

    }
}