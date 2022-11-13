using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Phone : Notifiable<Notification>
{
	public Phone(string number)
	{
		Number = number;

		AddNotifications(new Contract<Phone>()
			.Requires()
			.AreEquals(number, 11, "Telefone", "deve conter o numero juntamente com o DDD ao todo 11 digitos.")
		);
	}
	public string Number { get; private set; }

}