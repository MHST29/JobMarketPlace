namespace JobMarketPlace.Application.Features.Job.Query.GetAllJobs
{
    public class JobResponseDto
    {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly DueDate { get; set; }
        public decimal Budget { get; set; }
        public string? Description { get; set; }
        public Guid? AcceptedJobOfferId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
