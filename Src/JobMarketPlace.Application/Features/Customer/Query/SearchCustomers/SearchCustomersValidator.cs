using FluentValidation;

namespace JobMarketPlace.Application.Features.Customer.Query.SearchCustomers
{
    public class SearchCustomersValidator : AbstractValidator<SearchCustomersQuery>
    {
        public SearchCustomersValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100);

            RuleFor(x => x.LastName)
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.LastName));

            RuleFor(x => x)
                .Must(x =>
                    x.Id.HasValue ||
                    !string.IsNullOrWhiteSpace(x.LastName))
                .WithMessage(
                    "Either Id or LastName must be provided.");
        }
    }
}
