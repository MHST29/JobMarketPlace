namespace Domain.Test
{
    public class ContractorTests
    {
        [Fact]
        public void Contractor_Should_Be_Created()
        {
            var contractor = new Contractor
            {
                Name = "Laptop",
                Rating = 10
            };

            contractor.Name.Should().Be("Laptop");
            contractor.Rating.Should().Be(10);
        }
    }
}