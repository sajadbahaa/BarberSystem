using BussinesLayer;
using Dtos.PeopleDtos;
using Dtos.SpeclisysDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeclitController : ControllerBase
    {
        private readonly SpeclistServices _service;

        public SpeclitController(SpeclistServices service)
        {
            _service = service;
        }

        // =================== FIND ===================

        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> FindByIDAsync(short id)
        {
            var person = await _service.FindByIDAsync(id);
            if (person == null)
                return NotFound($"speclist with ID {id} not found.");

            return Ok(person);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllSpeclistAsync()
        {
            var people = await _service.FindAllSpeclistAsync();
            return Ok(people);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllSpecliystActiveAsync()
        {
            var people = await _service.FindAllSpecliystActiveAsync();
            return Ok(people);
        }

        // =================== ADD ===================

        [HttpPost("[action]")]
        public async Task<IActionResult> AddSpeclistServiceNewAsync([FromBody] addSpeclistNewDtos dto)
        {
            
            bool res = await _service.AddSpeclistAsync(dto);
            if (!res )
                return BadRequest("Failed to add Speclist.");

            return Ok("add speclist succes");
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddSpeclisServiceAsync([FromBody] addSpeclistDtos dto)
        {
         
            bool res = await _service.AddSpeclistAsync(dto);
            if (!res)
                return BadRequest("Failed to add Services.");

            return Ok("add Services succes");
        }
        // =================== UPDATE ===================

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] updateSpeclistDtos dto)
        {
       
            var success = await _service.UpdateAsync(dto);
            if (!success)
                return BadRequest("Failed to update speclist.");

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
                return NotFound($"speclist with ID {id} not found.");

            return Ok("DeleteSuccess");
        }
    }
}
