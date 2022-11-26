using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Email : BaseVo
{
	public Email() { }
	public Email(string address)
	{
		Address = address;
	}

	public string Address { get; private set; }
}