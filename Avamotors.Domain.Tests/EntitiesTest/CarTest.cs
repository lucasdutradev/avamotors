using Avamotors.Domain.Entities;
using Avamotors.Domain.Shared.VOs;

namespace Avamotors.Domain.Tests.EntitiesTest;

[TestClass]
public class CarTest
{
	private readonly Seller _owner;
	private readonly Client _client;

	public CarTest()
	{
		var name = new Name("Lucas", "Dutra");
		var address = new Address("15075270", "Rua Reinaldo Volpe", "CAIC, Conjunto habitacional", "São jose do Rio Preto", "150", "APTO 48");
		var email = new Email("lucasbryan0217@gmail.com");
		var phone = new Phone("17991846526");
		var cpf = new Cpf("10695196693");
		_owner = new Seller(name, address, email, phone, cpf);
		_client = new Client(name, cpf, address, phone, "M");
	}

	[TestMethod]
	public void Deve_Cadastrar_Um_Novo_Carro_E_Adicionar_Um_Dono()
	{
		var newCar = new Car("Fiat Mobi", 1200.50, "2009", "XN9", "Fiat mobi totalmente conservado", "https://image.jpg");
		newCar.AddCarASeller(_owner);
		Assert.AreNotEqual(null, newCar.Owner);
	}

	[TestMethod]
	public void Deve_Cadastrar_Uma_Data_Para_O_Carro()
	{
		var newCar = new Car("Fiat Mobi", 1200.50, "2009", "XN9", "Fiat mobi totalmente conservado", "https://image.jpg");
		newCar.AddCarASeller(_owner);
		newCar.AddAvailability(DateTime.Now, 120.0M);
		newCar.AddAvailability(DateTime.Now.AddDays(1), 120.0M);
		Assert.AreEqual(2, newCar.Availabilitys.Count());
	}

	[TestMethod]
	public void Nao_Deve_Cadastrar_Uma_Data_Para_O_Carro_Caso_Ja_Tenha_Nesse_Dia()
	{
		var newCar = new Car("Fiat Mobi", 1200.50, "2009", "XN9", "Fiat mobi totalmente conservado", "https://image.jpg");
		newCar.AddCarASeller(_owner);
		newCar.AddAvailability(DateTime.Now, 120.0M);
		newCar.AddAvailability(DateTime.Now, 120.0M);
		newCar.AddAvailability(DateTime.Now.AddDays(1), 120.0M);
		Assert.AreEqual(2, newCar.Availabilitys.Count());
	}

	[TestMethod]
	public void Deve_Cadastrar_Um_Cliente_A_Um_Carro_Em_Uma_Determinada_Data()
	{
		var newCar = new Car("Fiat Mobi", 1200.50, "2009", "XN9", "Fiat mobi totalmente conservado", "https://image.jpg");
		newCar.AddCarASeller(_owner);
		newCar.AddAvailability(DateTime.Now, 100.0M);
		newCar.AddAvailability(DateTime.Now, 120.0M);
		newCar.AddAvailability(DateTime.Now.AddDays(1), 120.0M);
		var availability = newCar.Availabilitys.First();
		newCar.AddCarAClient(_client, availability.Id);
		Assert.AreNotEqual(null, availability.Client);
	}
}