using BussinesLayer;
using Dtos.AppointmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize(Roles = "Customer")]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<int>> AddAsync([FromBody] addAppointmentDtos dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (userIdFromToken == default)
            {
                return Forbid("Un Authorize.");
            }

            var id = await _service.AddAsync(dto,userIdFromToken);
            return id==0?BadRequest(): Ok($"add appointment [{id}] success.");
        }

        [Authorize(Roles = "Customer")]
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<bool>> UpdateAsync([FromBody] updateAppointmentDtos dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (userIdFromToken == default)
            {
                return Forbid("Un Authorize.");
            }
            var result = await _service.UpdateAsync(dto,userIdFromToken);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }

        [Authorize(Roles = "Barber")]
        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<bool>> UpdateAppointmentToPendingApprovalAsync(int id)
        {

            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (userIdFromToken == default)
            {
                return Forbid("Un Authorize.");
            }

            //br01
            var result = await _service.UpdateAppointmentToPendingApprovalAsync(userIdFromToken,id);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }

        [Authorize(Roles = "Barber")]
        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<bool>> UpdateAppointmentToCompletedAsync(int id)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (userIdFromToken == default)
            {
                return Forbid("Un Authorize.");
            }

            var result = await _service.UpdateAppointmentToCompletedAsync(userIdFromToken,id);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }


        [Authorize(Roles = "Barber")]
        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<bool>> UpdateAppointmentToCanceledAsync(int id)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (userIdFromToken == default)
            {
                return Forbid("Un Authorize.");
            }
            var result = await _service.UpdateAppointmentToCanceledAsync(userIdFromToken, id);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }
    }
}
