using JobMarketPlace.Application.Features.Contractor.Command.CreateContructor;
using JobMarketPlace.Application.Features.Customer.Query.SearchCustomers;
using JobMarketPlace.Application.Features.Job.Command.UpdateJob;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ISender _sender;

        public ContractorsController(
            ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractorCommand command)
        {
            var id = await _sender.Send(command);
            return Created($"/api/contractors/{id}", new { id });
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
