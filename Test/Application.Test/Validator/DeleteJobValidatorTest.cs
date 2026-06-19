using FluentAssertions;
using JobMarketPlace.Application.Features.Job.Command.DeleteJob;

namespace Application.Test.Validator
{
    public class DeleteJobValidatorTest
    {
        [Fact]
        public void Should_Fail_When_Id_Is_Empty()
        {
            var validator =
                new DeleteJobValidator();

            var command =
                new DeleteJobCommand(
                    Guid.Empty);

            var result =
                validator.Validate(command);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_Pass_When_Id_Is_Valid()
        {
            var validator =
                new DeleteJobValidator();

            var command =
                new DeleteJobCommand(
                    Guid.NewGuid());

            var result =
                validator.Validate(command);

            result.IsValid.Should().BeTrue();
        }
    }
}
