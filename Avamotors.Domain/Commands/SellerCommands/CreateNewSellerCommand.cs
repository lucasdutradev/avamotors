using Avamotors.Domain.Commands.Contracts;
using Avamotors.Domain.Shared.Utils;
using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Commands;

public class CreateNewSellerCommand : Notifiable<Notification>, ICommand
{
	public CreateNewSellerCommand(string firstName, string lastName, string cep, string street, string neighborhood, string city, string number, string? complement, string email, string numberPhone, string cPF)
	{
		FirstName = firstName;
		LastName = lastName;
		Cep = cep;
		Street = street;
		Neighborhood = neighborhood;
		City = city;
		Number = number;
		Complement = complement;
		Email = email;
		NumberPhone = numberPhone;
		CPF = cPF;
	}

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Cep { get; set; }
	public string Street { get; set; }
	public string Neighborhood { get; set; }
	public string City { get; set; }
	public string Number { get; set; }
	public string? Complement { get; set; }
	public string Email { get; set; }
	public string NumberPhone { get; set; }
	public string CPF { get; set; }

	public bool Validate()
	{
		AddNotifications(new Contract<CreateNewSellerCommand>()
			.Requires()
			.IsGreaterThan(FirstName, 2, "firstName", "Nome precisa ser maior que 2 caracteres")
			.IsGreaterThan(LastName, 2, "lastName", "Sobrenome precisa ser maior que 2 caracteres")
			.AreEquals(Cep, 8, "Cep", "CEP invalido")
			.IsNotNullOrEmpty(Street, "Rua", "Rua não pode estar vazia")
			.IsNotNullOrEmpty(Neighborhood, "Bairro", "Bairro não pode estar vazio")
			.IsNotNullOrEmpty(City, "Cidade", "Cidade não pode estar vazia")
			.IsNotNullOrEmpty(Number, "Numero", "Numero não pode estar vazio")
			.IsEmail(Email, "E-mail", "Endereço de e-mail invalido.")
			.AreEquals(NumberPhone, 11, "Telefone", "deve conter o numero juntamente com o DDD ao todo 11 digitos.")
			.AreEquals(CpfValidate.IsCpf(CPF), true, "cpf", "CPF Invalido")
		);
		return IsValid;
	}

	public string AddressFormat()
	{
		return $"{Street}, {Number}, {Neighborhood} - {City}, {Complement ?? "Sem Complemento"}";
	}
}
