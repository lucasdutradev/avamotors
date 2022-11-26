using Avamotors.Domain.Commands;
using Avamotors.Domain.Commands.Contracts;
using Avamotors.Domain.Commands.Result;
using Avamotors.Domain.Entities;
using Avamotors.Domain.Handlers.Contracts;
using Avamotors.Domain.Repositories;
using Avamotors.Domain.Shared.VOs;
using Flunt.Notifications;

namespace Avamotors.Domain.Handlers;

public class SellerHandler :
	Notifiable<Notification>,
	IHandler<CreateNewSellerCommand>,
	IHandler<UpdateSellerCommand>
{
	private readonly ISellerRepositories _repository;

	public SellerHandler(ISellerRepositories repository)
	{
		_repository = repository;
	}

	public ICommandResult Handle(CreateNewSellerCommand command)
	{
		// FFV
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "Parece que seu vendedor tem campos errados", command.Notifications);

		//Gerar um Seller
		var name = new Name(command.FirstName, command.LastName);
		var email = new Email(command.Email);
		var phone = new Phone(command.NumberPhone);
		var cpf = new Cpf(command.CPF);
		var newSeller = new Seller(name, command.AddressFormat(), email, phone, cpf);

		//Salvar no banco
		_repository.Create(newSeller);

		//Retorna o resultado
		return new GenericCommandResult(true, "Seller criado com sucesso", newSeller);
	}

	public ICommandResult Handle(UpdateSellerCommand command)
	{
		// FFV
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "Parece que seu vendedor tem campos errados", command.Notifications);


		//Recuperar o Seller
		var seller = _repository.GetById(command.Id);

		//Salvar no banco
		_repository.Update(seller);

		//Retorna o resultado
		return new GenericCommandResult(true, "Vendedor atualizado com sucesso", seller);
	}
}