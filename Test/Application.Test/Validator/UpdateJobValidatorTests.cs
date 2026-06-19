using FluentAssertions;
using JobMarketPlace.Application.Features.Job.Command.UpdateJob;

namespace Application.Test.Validator
{
    public class UpdateJobValidatorTests
    {
        private readonly UpdateJobValidator _validator;

        public UpdateJobValidatorTests()
        {
            _validator = new UpdateJobValidator();
        }

        [Fact]
        public void Should_Pass_When_Request_Is_Valid()
        {
            var command = new UpdateJobCommand(
             Guid.NewGuid(),
             new DateOnly(2024, 5, 10),
                new DateOnly(2024, 5, 10),
                120000,
                "Test Job",
                new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));

            var result = _validator.Validate(command);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should_Fail_When_Id_Is_Empty()
        {
            var command = new UpdateJobCommand(
             Guid.Empty,
             new DateOnly(2024, 5, 10),
                new DateOnly(2024, 5, 10),
                120000,
                "Test Job",
                new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));

            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
        }

    }
}
