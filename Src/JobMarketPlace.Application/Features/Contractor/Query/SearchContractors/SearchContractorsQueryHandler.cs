using JobMarketPlace.Application.Common.Exceptions;
using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Common.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Application.Features.Contractor.Query.SearchContractors
{
    public class SearchContractorsQueryHandler
  : IRequestHandler<
      SearchContractorsQuery,
      PagedResult<ContractorDto>>
    {
        private readonly IAppDbContext _context;

        private readonly ICacheService _cache;

        public SearchContractorsQueryHandler(
            IAppDbContext context,
            ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<PagedResult<ContractorDto>>
            Handle(
            SearchContractorsQuery request,
            CancellationToken cancellationToken)
        {
            var query =
     _context.Contractors
         .AsNoTracking()
         .AsQueryable();

            if (request.Id.HasValue)
            {
                query = query.Where(
                    x => x.Id == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(
                request.Name))
            {
                var search =
                    request.Name.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(
                        x.Name,
                        $"%{search}%"));
            }

            var totalCount =
                await query.CountAsync(
                    cancellationToken);

            var items =
                await query
                    .OrderBy(x => x.Name)
                    .Skip(
                        (request.PageNumber - 1)
                        * request.PageSize)
                    .Take(request.PageSize)
                    .Select(x =>
                        new ContractorDto
                        {
                            Name = x.Name,
                            Id = x.Id
                        })
                    .ToListAsync(cancellationToken);

            if (items is null)
            {
                throw new NotFoundException(
                    nameof(items),
                    request.Id is null ? request.Name : request.Id);
            }

            var result =
                new PagedResult<ContractorDto>
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

