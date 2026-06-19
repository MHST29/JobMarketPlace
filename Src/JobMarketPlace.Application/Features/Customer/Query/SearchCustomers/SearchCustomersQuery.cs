using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Common.Pagination;
using MediatR;

namespace JobMarketPlace.Application.Features.Customer.Query.SearchCustomers
{
    public record SearchCustomersQuery(
     Guid? Id,
     string? LastName,
     int PageNumber = 1,
     int PageSize = 10
 ) : IRequest<PagedResult<CustomerDto>>,
  ICacheable
    {
        public string CacheKey =>
            $"products:{Id}:{LastName}:{PageNumber}:{PageSize}";

        public TimeSpan Expiration =>
            TimeSpan.FromMinutes(5);

        public bool BypassCache => false;
    }
}
 