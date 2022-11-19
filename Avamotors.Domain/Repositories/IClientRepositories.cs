using Avamotors.Domain.Entities;

namespace Avamotors.Domain.Repositories;

public interface IClientRepositories
{
	void Create(Client newClient);
	void Update(Client newClient);
}