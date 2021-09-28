using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Contracts;
using Store.Domain.Entities;
using Store.Domain.Handlers.Contracts;
using Store.Domain.Repositories;
using Store.Domain.ValueObjects;
using Store.Shared.Services;

namespace Store.Domain.Handlers
{
    public class UpdateCustomerHandler : Notifiable,
    IHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IEmailService _emailService;

        public ICommandResult Handle(RegisterCustomerCommand command)
        {

            command.Validate();
            if (_customerRepo.DocumentExist(command.Document))
            {

                return new GenericCommandResult
                {
                    Message = "Não foi possível realizar cadastro. Documento já cadastrado !"
                };
            }

            if (command.Invalid)
                return new GenericCommandResult
                {
                    Message = ("Opaa, parece que deu algo errado no registro !")
                };
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, document, email, user);

            _customerRepo.Save(customer);
            //enviar email
            // _emailService.Send(
            //     customer.Name.ToString(), 
            //     customer.Email.Address, 
            //     "Bem Vindo a eiMaZon", string.Format(EmailTemplate ))
            //
            return new GenericCommandResult
            {
                Name = customer.Name.ToString(),
                Message = "Cadastrado com sucesso !"
            };
        }
    }
}
