using Avamotors.Domain.Entities;
using Avamotors.Domain.Infra.Contexts;
using Avamotors.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Avamotors.Domain.Infra.Repositories;

public class AvailabilityRepositories : IAvailabilityRepositories
{
	private readonly DataContext _context;

	public AvailabilityRepositories(DataContext context)
	{
		_context = context;
	}

	public void Create(Availability newAvailability)
	{
		_context.Availability.Add(newAvailability);
		_context.SaveChanges();
	}

	public void Update(Availability newAvailability)
	{
		_context.Entry(newAvailability).State = EntityState.Modified;
		_context.SaveChanges();
	}
}