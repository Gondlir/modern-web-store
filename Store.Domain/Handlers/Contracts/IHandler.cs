using Store.Domain.Commands.Contracts;

namespace Store.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}