using FluentValidation;
using JobMarketPlace.Application.Features.Contractor.Command.CreateContructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMarketPlace.Application.Features.JobOffer.Command.CreateJobOffer
{
    internal class CreateJobOfferValidator : AbstractValidator<CreateJobOfferCommand>
    {
        public CreateJobOfferValidator()
        {
            RuleFor(x => x.JobId)
                .NotEmpty();

            RuleFor(x => x.ContractorId)
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .LessThan(6)
                .GreaterThan(0);
        }
    }
}
