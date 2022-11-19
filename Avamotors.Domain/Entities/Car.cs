namespace Avamotors.Domain.Entities;

public class Car : Entitie
{
	private readonly IList<Availability> _availabilitys;
	public Car(string name, double km, string year, string model, string description, string image, Client? client)
	{
		Name = name;
		Km = km;
		Year = year;
		Model = model;
		Description = description;
		Image = image;
		Client = client;
		_availabilitys = new List<Availability>();
	}

	public Seller Owner { get; private set; }
	public string Name { get; private set; }
	public double Km { get; private set; }
	public string Year { get; private set; }
	public string Model { get; private set; }
	public string Description { get; private set; }
	public string Image { get; private set; }
	public Client? Client { get; private set; }
	public IEnumerable<Availability> Availabilitys => _availabilitys.ToArray();

	public bool AddCarASeller(Seller owner)
	{
		if (owner.IsValid)
		{
			Owner = owner;
			return true;
		}
		return false;

	}
	public bool AddAvailability(DateTime date, decimal priceInThisDay)
	{
		var existThisAvailability = Availabilitys.FirstOrDefault(x => x.Date.Date == date.Date);

		if (existThisAvailability == null)
		{
			var newAvailability = new Availability(date, priceInThisDay);
			_availabilitys.Add(newAvailability);
			return true;
		}
		return false;
	}


	public bool AddCarAClient(Client client, Guid availability_id)
	{
		var availability = Availabilitys.FirstOrDefault(x => x.Id == availability_id);
		if (client.IsValid && !availability.FilledDate)
		{
			availability.checkData();
			Client = client;
			return true;
		}
		return false;
	}
}