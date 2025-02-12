using FenecApi.Data;
using FenecApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FenecApi.Repositories;

/// <summary>
/// Generic repository for basic CRUD operations.
/// </summary>
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
	protected readonly FenecDbContext _context;
	protected readonly DbSet<T> _dbSet;

	public BaseRepository(FenecDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}

	public async Task<List<T>> GetAllAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<T?> GetByIdAsync(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public async Task AddAsync(T entity)
	{
		await _dbSet.AddAsync(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(T entity)
	{
		_dbSet.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var entity = await _dbSet.FindAsync(id);
		if (entity != null)
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}