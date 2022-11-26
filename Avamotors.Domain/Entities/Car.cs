namespace Avamotors.Domain.Entities;

public class Car : Entitie
{
	private readonly IList<Availability> _availabilitys;

	public Car() { }
	public Car(string name, double km, string year, string model, string description, string image)
	{
		Name = name;
		Km = km;
		Year = year;
		Model = model;
		Description = description;
		Image = image;
		_availabilitys = new List<Availability>();
	}

	public string Name { get; private set; }
	public double Km { get; private set; }
	public string Year { get; private set; }
	public string Model { get; private set; }
	public string Description { get; private set; }
	public string Image { get; private set; }
	public Guid SellerId { get; private set; }
	public Seller Owner { get; private set; }
	public IEnumerable<Availability> Availabilitys => _availabilitys.ToArray();

	public void AddCarASeller(Seller owner)
	{
		Owner = owner;

	}
	public void AddAvailability(DateTime date, decimal priceInThisDay)
	{
		var existThisAvailability = Availabilitys.FirstOrDefault(x => x.Date.Date == date.Date);

		if (existThisAvailability == null)
		{
			var newAvailability = new Availability(date, priceInThisDay);
			_availabilitys.Add(newAvailability);
		}
	}


	public void AddCarAClient(Client client, Guid availability_id)
	{
		var availability = Availabilitys.FirstOrDefault(x => x.Id == availability_id);
		if (availability != null && !availability.FilledDate)
		{
			availability.AddClient(client);
		}
	}
}