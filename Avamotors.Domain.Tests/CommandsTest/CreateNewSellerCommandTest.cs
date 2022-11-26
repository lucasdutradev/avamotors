using Avamotors.Domain.Commands;
using Avamotors.Domain.Entities;
using Avamotors.Domain.Shared.VOs;

namespace Avamotors.Domain.Tests.CommandsTest;

[TestClass]
public class CreateNewSellerCommandTest
{
	private readonly CreateNewSellerCommand _commandValid = new CreateNewSellerCommand(
		"Lucas",
		"Dutra",
		"15075270",
		"Rua Reinaldo Volpe",
		"CAIC, Conjunto habitacional",
		"São jose do Rio Preto",
		"150",
		"APTO 48",
		"lucasbryan0217@gmail.com",
		"17991846526",
		"10695196693"
	);
	private readonly CreateNewSellerCommand _commandNotValid = new CreateNewSellerCommand(
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		""
	);
	[TestMethod]
	public void Deve_Criar_Um_Comando_Valido()
	{
		Assert.AreEqual(true, _commandValid.Validate());

	}
	[TestMethod]
	public void Deve_Criar_Um_Comando_InValido()
	{
		Assert.AreEqual(false, _commandNotValid.Validate());
	}

	// [TestMethod]
	// public void Deve_Criar_Um_Vendedor_Com_Comando_Valido()
	// {
	// 	var name = new Name(_commandValid.FirstName, _commandValid.LastName);
	// 	var address = new Address(_commandValid.Cep, _commandValid.Street, _commandValid.Neighborhood, _commandValid.City, _commandValid.Number, _commandValid.Complement);
	// 	var email = new Email(_commandValid.Email);
	// 	var phone = new Phone(_commandValid.NumberPhone);
	// 	var cpf = new Cpf(_commandValid.CPF);
	// 	var seller = new Seller(name, "aaa", email, phone, cpf);
	// 	Assert.AreEqual(true, seller.IsValid);
	// }

	// [TestMethod]
	// public void Deve_Criar_Um_Vendedor_Com_Comando_InValido()
	// {
	// 	var name = new Name(_commandNotValid.FirstName, _commandNotValid.LastName);
	// 	var address = new Address(_commandNotValid.Cep, _commandNotValid.Street, _commandNotValid.Neighborhood, _commandNotValid.City, _commandNotValid.Number, _commandNotValid.Complement);
	// 	var email = new Email(_commandNotValid.Email);
	// 	var phone = new Phone(_commandNotValid.NumberPhone);
	// 	var cpf = new Cpf(_commandNotValid.CPF);
	// 	var seller = new Seller(name, "aaa", email, phone, cpf);
	// 	Assert.AreEqual(false, seller.IsValid);
	// }
}