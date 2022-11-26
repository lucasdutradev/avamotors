using Avamotors.Domain.Commands;
using Avamotors.Domain.Commands.Contracts;
using Avamotors.Domain.Commands.Result;
using Avamotors.Domain.Entities;
using Avamotors.Domain.Handlers.Contracts;
using Avamotors.Domain.Repositories;
using Flunt.Notifications;

namespace Avamotors.Domain.Handlers;

public class CarHandler :
	Notifiable<Notification>,
	IHandler<CreateCarSellerCommand>
{
	private readonly ICarRepositories _repositoryCar;
	private readonly ISellerRepositories _repositorySeller;

	public CarHandler(ICarRepositories repositoryCar, ISellerRepositories repositorySeller)
	{
		_repositoryCar = repositoryCar;
		_repositorySeller = repositorySeller;
	}
	public ICommandResult Handle(CreateCarSellerCommand command)
	{
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "invalid command", command.Notifications);


		var newCar = new Car(command.Name, command.Km, command.Year, command.Model, command.Description, command.Image);

		var seller = _repositorySeller.GetById(command.SellerId);
		newCar.AddCarASeller(seller);

		_repositoryCar.Create(newCar, seller);


		return new GenericCommandResult(true, "Carro criado com sucesso", newCar);
	}
}