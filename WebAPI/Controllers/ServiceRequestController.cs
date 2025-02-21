using Microsoft.AspNetCore.Mvc;

using ServiceCenter.Application.Interfaces;

using ServiceCenter.Domain.Entities;


namespace ServiceCenter.WebAPI.Controllers
{
    /// <summary>
    /// Service Request management controller.
    /// </summary>
    /// <remarks>
    /// Provides endpoints for retrieving, creating, updating, and deleting service requests.
    /// </remarks>
    /// <response code="200">Indicates a successful operation.</response>
    /// <response code="400">Indicates a bad request due to invalid input.</response>
    /// <response code="404">Indicates that the specified resource was not found.</response>
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        /// <summary>
        /// Retrieves all service request.
        /// </summary>
        /// <returns>A list of all service requests.</returns>
        /// <response code="200">The requests were successfully retrieved.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _serviceRequestService.GetAllAsync();
            return Ok(requests);
        }

        /// <summary>
        /// Retrieves a service request by ID.
        /// </summary>
        /// <param name="id">The ID of the service request to retrieve.</param>
        /// <returns>The service request if found; otherwise, a 404 response.</returns>
        /// <response code="200">The request was successfully retrieved.</response>
        /// <response code="404">No request was found with the specified ID.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = await _serviceRequestService.GetByIdAsync(id);
            if (request == null) return NotFound("Ticket not found");

            return Ok(request);
        }

        /// <summary>
        /// Creates a new service request.
        /// </summary>
        /// <param name="model">The service request model to create.</param>
        /// <returns>The created service request's details.</returns>
        /// <response code="200">The request was successfully created.</response>
        /// <response code="400">The provided model is invalid.</response>
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

        /// <summary>
        /// Updates an existing service request.
        /// </summary>
        /// <param name="id">The ID of the service request to update.</param>
        /// <param name="updateModel">The updated service request model.</param>
        /// <returns>A message indicating successful update.</returns>
        /// <response code="200">The service request was successfully updated.</response>
        /// <response code="400">The ID in the path does not match the ID in the model, or the provided data is invalid.</response>
        /// <response code="404">The specified service request was not found.</response>
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

        /// <summary>
        /// Deletes a service request by ID.
        /// </summary>
        /// <param name="id">The ID of the service request to delete.</param>
        /// <returns>A message indicating successful deletion.</returns>
        /// <response code="200">The service request was successfully deleted.</response>
        /// <response code="404">The specified service request was not found.</response>
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
