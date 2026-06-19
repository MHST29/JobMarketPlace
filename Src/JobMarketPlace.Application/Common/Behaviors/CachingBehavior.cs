using JobMarketPlace.Application.Common.Interfaces;
using MediatR;

namespace JobMarketPlace.Application.Common.Behaviors;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ICacheService _cache;

    public CachingBehavior(
        ICacheService cache)
    {
        _cache = cache;
    }

    public async Task<TResponse> Handle(
        TRequest request,

        RequestHandlerDelegate<TResponse> next,

        CancellationToken cancellationToken)
    {
        if (request is not ICacheable cacheable)
        {
            return await next();
        }

        if (cacheable.BypassCache)
        {
            return await next();
        }

        var cached =
            await _cache.GetAsync<TResponse>(
                cacheable.CacheKey);

        if (cached is not null)
        {
            return cached;
        }

        var response =
            await next();

        await _cache.SetAsync(
            cacheable.CacheKey,

            response,

            cacheable.Expiration);

        return response;
    }
}