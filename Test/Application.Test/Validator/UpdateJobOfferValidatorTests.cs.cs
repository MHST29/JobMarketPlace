using FluentAssertions;
using JobMarketPlace.Application.Features.JobOffer.Command.UpdateJobOffer;

namespace Application.Test.Validator
{
    public class UpdateJobOfferValidatorTests
    {
        private readonly UpdateJobOfferValidator _validator;

        public UpdateJobOfferValidatorTests()
        {
            _validator = new UpdateJobOfferValidator();
        }

        [Fact]
        public void Should_Pass_When_Request_Is_Valid()
        {
            var command = new UpdateJobOfferCommand(
             Guid.NewGuid(),
             120000,
              Guid.NewGuid(),
              Guid.NewGuid());

            var result = _validator.Validate(command);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should_Fail_When_Id_Is_Empty()
        {
            var command = new UpdateJobOfferCommand(
             Guid.Empty,
             120000,
              Guid.NewGuid(),
              Guid.NewGuid());

            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_Fail_When_Price_Is_Invalid()
        {
            var command = new UpdateJobOfferCommand(
                Guid.NewGuid(),
                -4,
                 Guid.NewGuid(),
                 Guid.NewGuid());

            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
        }
    }
}