using System.Linq.Expressions;

namespace ServiceCenter.Application.Interfaces
{
    /// <summary>
    /// A generic repository interface for CRUD operations on entities.
    /// </summary>
    /// <typeparam name="T">The type of entity the repository will handle.</typeparam>
    /// <remarks>
    /// Provides methods for retrieving entities by ID, fetching all entities, querying by conditions, 
    /// as well as adding, updating, and deleting entities.
    /// </remarks>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity if found, otherwise null.</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all entities from the repository.
        /// </summary>
        /// <returns>A read-only list of all entities.</returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Retrieves entities matching the specified condition.
        /// </summary>
        /// <param name="predicate">The condition to filter the entities.</param>
        /// <returns>A read-only list of entities that match the condition.</returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        Task DeleteAsync(T entity);
    }
}
