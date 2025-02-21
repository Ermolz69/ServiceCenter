using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Application.Interfaces;
using ServiceCenter.Domain.Entities;


namespace ServiceCenter.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _serviceRequestService.GetAllAsync();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = await _serviceRequestService.GetByIdAsync(id);
            if (request == null) return NotFound("Ticket not found");

            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _serviceRequestService.CreateAsync(model);

            return Ok(new
            {
                Message = "Ticket successfully sended",
                Data = created
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceRequest updateModel)
        {
            if (id != updateModel.Id)
                return BadRequest("ID in the path and in the model do not match.");

            var existing = await _serviceRequestService.GetByIdAsync(id);
            if (existing == null)
                return NotFound("Ticket not found.");

            existing.Name = updateModel.Name;
            existing.Phone = updateModel.Phone;
            existing.Email = updateModel.Email;
            existing.DeviceType = updateModel.DeviceType;
            existing.ProblemDescription = updateModel.ProblemDescription;
            existing.Status = updateModel.Status;

            await _serviceRequestService.UpdateAsync(existing);

            return Ok(new { Message = "Ticket successfully updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _serviceRequestService.GetByIdAsync(id);
            if (existing == null)
                return NotFound("Ticket not found.");

            await _serviceRequestService.DeleteAsync(id);
            return Ok(new { Message = "Ticket successfully deleted" });
        }
    }
}
