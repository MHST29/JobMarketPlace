using System.Net;

namespace JobMarketPlace.Application.Common.Exceptions
{
    public sealed class ForbiddenException
        : ApiException
    {
        public ForbiddenException(
            string message = "Access denied.")
            : base(
                message,
                (int)HttpStatusCode.Forbidden)
        {
        }
    }
}
