namespace JobMarketPlace.Application.Features.JobOffer.Query.GetAllJobOffers
{
    public class JobOfferResponseDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Guid JobId { get; set; }
        public Guid ContractorId { get; set; }
    }
}
