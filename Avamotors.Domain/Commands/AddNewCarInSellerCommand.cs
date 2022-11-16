using Avamotors.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Commands;

public class AddNewCarInSellerCommand : Notifiable<Notification>, ICommand
{
	public AddNewCarInSellerCommand(Guid sellerId, double priceDay, string firstName, string lastName, double km, string year, string model, string description, string image, Guid? clientId)
	{
		SellerId = sellerId;
		PriceDay = priceDay;
		FirstName = firstName;
		LastName = lastName;
		Km = km;
		Year = year;
		Model = model;
		Description = description;
		Image = image;
		ClientId = clientId;
	}

	public Guid SellerId { get; set; }
	public double PriceDay { get; set; }
	public string FirstName { get; private set; }
	public string LastName { get; private set; }
	public double Km { get; set; }
	public string Year { get; set; }
	public string Model { get; set; }
	public string Description { get; set; }
	public string Image { get; set; }
	public Guid? ClientId { get; set; }

	public bool Validate()
	{
		AddNotifications(new Contract<AddNewCarInSellerCommand>()
			.Requires()
			.IsGreaterThan(FirstName, 2, "firstName", "Nome precisa ser maior que 2 caracteres")
			.IsGreaterThan(LastName, 2, "lastName", "Sobrenome precisa ser maior que 2 caracteres")
		);
		return IsValid;
	}
}
