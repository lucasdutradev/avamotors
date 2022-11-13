using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Email : Notifiable<Notification>
{
	public Email(string address)
	{
		Address = address;

		AddNotifications(new Contract<Email>()
			.Requires()
			.IsEmail(address, "E-mail", "Endereço de e-mail invalido.")
		);
	}

	public string Address { get; private set; }
}