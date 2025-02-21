using ServiceCenter.Application.Interfaces;
using ServiceCenter.Domain.Entities;


namespace ServiceCenter.Application.Services
{
    /// <summary>
    /// Service class for managing service requests.
    /// </summary>
    /// <remarks>
    /// Implements methods for retrieving, creating, updating, and deleting service requests.
    /// </remarks>
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IGenericRepository<ServiceRequest> _repository;

        public ServiceRequestService(IGenericRepository<ServiceRequest> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all service requests.
        /// </summary>
        /// <returns>A collection of all service requests.</returns>
        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>
        /// Creates a new service request.
        /// </summary>
        /// <param name="request">The service request to create.</param>
        /// <returns>The newly created service request.</returns>
        public async Task<ServiceRequest> CreateAsync(ServiceRequest request)
        {
            return await _repository.AddAsync(request);
        }

        /// <summary>
        /// Retrieves a service request by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service request.</param>
        /// <returns>The service request if found, otherwise null.</returns>
        public async Task<ServiceRequest?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <summary>
        /// Updates an existing service request.
        /// </summary>
        /// <param name="request">The service request to update.</param>
        public async Task UpdateAsync(ServiceRequest request)
        {
            await _repository.UpdateAsync(request);
        }

        /// <summary>
        /// Deletes a service request by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service request to delete.</param>
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}
