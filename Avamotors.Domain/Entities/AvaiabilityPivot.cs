namespace Avamotors.Domain.Entities;

public class AvailabilityPivot : Entitie
{
	public AvailabilityPivot(Car car, Availability availability, double priceInThisDay, bool filledDate)
	{
		Car = car;
		Availability = availability;
		PriceInThisDay = priceInThisDay;
		FilledDate = filledDate;
	}

	public Car Car { get; private set; }
	public Availability Availability { get; private set; }
	public double PriceInThisDay { get; private set; }
	public bool FilledDate { get; private set; }
}