using BussinesLayer;
using BussinesLayer.Services.Jwt;
using Dtos.UsersDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]

    //[Microsoft.AspNetCore.Authorization.Authorize]
    public class AppUserController : ControllerBase
    {
        private readonly AppUserService _service;
        readonly IJwtServices _jwtServices;

        public AppUserController(AppUserService service, IJwtServices jwtServices)
        {
            _service = service;
            _jwtServices = jwtServices;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDtos dto)
        {
            var (user, roles) = await _service.LogainAsync(dto.UserName,dto.Password);

            if (user == null)
                return Unauthorized("Invalid username or password.");

            // هنا تولّد JWT
            var token = _jwtServices.GenerateTokenAsync(user, roles);

            return Ok(new
            {
                token,
                username = user.UserName,
                roles
            });
        }

        [Authorize]
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

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var res = await _service.GetAllUsersAsync();
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var res = await _service.GetAllActiveAsync();
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDeactivatedAsync()
        {
            var res = await _service.GetAllDeactivatedAsync();
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
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
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (dto.Id != userIdFromToken)
            {
                return Forbid("You are not allowed to update other user.");
            }

            var res = await _service.UpdateUserAsync(dto);
            return res? Ok(res):BadRequest();
        }
        [Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (dto.UserId != userIdFromToken)
            {
                return Forbid("You are not allowed to update other user.");
            }


            var res = await _service.ChangePassword(dto);
            return Ok(res);
        }

        //[Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (dto.UserId != userIdFromToken&dto.UserId!=dto.UserId)
            {
                return Forbid("You are not allowed to update other user.");
            }


            var res = await _service.ResetPassword(dto);
            return Ok(res);
        }

        // =================== ACTIVATE ===================

        [Authorize]

        [HttpPut("[action]/{id:int}")]
        public async Task<IActionResult> ActivateeAsync(int id)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (id != userIdFromToken)
            {
                return Forbid("You are not allowed to update other user.");
            }


            var success = await _service.ActivateeAsync(id);
            if (!success)
                return NotFound($"User with ID {id} not found");

            return Ok("ActivatedSuccess");
        }

        // =================== DELETE ===================

        [Authorize]
        [HttpDelete("[action]/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (id != userIdFromToken)
            {
                return Forbid("You are not allowed to update other user.");
            }
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound($"Person with ID {id} not found.");

            return Ok("DeleteSuccess");
        }
    }
}
