using Avamotors.Domain.Entities;

namespace Avamotors.Domain.Repositories;
public interface IAvailabilityRepositories
{
	void Create(Availability newAvailability);
	void Update(Availability newAvailability);
}