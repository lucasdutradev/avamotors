using Avamotors.Domain.Shared.Utils;
using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Cpf : BaseVo
{

	public Cpf() { }
	public Cpf(string cpf)
	{
		CPF = cpf;
	}

	public string CPF { get; private set; }
}