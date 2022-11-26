namespace Avamotors.Domain.Entities;

public class Availability : Entitie
{

	public Availability() { }
	public Availability(DateTime date, decimal priceInThisDay, Guid carId)
	{
		Date = date;
		PriceInThisDay = priceInThisDay;
		FilledDate = false;
		CarId = carId;
	}

	public DateTime Date { get; private set; }
	public decimal PriceInThisDay { get; private set; }
	public bool FilledDate { get; private set; }
	public Guid ClientId { get; private set; }
	public Client? Client { get; private set; }
	public Guid CarId { get; private set; }
	public Car? Car { get; private set; }

	public void AddClient(Client client)
	{
		FilledDate = true;
		Client = client;
	}
}