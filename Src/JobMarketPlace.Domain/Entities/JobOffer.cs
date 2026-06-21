namespace JobMarketPlace.Domain.Entities
{
    public class JobOffer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Price { get; set; }
        public Guid JobId { get; set; }
        public Guid ContractorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
