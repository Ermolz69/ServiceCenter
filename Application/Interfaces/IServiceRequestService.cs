using ServiceCenter.Domain.Entities;

namespace ServiceCenter.Application.Interfaces
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();

        Task<ServiceRequest> CreateAsync(ServiceRequest request);

        Task<ServiceRequest?> GetByIdAsync(int id);

        Task UpdateAsync(ServiceRequest request);

        Task DeleteAsync(int id);
    }
}
