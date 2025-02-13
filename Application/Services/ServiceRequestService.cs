using ServiceCenter.Application.Interfaces;
using ServiceCenter.Domain.Entities;


namespace YourSolution.Application.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IGenericRepository<ServiceRequest> _repository;

        public ServiceRequestService(IGenericRepository<ServiceRequest> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ServiceRequest> CreateAsync(ServiceRequest request)
        {
            return await _repository.AddAsync(request);
        }

        public async Task<ServiceRequest?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ServiceRequest request)
        {
            await _repository.UpdateAsync(request);
        }

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
