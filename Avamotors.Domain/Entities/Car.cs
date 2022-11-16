using Avamotors.Domain.Shared.VOs;

namespace Avamotors.Domain.Entities;

public class Car : Entitie
{
	public Car(Seller owner, double priceDay, Name name, double km, string year, string model, string description, string image, Client client)
	{
		Owner = owner;
		PriceDay = priceDay;
		Name = name;
		Km = km;
		Year = year;
		Model = model;
		Description = description;
		Image = image;
		Client = client;
	}

	public Seller Owner { get; private set; }
	public double PriceDay { get; private set; }
	public Name Name { get; private set; }
	public double Km { get; private set; }
	public string Year { get; private set; }
	public string Model { get; private set; }
	public string Description { get; private set; }
	public string Image { get; private set; }
	public Client Client { get; private set; }
}