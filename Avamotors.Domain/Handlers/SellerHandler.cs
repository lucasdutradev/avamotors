using Avamotors.Domain.Commands;
using Avamotors.Domain.Commands.Contracts;
using Avamotors.Domain.Handlers.Contracts;
using Flunt.Notifications;

namespace Avamotors.Domain.Handlers;

public class SellerHandler :
	Notifiable<Notification>,
	IHandler<CreateNewSellerCommand>
{
	public ICommandResult Handle(CreateNewSellerCommand command)
	{
		throw new NotImplementedException();
	}
}