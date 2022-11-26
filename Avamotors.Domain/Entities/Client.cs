using Avamotors.Domain.Shared.VOs;

namespace Avamotors.Domain.Entities;

public class Client : Entitie
{
	public Client() { }
	public Client(Name name, Cpf cpf, string address, Email email, Phone phone, string sex)
	{
		Name = name;
		Cpf = cpf;
		Email = email;
		Phone = phone;
		Sex = sex;
	}

	public Name Name { get; private set; }
	public Cpf Cpf { get; private set; }
	public string Address { get; private set; }
	public Phone Phone { get; private set; }
	public Email Email { get; private set; }
	public string Sex { get; private set; }
	public Availability? Availability { get; private set; }
}