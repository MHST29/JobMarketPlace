using JobMarketPlace.Application.Features.Job.Command.DeleteJob;
using JobMarketPlace.Application.Features.Job.Query.GetAllJobs;
using JobMarketPlace.Application.Features.JobOffer.Command.CreateJobOffer;
using JobMarketPlace.Application.Features.JobOffer.Command.DeleteJobOffer;
using JobMarketPlace.Application.Features.JobOffer.Command.UpdateJobOffer;
using JobMarketPlace.Application.Features.JobOffer.Query.GetAllJobOffers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsOfferController : ControllerBase
    {
        private readonly ISender _sender;

        public JobsOfferController(
            ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobOfferCommand command)
        {
            var id = await _sender.Send(command);
            return Created($"/api/joboffers/{id}", new { id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateJobOfferCommand request)
        {
            var command = new UpdateJobOfferCommand(
                id,
                request.Price,
                request.JobId,
                request.ContractorId);

            var result = await _sender.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _sender.Send(new DeleteJobOfferCommand(id));

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetJobOffers()
        {
            var result = await _sender.Send(new GetJobOffersQuery());

            return Ok(result);
        }
    }
}
