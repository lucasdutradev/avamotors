using Avamotors.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Commands;

public class AddNewAvaiabilityInCarCommand : Notifiable<Notification>, ICommand
{
	public AddNewAvaiabilityInCarCommand(DateTime date, Guid carId, double priceInThisDay, bool filledDate)
	{
		Date = date;
		CarId = carId;
		PriceInThisDay = priceInThisDay;
		FilledDate = false;
	}

	public DateTime Date { get; set; }
	public Guid CarId { get; private set; }
	public double PriceInThisDay { get; private set; }
	public bool FilledDate { get; private set; }

	public bool Validate()
	{
		AddNotifications(new Contract<AddNewAvaiabilityInCarCommand>().Requires());
		return IsValid;
	}
}