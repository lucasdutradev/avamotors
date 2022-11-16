namespace Avamotors.Domain.Commands.Contracts;

public interface ICommand
{
	bool Validate();
}