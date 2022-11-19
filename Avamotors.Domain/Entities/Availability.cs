namespace Avamotors.Domain.Entities;

public class Availability : Entitie
{
	public Availability(DateTime date, decimal priceInThisDay)
	{
		Date = date;
		PriceInThisDay = priceInThisDay;
		FilledDate = false;
	}

	public DateTime Date { get; private set; }
	public decimal PriceInThisDay { get; private set; }
	public bool FilledDate { get; private set; }
	public Client? Client { get; private set; }

	public void AddClient(Client client)
	{
		FilledDate = true;
		Client = client;
	}
}