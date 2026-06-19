using JobMarketPlace.Application.Features.Customer.Query.SearchCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ISender _sender;

        public CustomersController(
            ISender sender)
        {
            _sender = sender;
        }
        [HttpGet("smi")]
        public async Task<IActionResult> Search(
    [FromQuery] SearchCustomersQuery query)
        {
            var result =
                await _sender.Send(query);

            return Ok(result);
        }
    }
}
