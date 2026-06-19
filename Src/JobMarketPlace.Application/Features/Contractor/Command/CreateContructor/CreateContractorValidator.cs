using FluentValidation;

namespace JobMarketPlace.Application.Features.Contractor.Command.CreateContructor
{
    public class CreateContractorValidator
    : AbstractValidator<CreateContractorCommand>
    {
        public CreateContractorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(400);

            RuleFor(x => x.Rating)
                .LessThan(6)
                .GreaterThan(0);
        }
    }
}
