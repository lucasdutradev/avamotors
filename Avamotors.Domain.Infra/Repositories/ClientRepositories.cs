using Avamotors.Domain.Entities;
using Avamotors.Domain.Infra.Contexts;
using Avamotors.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Avamotors.Domain.Infra.Repositories;

public class ClientRepositories : IClientRepositories
{

	private readonly DataContext _context;

	public ClientRepositories(DataContext context)
	{
		_context = context;
	}

	public void Create(Client newClient)
	{
		_context.Client.Add(newClient);
		_context.SaveChanges();
	}

	public void Update(Client newClient)
	{
		_context.Entry(newClient).State = EntityState.Modified;
		_context.SaveChanges();
	}
}