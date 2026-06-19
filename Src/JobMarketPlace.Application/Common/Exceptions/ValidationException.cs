using System.Net;

namespace JobMarketPlace.Application.Common.Exceptions
{
    public sealed class ValidationException
    : ApiException
    {
        public ValidationException(
            IEnumerable<string> errors)
            : base(
                "Validation failed.",
                (int)HttpStatusCode.BadRequest)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; }
    }
}
