using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Shared.VOs;

public class Address : Notifiable<Notification>
{
	public Address(string cep, string street, string neighborhood, string city, string number, string complement)
	{
		Cep = cep;
		Street = street;
		Neighborhood = neighborhood;
		City = city;
		Number = number;
		Complement = complement;

		AddNotifications(new Contract<Address>()
			.Requires()
			.AreEquals(cep, 8, "Cep", "CEP invalido")
			.IsNotNullOrEmpty(street, "Rua", "Rua não pode estar vazia")
			.IsNotNullOrEmpty(neighborhood, "Bairro", "Bairro não pode estar vazio")
			.IsNotNullOrEmpty(city, "Cidade", "Cidade não pode estar vazia")
			.IsNotNullOrEmpty(number, "Numero", "Numero não pode estar vazio")
		);
	}

	public string Cep { get; private set; }
	public string Street { get; private set; }
	public string Neighborhood { get; private set; }
	public string City { get; private set; }
	public string Number { get; private set; }
	public string? Complement { get; private set; }
}