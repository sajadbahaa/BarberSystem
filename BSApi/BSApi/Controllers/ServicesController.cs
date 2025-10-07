using BussinesLayer;
using Dtos.PeopleDtos;
using Dtos.Services;
using Dtos.SpeclisysDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServicesDetilasService _service;

        public ServicesController(ServicesDetilasService service)
        {
            _service = service;
        }

        // =================== FIND ===================

        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> FindByIDAsync(short id)
        {
            var entity = await _service.FindByIDAsync(id);
            if (entity == null)
                return NotFound($"service with ID {id} not found.");

            return Ok(entity);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllServicesAsync()
        {
            var entitys = await _service.FindAllServicesAsync();
            return Ok(entitys);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllServicesDetialsAsync()
        {
            var entitys = await _service.FindAllServicesDetilasAsync();
            return Ok(entitys);
        }

        // =================== ADD ===================



        // =================== UPDATE ===================

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] updateServiceDtos dto)
        {
       
            var success = await _service.UpdateAsync(dto);
            if (!success)
                return BadRequest("Failed to update service.");

            return Ok("UpdateSuccess");
        }

        // =================== ACTIVATE ===================

        [HttpPut("[action]/{id:int}")]
        public async Task<IActionResult> ActivateeAsync(short id)
        {
            var success = await _service.ActivateeAsync(id);
            if (!success)
                return NotFound($"Error");

            return Ok("ActivatedSuccess");
        }

        // =================== DELETE ===================

        [HttpDelete("[action]/{id:int}")]
        public async Task<IActionResult> DeleteAsync(short id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound($"service with ID {id} not found.");

            return Ok("DeleteSuccess");
        }
    }
}
