using ServiceCenter.Domain.Entities;

namespace ServiceCenter.Application.Interfaces
{
    /// <summary>
    /// Interface for managing service requests.
    /// </summary>
    /// <remarks>
    /// Defines methods for retrieving, creating, updating, and deleting service requests.
    /// </remarks>
    public interface IServiceRequestService
    {
        /// <summary>
        /// Retrieves all service requests.
        /// </summary>
        /// <returns>A collection of all service requests.</returns>
        Task<IEnumerable<ServiceRequest>> GetAllAsync();

        /// <summary>
        /// Creates a new service request.
        /// </summary>
        /// <param name="request">The service request to create.</param>
        /// <returns>The newly created service request.</returns>
        Task<ServiceRequest> CreateAsync(ServiceRequest request);

        /// <summary>
        /// Retrieves a service request by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service request.</param>
        /// <returns>The service request if found, otherwise null.</returns>
        Task<ServiceRequest?> GetByIdAsync(int id);

        /// <summary>
        /// Updates an existing service request.
        /// </summary>
        /// <param name="request">The service request to update.</param>
        Task UpdateAsync(ServiceRequest request);

        /// <summary>
        /// Deletes a service request by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service request to delete.</param>
        Task DeleteAsync(int id);
    }
}
