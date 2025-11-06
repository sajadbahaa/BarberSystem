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
            var entitys = await _service.FindByIDAsync(id);
            if (entitys == null)
                return NotFound($"speclist with ID {id} not found.");

            return Ok(entitys);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllSpeclistAsync()
        {
            var entitys = await _service.FindAllSpeclistAsync();
            return Ok(entitys);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> FindServicesBySpeclistNameAsync(string speclityName)
        {
            var entittys = await _service.GetServicesBySpeclityName(speclityName);
            return Ok(entittys);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllSpeclistNamesAsync()
        {
            var entittys = await _service.GetAllSpeclityNamesAsync();
            return Ok(entittys);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllSpecliystActiveAsync()
        {
            var entittys = await _service.FindAllSpecliystActiveAsync();
            return Ok(entittys);
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

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetAllWithPaginationAsync(pageNumber, pageSize);

            if (result == null || result.Count == 0)
                return NotFound(new { message = "ماكو بيانات للعرض" });

            return Ok(result);
        }
    }
}
