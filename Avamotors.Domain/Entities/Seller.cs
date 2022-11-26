using Avamotors.Domain.Shared.VOs;

namespace Avamotors.Domain.Entities;

public class Seller : Entitie
{
	private readonly IList<Car> _cars;

	public Seller() { }
	public Seller(Name name, string address, Email email, Phone phone, Cpf cpf)
	{
		Name = name;
		Email = email;
		Phone = phone;
		Cpf = cpf;
		_cars = new List<Car>();
	}

	public Name Name { get; private set; }
	public string Address { get; private set; }
	// public string FullAddress { get; private set; }
	public Email Email { get; private set; }
	public Phone Phone { get; private set; }
	public Cpf Cpf { get; private set; }
	public IEnumerable<Car> Cars => _cars.ToArray();
}