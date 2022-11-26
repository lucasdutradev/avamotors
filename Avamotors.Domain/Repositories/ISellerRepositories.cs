using Avamotors.Domain.Entities;

namespace Avamotors.Domain.Repositories;

public interface ISellerRepositories
{
	void Create(Seller newSeller);
	void Update(Seller newSeller);
	Seller GetById(Guid SellerId);
}