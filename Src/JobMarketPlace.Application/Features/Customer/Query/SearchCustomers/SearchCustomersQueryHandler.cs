using JobMarketPlace.Application.Common.Exceptions;
using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Common.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Application.Features.Customer.Query.SearchCustomers
{
    public class SearchCustomersQueryHandler
      : IRequestHandler<
          SearchCustomersQuery,
          PagedResult<CustomerDto>>
    {
        private readonly IAppDbContext _context;

        private readonly ICacheService _cache;

        public SearchCustomersQueryHandler(
            IAppDbContext context,
            ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<PagedResult<CustomerDto>>
            Handle(
            SearchCustomersQuery request,
            CancellationToken cancellationToken)
        {
            var query =
                _context.Customers
                    .AsNoTracking()
                    .AsQueryable();

            if (request.Id.HasValue)
            {
                query = query.Where(
                    x => x.Id == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(
                request.LastName))
            {
                var search =
                    request.LastName.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(
                        x.LastName,
                        $"%{search}%"));
            }

            var totalCount =
                await query.CountAsync(
                    cancellationToken);

            var items =
                await query
                    .OrderBy(x => x.LastName)
                    .Skip(
                        (request.PageNumber - 1)
                        * request.PageSize)
                    .Take(request.PageSize)
                    .Select(x =>
                        new CustomerDto
                        {
                            Name = x.FirstName,
                            LastName = x.LastName
                        })
                    .ToListAsync(cancellationToken);

            if (items is null)
            {
                throw new NotFoundException(
                    nameof(items),
                    request.Id is null ? request.LastName : request.Id);
            }

            var result =
                new PagedResult<CustomerDto>
                {
                    Items = items,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    TotalCount = totalCount
                };
            return result;
        }
    }
}