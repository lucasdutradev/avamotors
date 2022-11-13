using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Name : Notifiable<Notification>
{
	public Name(string firstName, string lastName)
	{
		FirstName = firstName;
		LastName = lastName;

		AddNotifications(new Contract<Name>()
			.Requires()
			.IsGreaterThan(firstName, 2, "firstName", "Nome precisa ser maior que 2 caracteres")
			.IsGreaterThan(lastName, 2, "lastName", "Sobrenome precisa ser maior que 2 caracteres")
		);
	}

	public string FirstName { get; private set; }
	public string LastName { get; private set; }
}