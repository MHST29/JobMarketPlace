using FluentAssertions;
using JobMarketPlace.Application.Features.Job.Command.DeleteJob;
using JobMarketPlace.Application.Features.JobOffer.Command.DeleteJobOffer;

namespace Application.Test.Validator
{
    public class DeleteJobOfferValidatorTest
    {
        [Fact]
        public void Should_Fail_When_Id_Is_Empty()
        {
            var validator =
                new DeleteJobOfferValidator();

            var command =
                new DeleteJobOfferCommand(
                    Guid.Empty);

            var result =
                validator.Validate(command);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_Pass_When_Id_Is_Valid()
        {
            var validator =
                new DeleteJobOfferValidator();

            var command =
                new DeleteJobOfferCommand(
                    Guid.NewGuid());

            var result =
                validator.Validate(command);

            result.IsValid.Should().BeTrue();
        }
    }
}
