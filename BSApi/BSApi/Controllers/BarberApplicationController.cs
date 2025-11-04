using BussinesLayer;
using Dtos.ApplicationsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BSApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BarberApplicationController : ControllerBase
    {
        private readonly BarberApplicationService _service;

        public BarberApplicationController(BarberApplicationService service)
        {
            _service = service;
        }

        // -------------------------- [Add / Update / Cancel] --------------------------

        [Authorize(Roles = "PendingBarber")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddApplicationAsync([FromBody] addApplicationDtos dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (userIdFromToken == default || userIdFromToken!=dto.UserID)
            {
                return Forbid("Un Authorize.");
            }
            dto.UserID = userIdFromToken;
            var result = await _service.addApplicationAsync(dto);
            return result ? Ok("Application added successfully.") : BadRequest("Failed to add application.");
        }
        [Authorize(Roles = "PendingBarber")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateApplicationWithDraftStatusAsync([FromBody] updateApplicationDtos dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (dto.userID != userIdFromToken)
            {
                return Forbid("You are not allowed to update other user.");
            }
            var result = await _service.UpdateApplicationWithDraftStatusAsync(dto);
            return result ? Ok("Application updated successfully.") : BadRequest("Failed to update application.");
        }
        [Authorize(Roles = "PendingBarber")]
        [HttpPut("[Action]")]
        public async Task<IActionResult> UpdateTempBarberServiceAsync([FromBody] updateTempBarberServiceListDtos dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (dto.userID != userIdFromToken)
            {
                return Forbid("You are not allowed to update other user.");
            }
            var result = await _service.UpdateTempServicesAsync(dto.updateTempBarberServiceDto);
            return result ? Ok("temp barber updated successfully.") : BadRequest("Failed to update temp barber.");
        }

        [Authorize(Roles = "PendingBarber")]
        [HttpPost("[Action]")]
        public async Task<IActionResult> addTempBarberServiceAsync([FromBody] addTempBabrerServiceListDtos dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (dto.useriD != userIdFromToken)
            {
                return Forbid("You are not allowed to update other user.");
            }
            var result = await _service.AddTempServicesAsync(dto.AddTempBarberServiceList,dto.ApplicationID);
            return result ? Ok("temp barber updated successfully.") : BadRequest("Failed to update temp barber.");
        }


        [Authorize(Roles = "PendingBarber")]
        [HttpDelete("[Action]")]
        public async Task<IActionResult> RemoveTempBarberServiceAsync([FromBody] DeleteTempBarberServiceDto dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (dto.userID != userIdFromToken)
            {
                return Forbid("You are not allowed to Remove other user.");
            }
            var result = await _service.DeleteTempServicesAsync(dto.tempBabrerServicesIDs,dto.ApplicationID);
            return result ? Ok("temp barber Removed successfully.") : BadRequest("Failed to remove temp barber.");
        }


        // 
        [Authorize(Roles = "PendingBarber")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateApplicationWithStatusRejectedAsync([FromBody] updateFullApplicationRejectedDtos dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (dto.UpdateApplicationDtos.userID != userIdFromToken)
            {
                return Forbid("You are not allowed to Remove other user.");
            }
            var result = await _service.UpdateApplicationWithStatusRejectedAsync(dto);
            return result ? Ok("Updated Application Successfully.") : BadRequest("Failed Update Application.");
        }
        [Authorize(Roles = "PendingBarber")]
        [HttpPut("[action]/{id:int}")]
        public async Task<IActionResult> SendApplicationIntoAdminWithStatusDraftAsync(int id)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (userIdFromToken==default)
            {
                return Forbid("You are not allowed to Remove other user.");
            }
            var result = await _service.SendApplicationIntoAdminWithStatusDraftAsync(id,userIdFromToken);
            return result ? Ok("Application sent to admin successfully.") : BadRequest("Failed to send application to admin.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAdminApplicationIntoIntoRejectedStatusAsync([FromBody] RejectedOrCanceledApplicarionDtos dto)
        {

            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            // تحقق هل المستخدم يحاول تعديل بياناته فقط
            if (userIdFromToken!=dto.UserID ||userIdFromToken == default)
            {
                return Forbid("You are not allowed to Remove other user.");
            }

            var result = await _service.UpdateAdminApplicationIntoIntoRejectedStatusAsync(dto);
            return result ? Ok("Application rejected successfully.") : BadRequest("Failed to reject application.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAdminApplicationIntoAcceptStatusAsync( updateApplicationAcceptDto dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");


            if (userIdFromToken != dto.userID || userIdFromToken == default)
            {
                return Forbid("You are not allowed to Remove other user.");
            }
            var result = await _service.UpdateAdminApplicationIntoAcceptStatusAsync(dto.applicationID);
            return result ? Ok("Application accepted successfully.") : BadRequest("Failed to accept application.");
        }


     [Authorize(Roles = "Admin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> CancelApplicationByPendingBarberAsync([FromBody] RejectedOrCanceledApplicarionDtos dto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");


            if (userIdFromToken != dto.UserID || userIdFromToken == default)
            {
                return Forbid("You are not allowed to Remove other user.");
            }

            var result = await _service.CancelApplicationByPendingBarberAsync(dto);
            return result ? Ok("Application canceled successfully.") : BadRequest("Failed to cancel application.");
        }

        // -------------------------- [Get Application Info] --------------------------

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<findApplicationDtos>> GetApplicationInfoByIDAsync(int id)
        {
            var result = await _service.GetApplicationInfoByID(id);
            if (result == null)
                return NotFound("Application not found.");

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<findApplicationDtos>>> GetAllApplicationsAsync()
        {
            var result = await _service.GetAllApplicationsAsync();
            return Ok(result);
        }

        // -------------------------- [Temp Barber Services] --------------------------

        [HttpGet("[action]")]
        public async Task<ActionResult<List<findTempBarberServiceGeneralDtos>>> GetAllTempPendingServicesAsync()
        {
            var result = await _service.GetAllTempPendingServicesAsync();
            return Ok(result);
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<findTempBarberServiceGeneralDtos>> GetTempPendingServicesByTempIDAsync(int id)
        {
            var result = await _service.GetTempPendingServicesByTempIDAsync(id);
            if (result == null)
                return NotFound("Temp service not found.");

            return Ok(result);
        }

        // -------------------------- [Application History] --------------------------

        [HttpGet("[action]")]
        public async Task<ActionResult<List<findApplicationHistotyDtos>>> GetAllApplicationsHistotyAsync()
        {
            var result = await _service.GetAllApplicationsHistotyAsync();
            return Ok(result);
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<findApplicationHistotyDtos>> GetApplicationsHistoryByHistoryIDAsync(int id)
        {
            var result = await _service.GetApplicationsHistoryByHistoryIDAsync(id);
            if (result == null)
                return NotFound("Application history not found.");

            return Ok(result);
        }
    }
}
