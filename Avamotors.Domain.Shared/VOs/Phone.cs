using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Phone : BaseVo
{
	public Phone() { }
	public Phone(string number)
	{
		Number = number;
	}
	public string Number { get; private set; }

}