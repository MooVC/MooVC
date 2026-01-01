namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;

public sealed class WhenWithConfigurationsIsCalled
{
    [Fact]
    public void GivenConfigurationsThenReturnsUpdatedInstance()
    {
        // Arrange
        Configuration existing = SolutionTestsData.CreateConfiguration();
        var additional = new Configuration
        {
            Name = Snippet.From("Release"),
            Platform = Snippet.From("x64"),
        };
        Solution original = SolutionTestsData.Create(configuration: existing);

        // Act
        Solution result = original.WithConfigurations(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Configurations.ShouldBe(original.Configurations.Concat([additional]));
        result.Files.ShouldBe(original.Files);
    }
}