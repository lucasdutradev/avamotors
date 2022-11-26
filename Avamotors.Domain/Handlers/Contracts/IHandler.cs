using Avamotors.Domain.Commands.Contracts;

namespace Avamotors.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
	ICommandResult Handle(T command);
}