using System.Net;

namespace JobMarketPlace.Application.Common.Exceptions
{
    public sealed class UnauthorizedException
    : ApiException
    {
        public UnauthorizedException(
            string message = "Unauthorized.")
            : base(
                message,
                (int)HttpStatusCode.Unauthorized)
        {
        }
    }
}
