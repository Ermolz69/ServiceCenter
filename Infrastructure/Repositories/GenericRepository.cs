using Microsoft.EntityFrameworkCore;
using ServiceCenter.Infrastructure.Data;
using System.Linq.Expressions;
using ServiceCenter.Application.Interfaces;

namespace ServiceCenter.Infrastructure.Repositories
{
    /// <summary>
    /// A generic repository implementation for handling CRUD operations.
    /// </summary>
    /// <remarks>
    /// This repository provides methods to get entities by ID, fetch all entities, query by condition, add new entities, update existing ones, and delete entities.
    /// </remarks>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity if found, otherwise null.</returns>
        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        /// <summary>
        /// Retrieves all entities from the repository.
        /// </summary>
        /// <returns>A read-only list of all entities.</returns>
        public async Task<IReadOnlyList<T>> GetAllAsync() =>
            await _context.Set<T>().ToListAsync();

        /// <summary>
        /// Retrieves entities matching the specified condition.
        /// </summary>
        /// <param name="predicate">The condition to filter the entities.</param>
        /// <returns>A read-only list of entities that match the condition.</returns>
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) =>
            await _context.Set<T>().Where(predicate).ToListAsync();

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}