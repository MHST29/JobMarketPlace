    using FluentAssertions;
    using JobMarketPlace.Application.Common.Interfaces;
    using JobMarketPlace.Application.Features.Contractor.Command.CreateContructor;
    using Moq;
    using Moq.EntityFrameworkCore;
    using Xunit;

    namespace JobMarketPlace.Application.Test.Contractor
    {
        public class CreateContractorCommandHandlerTests
        {
            [Fact]
            public async Task Handle_Should_Create_Contractor()
            {
                // Arrange

                var contractors = new List<Domain.Entities.Contractor>();

                var mockContext = new Mock<IAppDbContext>();

                mockContext.Setup(x => x.Contractors)
                    .ReturnsDbSet(contractors);

                mockContext.Setup(x => x.SaveChangesAsync(
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(1);

                var handler =
                    new CreateContractorCommandHandler(
                        mockContext.Object);

                var command = new CreateContractorCommand(
                    "Laptop",
                    5);

                // Act

                var result = await handler.Handle(
                    command,
                    CancellationToken.None);

                // Assert

                result.Should().NotBeEmpty();

                mockContext.Verify(x =>
                    x.SaveChangesAsync(
                        It.IsAny<CancellationToken>()),
                    Times.Once);
            }
        }
    }

