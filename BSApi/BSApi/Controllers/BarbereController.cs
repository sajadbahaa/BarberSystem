using BussinesLayer;
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

        public BarbersController(BarbersServices service)
        {
            _service = service;
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
                return Forbid("You are not allowed to update other users.");
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
        // =================== ADD ===================

        
        // =================== UPDATE ===================

        //[HttpPut("[action]")]
        //public async Task<IActionResult> UpdateAsync([FromBody] UpdatePeopleDtos dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var success = await _service.UpdateAsync(dto);
        //    if (!success)
        //        return BadRequest("Failed to update entity.");

        //    return Ok("UpdateSuccess");
        //}

        // =================== ACTIVATE ===================

        //[HttpPut("[action]/{id:int}")]
        //public async Task<IActionResult> ActivateeAsync(int id)
        //{
        //    var success = await _service.ActivateeAsync(id);
        //    if (!success)
        //        return NotFound($"Person with ID {id} not found");

        //    return Ok("ActivatedSuccess");
        //}

        // =================== DELETE ===================

        //[HttpDelete("[action]/{id:int}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var success = await _service.DeleteAsync(id);
        //    if (!success)
        //        return NotFound($"Person with ID {id} not found.");

        //    return Ok("DeleteSuccess");
        //}
    }
}
