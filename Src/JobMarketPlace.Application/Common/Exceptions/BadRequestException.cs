using System.Net;

namespace JobMarketPlace.Application.Common.Exceptions
{
    public sealed class BadRequestException
    : ApiException
    {
        public BadRequestException(
            string message)
            : base(
                message,
                (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
