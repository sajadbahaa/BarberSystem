using BussinesLayer;
using Dtos.RatingsDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly RatingsService _service;

        public RatingController(RatingsService service)
        {
            _service = service;
        }

        // ✅ إضافة تقييم جديد
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<bool>> AddRatingAsync([FromBody] addRatingDtos dto)
        {
            var result = await _service.AddRatingAsync(dto);
            if (!result)
                return BadRequest("Failed to add rating. Either appointment is invalid or update failed.");

            return Ok("Rating added successfully and barber rating updated.");
        }

        // ✅ تحديث تقييم
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<bool>> UpdateRatingAsync([FromBody] updateRatingDtos dto)
        {
            var result = await _service.UpdateRatingAsync(dto);
            if (!result)
                return BadRequest("Failed to update rating or update barber rating.");

            return Ok("Rating updated successfully.");
        }

        // ✅ حذف تقييم
        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult<bool>> DeleteAsync([FromBody] deleteRatingDtos dto)
        {
            var result = await _service.DeleteAsync(dto);
            if (!result)
                return BadRequest("Failed to delete rating or update barber rating.");

            return Ok("Rating deleted successfully and barber rating updated.");
        }

        // ✅ الحصول على تقييم حسب الـ ID
        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<findRatingDtos?>> GetRatingByIDAsync(int id)
        {
            var result = await _service.GetRatingByIDAsync(id);
            if (result == null)
                return NotFound("Rating not found.");

            return Ok(result);
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> FindByIDV1Async(int id)
        {
            var person = await _service.FindByIDV1Async(id);
            if (person == null)
                return NotFound($"entity ID {id} not found.");

            return Ok(person);
        }


        // ✅ الحصول على كل التقييمات
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<findRatingDtos>?>> GetAllRatingsAsync()
        {
            var result = await _service.GetAllRatingsAsync();
            return Ok(result);
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
