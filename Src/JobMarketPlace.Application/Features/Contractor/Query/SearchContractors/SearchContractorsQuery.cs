using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Common.Pagination;
using MediatR;

namespace JobMarketPlace.Application.Features.Contractor.Query.SearchContractors
{
    public record SearchContractorsQuery(
  Guid? Id,
  string? Name,
  int PageNumber = 1,
  int PageSize = 10
) : IRequest<PagedResult<ContractorDto>>,
  ICacheable
    {
        public string CacheKey =>
            $"products:{Id}:{Name}:{PageNumber}:{PageSize}";

        public TimeSpan Expiration =>
            TimeSpan.FromMinutes(5);

        public bool BypassCache => false;
    }
}
