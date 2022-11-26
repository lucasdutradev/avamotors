using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Address : BaseVo
{

	public Address() { }
	public Address(string cep, string street, string neighborhood, string city, string number, string? complement)
	{
		Cep = cep;
		Street = street;
		Neighborhood = neighborhood;
		City = city;
		Number = number;
		Complement = complement;
	}

	public string Cep { get; private set; }
	public string Street { get; private set; }
	public string Neighborhood { get; private set; }
	public string City { get; private set; }
	public string Number { get; private set; }
	public string? Complement { get; private set; }
}