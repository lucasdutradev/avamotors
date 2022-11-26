using Avamotors.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Avamotors.Domain.Commands;

public class CreateCarSellerCommand : Notifiable<Notification>, ICommand
{
	public CreateCarSellerCommand(Guid sellerId, double priceDay, string name, double km, string year, string model, string description, string image)
	{
		SellerId = sellerId;
		PriceDay = priceDay;
		Km = km;
		Name = name;
		Year = year;
		Model = model;
		Description = description;
		Image = image;
	}

	public Guid SellerId { get; set; }
	public double PriceDay { get; set; }
	public string Name { get; private set; }
	public double Km { get; set; }
	public string Year { get; set; }
	public string Model { get; set; }
	public string Description { get; set; }
	public string Image { get; set; }

	public bool Validate()
	{
		return IsValid;
	}
}
