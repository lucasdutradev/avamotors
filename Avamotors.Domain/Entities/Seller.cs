using Avamotors.Domain.Shared.VOs;

namespace Avamotors.Domain.Entities;

public class Seller : Entitie
{
	public Seller(Name name, Address address, Email email, Phone phone, Cpf cpf)
	{
		Name = name;
		Address = address;
		Email = email;
		Phone = phone;
		Cpf = cpf;
	}

	public Name Name { get; private set; }
	public Address Address { get; private set; }
	public Email Email { get; private set; }
	public Phone Phone { get; private set; }
	public Cpf Cpf { get; private set; }
}