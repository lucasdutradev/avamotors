using Avamotors.Domain.Shared.Utils;
using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Cpf : Notifiable<Notification>
{
	public Cpf(string cpf)
	{
		CPF = cpf;
		AddNotifications(new Contract<Cpf>()
			.Requires()
			.AreEquals(CpfValidate.IsCpf(cpf), true, "cpf", "CPF Invalido")
		);
	}

	public string CPF { get; private set; }
}