using System;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    public class RegisterCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
            .HasMinLen(FirstName, 3, "FirstName", "O User Name deve conter ao mínimo 3 caracteres !")
            .HasMaxLen(FirstName, 60, "FirstName", "O User Name conter ao máximo 60 caracteres !")
            .HasMaxLen(LastName, 60, "LastName", "A senha deve ter até 12 caracteres !")
            .HasMinLen(LastName, 3, "LastName", "A senha deve ter no mínimo até 8 caracteres !")
            .IsNotNullOrEmpty(FirstName, "FirstName", "O nome não pode ser vazio !")
            .IsNotNullOrEmpty(LastName, "FirstName", "O nome não pode ser vazio !")
            .IsEmail(Email, "Email", "E-mail inválido")
            .HasMaxLen(Document, 11, "Document", "Documento Inválido !")
            .HasMinLen(Document, 11, "Document", "Documento Inválido !")
            .IsNotNullOrEmpty(Document, "Document", "Documento Inválido !")
            .HasMinLen(Username, 3, "Username", "O User Name deve conter ao mínimo 3 caracteres !")
            .HasMaxLen(Username, 8, "Username", "O User Name conter ao máximo 8 caracteres !")
            .IsNotNullOrEmpty(Username, "Username", "O User Name não pode ser vazio !")
            .HasMaxLen(Password, 12, "Password", "A senha deve ter até 12 caracteres !")
            .HasMinLen(Password, 8, "Password", "A senha deve ter no mínimo até 8 caracteres !")
            .IsNotNullOrEmpty(Password, "Password", "A senha não pode ser vazia !")
            .HasMaxLen(ConfirmPassword, 12, "confirmpassword", "A senha deve ter até 12 caracteres !")
            .HasMinLen(ConfirmPassword, 8, "confirmpassword", "A senha deve ter no mínimo até 8 caracteres !")
            .IsNotNullOrEmpty(ConfirmPassword, "confirmpassword", "A senha não pode ser vazia !")
            .AreEquals(Password, ConfirmPassword, "Password", "Senhas não coincidem !"));

        }
    }
}