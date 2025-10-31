using BussinesLayer;
using Dtos.AppointmentDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppoitmentServices _service;

        public AppointmentsController(AppoitmentServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<findAppointmentDtos?>> FindAppointmentDtos(int id)
        {
            var result = await _service.FindAppointmentDtos(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<findAppointmentDtos>?>> FindAllAppointmentsDtos()
        {
            var result = await _service.FindAllAppointmentsDtos();
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<int>> AddAsync([FromBody] addAppointmentDtos dto)
        {
            var id = await _service.AddAsync(dto);
            return id==0?BadRequest(): Ok($"add appointment [{id}] success.");
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<bool>> UpdateAsync([FromBody] updateAppointmentDtos dto)
        {
            var result = await _service.UpdateAsync(dto);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }

        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<bool>> UpdateAppointmentToPendingApprovalAsync(int id)
        {
            var result = await _service.UpdateAppointmentToPendingApprovalAsync(id);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }

        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<bool>> UpdateAppointmentToCompletedAsync(int id)
        {
            var result = await _service.UpdateAppointmentToCompletedAsync(id);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }

        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<bool>> UpdateAppointmentToCanceledAsync(int id)
        {
            var result = await _service.UpdateAppointmentToCanceledAsync(id);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }
    }
}
