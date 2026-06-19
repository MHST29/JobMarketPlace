using System.Net;

namespace JobMarketPlace.Application.Common.Exceptions
{
    public sealed class NotFoundException
    : ApiException
    {
        public NotFoundException(
            string entity,
            object id)
            : base(
                $"{entity} ({id}) was not found.",
                (int)HttpStatusCode.NotFound)
        {
        }
    }
}
