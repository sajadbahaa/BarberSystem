using BussinesLayer;
using Dtos.CustomerDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BSApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomersServices _service;

        public CustomerController(CustomersServices service)
        {
            _service = service;
        }

        // ✅ Get all customers
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _service.GetAllCustomersAsync();
            if (customers == null || customers.Count == 0)
                return NotFound("لا يوجد زبائن.");

            return Ok(customers);
        }

        // ✅ Get customer by ID
        //[HttpGet("{id:int}")]
        //[Authorize(Roles ="Customer")]
        //public async Task<IActionResult> GetCustomerById(int id)
        //{
        //    var customer = await _service.GetCustomerByIDAsync(id);
        //    if (customer == null)
        //        return NotFound("الزبون غير موجود.");

        //    return Ok(customer);
        //}

        // ✅ Get customer by user ID
        [HttpGet("by-user")]
        [Authorize(Roles = "Customer")]
        //[Authorize]
        public async Task<IActionResult> GetCustomerByUserId()
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            if (userIdFromToken==default)
            {
                return Unauthorized();
            }

            var customer = await _service.GetByUserIdAsync(userIdFromToken);
            if (customer == null)
                return NotFound("الزبون غير موجود لهذا المستخدم.");

            return Ok(customer);
        }

        // ✅ Add new customer
        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> AddCustomer([FromBody] addCustomerPersonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.AddCustomerAsync(dto);
            if (result == 0)
                return BadRequest("فشل إنشاء الزبون، تحقق من البيانات.");

            return Ok(new { message = "تم إنشاء الزبون بنجاح", customerId = result });
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetAllWithPaginationAsync(pageNumber, pageSize);

            if (result == null || result.Count == 0)
                return NotFound(new { message = "ماكو بيانات للعرض" });

            return Ok(result);
        }
        // ✅ Update customer info
        //[HttpPut("{userId:int}")]
        ////[Authorize]
        //public async Task<IActionResult> UpdateCustomer(int userId, [FromBody] updateCustomerPersonDto dto)
        //{
        //    //if (!ModelState.IsValid)
        //    //    return BadRequest(ModelState);

        //    bool updated = await _service.UpdateCustomerAsync(userId, dto);

        //    if (!updated)
        //        return NotFound("فشل التحديث، لم يتم العثور على الزبون.");

        //    return Ok("تم تحديث معلومات الزبون بنجاح.");
        //}
    }
}
