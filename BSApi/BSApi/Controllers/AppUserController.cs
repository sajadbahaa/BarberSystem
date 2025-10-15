using BussinesLayer;
using Dtos.UsersDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class AppUserController : ControllerBase
    {
        private readonly AppUserService _service;

        public AppUserController(AppUserService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> FindUserByIDAsync(int userID)
        {
            var res = await _service.FindUserByIDAsync(userID);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindUserByUsernameAsync(string userName)
        {
            var res = await _service.FindUserByUsernameAsync(userName);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindUserByEmailAsync(string Email)
        {
            var res = await _service.FindUserByEmailAsync(Email);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var res = await _service.GetAllUsersAsync();
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var res = await _service.GetAllActiveAsync();
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDeactivatedAsync()
        {
            var res = await _service.GetAllDeactivatedAsync();
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUserWithRolesAsync()
        {
            var res = await _service.GetAllUserWithRolesAsync();
            return Ok(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPendingBarberAsync([FromBody] addUserDtos dto)
        {
            bool res = await _service.AddPendingBarberAsync(dto);
            return res? Ok(res):BadRequest();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] updateUserDtos dto)
        {
            var res = await _service.UpdateUserAsync(dto);
            return res? Ok(res):BadRequest();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var res = await _service.ChangePassword(dto);
            return Ok(res);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var res = await _service.ResetPassword(dto);
            return Ok(res);
        }

        // =================== ACTIVATE ===================

        [HttpPut("[action]/{id:int}")]
        public async Task<IActionResult> ActivateeAsync(int id)
        {
            var success = await _service.ActivateeAsync(id);
            if (!success)
                return NotFound($"Person with ID {id} not found");

            return Ok("ActivatedSuccess");
        }

        // =================== DELETE ===================

        [HttpDelete("[action]/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound($"Person with ID {id} not found.");

            return Ok("DeleteSuccess");
        }
    }
}
