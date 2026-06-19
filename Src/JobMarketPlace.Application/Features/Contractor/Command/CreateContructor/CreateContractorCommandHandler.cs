using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Domain.Entities;
using MediatR;

namespace JobMarketPlace.Application.Features.Contractor.Command.CreateContructor
{
    public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateContractorCommandHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
            CreateContractorCommand request,
            CancellationToken cancellationToken)
        {
            var contractor = new Domain.Entities.Contractor
            {
                Name = request.Name,
                Rating = request.Rating,
            };

            await _context.Contractors.AddAsync(
                contractor,
                cancellationToken);

            await _context.SaveChangesAsync(
                cancellationToken);

            return contractor.Id;
        }
    }
}
