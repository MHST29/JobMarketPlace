using FluentValidation;

namespace JobMarketPlace.Application.Features.Contractor.Query.SearchContractors
{
    public class SearchContractorsValidator : AbstractValidator<SearchContractorsQuery>
    {
        public SearchContractorsValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100);

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.Name));

            RuleFor(x => x)
                .Must(x =>
                    x.Id.HasValue ||
                    !string.IsNullOrWhiteSpace(x.Name))
                .WithMessage(
                    "Either Id or Name must be provided.");
        }
    }
}
