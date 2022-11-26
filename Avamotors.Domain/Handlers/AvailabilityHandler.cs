using Avamotors.Domain.Commands;
using Avamotors.Domain.Commands.Contracts;
using Avamotors.Domain.Commands.Result;
using Avamotors.Domain.Entities;
using Avamotors.Domain.Handlers.Contracts;
using Avamotors.Domain.Repositories;
using Flunt.Notifications;

namespace Avamotors.Domain.Handlers;

public class AvailabilityHandler :
	Notifiable<Notification>,
	IHandler<AddNewAvailabilityInCarCommand>
{

	private readonly IAvailabilityRepositories _repository;
	public ICommandResult Handle(AddNewAvailabilityInCarCommand command)
	{
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "invalid command", command.Notifications);

		var newAvailability = new Availability(command.Date, command.PriceInThisDay, command.CarId);

		_repository.Create(newAvailability);

		return new GenericCommandResult(true, "Data criada com sucesso", newAvailability);
	}
}