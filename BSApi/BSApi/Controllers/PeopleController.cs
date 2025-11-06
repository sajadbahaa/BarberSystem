using BussinesLayer;
using Dtos.PeopleDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _service;

        public PeopleController(PeopleService service)
        {
            _service = service;
        }

        // =================== FIND ===================

        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> FindByIDAsync(int id)
        {
            var person = await _service.FindByIDAsync(id);
            if (person == null)
                return NotFound($"Person with ID {id} not found.");

            return Ok(person);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindByNameAsync(string firstName, string secondName, string lastName)
        {
            var person = await _service.FindByNameAsync(firstName, secondName, lastName);
            if (person == null)
                return NotFound("Person not found by name.");

            return Ok(person);
        }
        
        //[HttpGet("[action]")]
        //public async Task<IActionResult> FindByEmailAsync(string email)
        //{
        //    var person = await _service.FindByEmailAsync(email);
        //    if (person == null)
        //        return NotFound($"No person found with email: {email}");

        //    return Ok(person);
        //}

        [HttpGet("[action]")]
        public async Task<IActionResult> FindByPhoneAsync(string phone)
        {
            var person = await _service.FindByPhoneAsync(phone);
            if (person == null)
                return NotFound($"No person found with phone: {phone}");

            return Ok(person);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllPeopleAsync()
        {
            var people = await _service.FindAllPeopleAsync();
            return Ok(people);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindAllPeopleActiveAsync()
        {
            var people = await _service.FindAllPeopleActiveAsync();
            return Ok(people);
        }

        // =================== ADD ===================

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync([FromBody] AddPeopleDtos dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var personId = await _service.AddAsync(dto);
            if (personId == 0)
                return BadRequest("Failed to add person.");

            return Ok(new { PersonID = personId });
        }

        // =================== UPDATE ===================

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePeopleDtos dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _service.UpdateAsync(dto);
            if (!success)
                return BadRequest("Failed to update person.");

            return Ok("UpdateSuccess");
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

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetAllWithPaginationAsync(pageNumber, pageSize);

            if (result == null || result.Count == 0)
                return NotFound(new { message = "???? ?????? ?????" });

            return Ok(result);
        }
    }
}
