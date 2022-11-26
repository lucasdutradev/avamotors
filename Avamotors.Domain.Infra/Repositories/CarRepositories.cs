using Avamotors.Domain.Entities;
using Avamotors.Domain.Infra.Contexts;
using Avamotors.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Avamotors.Domain.Infra.Repositories;

public class CarRepositories : ICarRepositories
{
	private readonly DataContext _context;

	public CarRepositories(DataContext context)
	{
		_context = context;
	}

	public void Create(Car newCar, Seller seller)
	{
		_context.Car.Add(newCar);
		_context.SaveChanges();
	}

	public IEnumerable<Car> GetAll(Guid sellerId)
	{
		return _context.Car.AsNoTracking().Where(x => x.SellerId == sellerId).ToList();
	}

	public Car GetById(Guid carId, Guid sellerId)
	{
		return _context.Car.AsNoTracking().FirstOrDefault(x => x.Id == carId && x.SellerId == sellerId);
	}

	public void Update(Car newCar)
	{
		_context.Entry(newCar).State = EntityState.Modified;
		_context.SaveChanges();
	}
}