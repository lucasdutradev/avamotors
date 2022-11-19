using Avamotors.Domain.Shared.VOs;

namespace Avamotors.Domain.Entities;

public class Client : Entitie
{
	public Client(Name name, Cpf cpf, Address address, Phone phone, string sex)
	{
		Name = name;
		Cpf = cpf;
		Address = address;
		Phone = phone;
		Sex = sex;
	}

	public Name Name { get; private set; }
	public Cpf Cpf { get; private set; }
	public Address Address { get; private set; }
	public Phone Phone { get; private set; }
	public string Sex { get; private set; }
}