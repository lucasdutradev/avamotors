using Avamotors.Domain.Entities;

namespace Avamotors.Domain.Repositories;

public interface ICarRepositories
{
	void Create(Car newCar);
	void Update(Car newCar);
	Car GetById(Guid carId, Guid sellerId);
	IEnumerable<Car> GetAll(Guid sellerId);
}