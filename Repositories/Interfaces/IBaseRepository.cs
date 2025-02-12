using FenecApi.Models;

namespace FenecApi.Repositories.Interfaces;
/// <summary>
/// Generic repository interface that provides basic CRUD operations.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public interface IBaseRepository<T> where T : class
{
	/// <summary>
	/// Retrieves all entities of type <typeparamref name="T"/> from the database.
	/// </summary>
	/// <returns>A list of all entities.</returns>
	Task<List<T>> GetAllAsync();

	/// <summary>
	/// Retrieves an entity by its unique identifier.
	/// </summary>
	/// <param name="id">The unique identifier of the entity.</param>
	/// <returns>The entity if found; otherwise, null.</returns>
	Task<T?> GetByIdAsync(int id);

	/// <summary>
	/// Adds a new entity to the database.
	/// </summary>
	/// <param name="entity">The entity to add.</param>
	Task AddAsync(T entity);

	/// <summary>
	/// Updates an existing entity in the database.
	/// </summary>
	/// <param name="entity">The entity with updated values.</param>
	Task UpdateAsync(T entity);

	/// <summary>
	/// Deletes an entity from the database by its unique identifier.
	/// </summary>
	/// <param name="id">The unique identifier of the entity to delete.</param>
	Task DeleteAsync(int id);
}

/// <summary>
/// Repository interface for managing Category data operations.
/// </summary>
public interface ICategoryRepository : IBaseRepository<Category> { }

/// <summary>
/// Repository interface for managing Product data operations.
/// </summary>
public interface IProductRepository : IBaseRepository<Product> { }

/// <summary>
/// Repository interface for managing Order data operations.
/// </summary>
public interface IOrderRepository : IBaseRepository<Order> { }

/// <summary>
/// Repository interface for managing OrderItem data operations.
/// </summary>
public interface IOrderItemRepository : IBaseRepository<OrderItem> { }
