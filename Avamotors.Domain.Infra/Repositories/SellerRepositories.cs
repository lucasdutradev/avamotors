using Avamotors.Domain.Entities;
using Avamotors.Domain.Infra.Contexts;
using Avamotors.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Avamotors.Domain.Infra.Repositories;

public class SellerRepositories : ISellerRepositories
{

	private readonly DataContext _context;

	public SellerRepositories(DataContext context)
	{
		_context = context;
	}

	public void Create(Seller newSeller)
	{
		_context.Seller.Add(newSeller);
		_context.SaveChanges();
	}

	public Seller GetById(Guid SellerId)
	{
		return _context.Seller.FirstOrDefault(x => x.Id == SellerId);
	}

	public void Update(Seller newSeller)
	{
		_context.Entry(newSeller).State = EntityState.Modified;
		_context.SaveChanges();
	}
}