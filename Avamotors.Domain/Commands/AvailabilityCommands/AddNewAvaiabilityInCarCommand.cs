using Avamotors.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Commands;

public class AddNewAvailabilityInCarCommand : Notifiable<Notification>, ICommand
{
	public AddNewAvailabilityInCarCommand(DateTime date, Guid carId, decimal priceInThisDay, bool filledDate)
	{
		Date = date;
		CarId = carId;
		PriceInThisDay = priceInThisDay;
		FilledDate = false;
	}

	public DateTime Date { get; set; }
	public Guid CarId { get; private set; }
	public decimal PriceInThisDay { get; private set; }
	public bool FilledDate { get; private set; }

	public bool Validate()
	{
		return IsValid;
	}
}