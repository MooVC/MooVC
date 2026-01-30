namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenWithConfigurationsIsCalled
{
    [Fact]
    public void GivenConfigurationsThenReturnsUpdatedInstance()
    {
        // Arrange
        Configurations existing = Configurations.Default;

        var updated = new Configurations
        {
            Builds = ["Release"],
            Platforms = ["x64"],
        };

        Solution original = SolutionTestsData.Create(configurations: existing);

        // Act
        Solution result = original.WithConfigurations(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Configurations.ShouldBe(updated);
        result.Files.ShouldBe(original.Files);
    }
}