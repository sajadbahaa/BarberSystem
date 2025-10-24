using BussinesLayer;
using Dtos.ApplicationsDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        [HttpPost("[action]")]
        public async Task<IActionResult> AddApplicationAsync([FromBody] addApplicationDtos dto)
        {

            var result = await _service.addApplicationAsync(dto);
            return result ? Ok("Application added successfully.") : BadRequest("Failed to add application.");
        }

        [HttpPut("update-draft")]
        public async Task<IActionResult> UpdateApplicationWithDraftStatusAsync([FromBody] updateFullApplicationDtos dto)
        {
            var result = await _service.UpdateApplicationWithDraftStatusAsync(dto);
            return result ? Ok("Application updated successfully.") : BadRequest("Failed to update application.");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateApplicationWithStatusRejectedAsync([FromBody] updateFullApplicationRejectedDtos dto)
        {
            var result = await _service.UpdateApplicationWithStatusRejectedAsync(dto);
            return result ? Ok("Updated Application Successfully.") : BadRequest("Failed Update Application.");
        }

        [HttpPut("[action]/{id:int}")]
        public async Task<IActionResult> SendApplicationIntoAdminWithStatusDraftAsync(int id)
        {
            var result = await _service.SendApplicationIntoAdminWithStatusDraftAsync(id);
            return result ? Ok("Application sent to admin successfully.") : BadRequest("Failed to send application to admin.");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAdminApplicationIntoIntoRejectedStatusAsync([FromBody] RejectedOrCanceledApplicarionDtos dto)
        {
            var result = await _service.UpdateAdminApplicationIntoIntoRejectedStatusAsync(dto);
            return result ? Ok("Application rejected successfully.") : BadRequest("Failed to reject application.");
        }

        [HttpPut("[action]/{ApplicationID:int}")]
        public async Task<IActionResult> UpdateAdminApplicationIntoAcceptStatusAsync( int ApplicationID)
        {
            var result = await _service.UpdateAdminApplicationIntoAcceptStatusAsync(ApplicationID);
            return result ? Ok("Application accepted successfully.") : BadRequest("Failed to accept application.");
        }

        [HttpPut]
        public async Task<IActionResult> CancelApplicationByPendingBarberAsync([FromBody] RejectedOrCanceledApplicarionDtos dto)
        {
            
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
