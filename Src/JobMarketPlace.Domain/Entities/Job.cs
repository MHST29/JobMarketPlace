namespace JobMarketPlace.Domain.Entities
{
    public class Job
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateOnly StartDate { get; set; }
        public DateOnly DueDate { get; set; }
        public  decimal Budget { get; set; }
        public string? Description { get; set; }
        public Guid? AcceptedJobOfferId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
