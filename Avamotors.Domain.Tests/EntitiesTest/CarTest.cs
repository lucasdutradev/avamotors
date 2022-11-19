using Avamotors.Domain.Entities;
using Avamotors.Domain.Shared.VOs;

namespace Avamotors.Domain.Tests.EntitiesTest;

[TestClass]
public class CarTest
{
	private readonly Seller _owner;

	public CarTest()
	{
		var name = new Name("Lucas", "Dutra");
		var address = new Address("15075270", "Rua Reinaldo Volpe", "CAIC, Conjunto habitacional", "São jose do Rio Preto", "150", "APTO 48");
		var email = new Email("lucasbryan0217@gmail.com");
		var phone = new Phone("17991846526");
		var cpf = new Cpf("10695196693");
		_owner = new Seller(name, address, email, phone, cpf);
	}

	[TestMethod]
	public void Deve_Cadastrar_Um_Novo_Carro_E_Adicionar_Um_Dono()
	{
		var newCar = new Car("Fiat Mobi", 1200.50, "2009", "XN9", "Fiat mobi totalmente conservado", "https://image.jpg", null);
		var result = newCar.AddCarASeller(_owner);
		Assert.AreEqual(true, result);
	}

	[TestMethod]
	public void Deve_Cadastrar_Uma_Data_Para_O_Carro()
	{
		var newCar = new Car("Fiat Mobi", 1200.50, "2009", "XN9", "Fiat mobi totalmente conservado", "https://image.jpg", null);
		newCar.AddCarASeller(_owner);
		newCar.AddAvailability(DateTime.Now, 120.0M);
		var result = newCar.AddAvailability(DateTime.Now.AddDays(1), 120.0M);
		Assert.AreEqual(true, result);
	}

	[TestMethod]
	public void Nao_Deve_Cadastrar_Uma_Data_Para_O_Carro_Caso_Ja_Tenha_Nesse_Dia()
	{
		var newCar = new Car("Fiat Mobi", 1200.50, "2009", "XN9", "Fiat mobi totalmente conservado", "https://image.jpg", null);
		newCar.AddCarASeller(_owner);
		newCar.AddAvailability(DateTime.Now, 120.0M);
		var result = newCar.AddAvailability(DateTime.Now, 120.0M);
		Assert.AreEqual(false, result);
	}
}