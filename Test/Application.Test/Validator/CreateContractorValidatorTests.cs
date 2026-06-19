using FluentAssertions;
using JobMarketPlace.Application.Features.Contractor.Command.CreateContructor;

namespace Application.Test.Validator
{
    public class CreateContractorValidatorTests
    {
        private readonly CreateContractorValidator
        _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command =
                new CreateContractorCommand(
                    "",
                    10);

            var result =
                _validator.Validate(command);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_Be_Valid()
        {
            var command =
                new CreateContractorCommand(
                    "Laptop",
                    4);

            var result =
                _validator.Validate(command);

            result.IsValid.Should().BeTrue();
        }
    }
}
