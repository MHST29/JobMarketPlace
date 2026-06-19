using JobMarketPlace.Application.Features.Job.Command.CreateJob;
using JobMarketPlace.Application.Features.Job.Command.DeleteJob;
using JobMarketPlace.Application.Features.Job.Command.UpdateJob;
using JobMarketPlace.Application.Features.Job.Query.GetAllJobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ISender _sender;

        public JobsController(
            ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobCommand command)
        {
            var id = await _sender.Send(command);
            return Created($"/api/jobs/{id}", new { id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateJobCommand request)
        {
            var command = new UpdateJobCommand(
                id,
                request.StartDate,
                request.DueDate,
                request.Budget,
                request.Description,
                request.AcceptedJobOfferId,
                request.CustomerId);

            var result = await _sender.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _sender.Send(new DeleteJobCommand(id));

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var result = await _sender.Send(new GetJobsQuery());

            return Ok(result);
        }

    }
}
