using BussinesLayer;
using Dtos.BarbersDtos;
using Dtos.PeopleDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarbersController : ControllerBase
    {
        private readonly BarbersServices _service;
        private readonly BarberServiceServices _serviceServices;
        public BarbersController(BarbersServices service, BarberServiceServices serviceServices)
        {
            _service = service;
            _serviceServices = serviceServices;
        }

        // =================== FIND ===================
        [Authorize(Roles = "Barber")]
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> FindByIDAsync(int id)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (id != userIdFromToken)
            {
                return Forbid("You are not allowed to update other user.");
            }
            var entity = await _service.GetBarberByIDAsync(id);
            if (entity == null)
                return NotFound($"Barber with ID {id} not found.");

            return Ok(entity);
        }
        [Authorize(Roles = "Barber")]
        [HttpGet("[action]")]
        public async Task<IActionResult> MyProfileAsync()
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            
            var entity = await _service.GetByUserIdAsync(userIdFromToken);
            if (entity == null)
                return NotFound($"Barber with ID {userIdFromToken} not found.");

            return Ok(entity);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBarbersAsync()
        {
            var entities = await _service.GetAllBarbersAsync();
            return Ok(entities);
        }

        [Authorize(Roles = "Barber")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMyServicesAsync()
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var entities = await _service.GetMyServices(userIdFromToken);
            return Ok(entities);
        }
        // =================== ADD ===================


        // =================== UPDATE ===================

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] updateBarberPersonDto dto)
        {
        int userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
 if (userIdFromToken==default)
            {
                return Forbid("Un Authorize.");
            }
            var success = await _service.UpdateBarberInfo(userIdFromToken,dto);
            if (!success)
                return BadRequest("Failed to update entity.");

            return Ok("UpdateSuccess");
        }

        [Authorize(Roles = "Barber")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBarberServiceAsync([FromBody] updateBarberServiceDto dto)
        {
            var success = await _serviceServices.UpdateAsync(dto);
            if (!success)
                return BadRequest("Failed to update entity.");

            return Ok("UpdateSuccess");
        }

        [Authorize(Roles = "Barber")]
        [HttpPut("[action]")]
        public async Task<IActionResult> AddBarberServiceAsync([FromBody] addBarberServiceDto dto)
        {
            int userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (userIdFromToken == default) 
            {
                return Forbid("Un Authorize.");
            }

            int barberServiceiD = await _serviceServices.AddBarberServiceAsync(dto,userIdFromToken);
            if (barberServiceiD==0)
                return BadRequest("Failed to add entity.");

            return Ok($"barber Service [{barberServiceiD}] has been added success.");
        }

        // find Barber service ID
        [Authorize(Roles = "Barber")]
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> FindBarberServiceByIDAsync(int id)
        {
           var entity = await _serviceServices.FindBarberServiceByIDAsync(id);
            if (entity == null)
                return NotFound($"Barber service not with ID {id} not found.");

            return Ok(entity);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBarbersServicesAsync()
        {
            var entities = await _serviceServices.FindAllBarberServiceAsync();
            return Ok(entities);
        }
        // =================== ACTIVATE ===================

        //[HttpPut("[action]/{id:int}")]
        //public async Task<IActionResult> ActivateeAsync(int id)
        //{
        //    var barberServiceiD = await _service.ActivateeAsync(id);
        //    if (!barberServiceiD)
        //        return NotFound($"Person with ID {id} not found");

        //    return Ok("ActivatedSuccess");
        //}

        // =================== DELETE ===================

        //[HttpDelete("[action]/{id:int}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var barberServiceiD = await _service.DeleteAsync(id);
        //    if (!barberServiceiD)
        //        return NotFound($"Person with ID {id} not found.");

        //    return Ok("DeleteSuccess");
        //}
    }
}
