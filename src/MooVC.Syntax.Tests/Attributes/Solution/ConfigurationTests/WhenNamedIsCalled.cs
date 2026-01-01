namespace MooVC.Syntax.Attributes.Solution.ConfigurationTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Configuration original = ConfigurationTestsData.Create();
        var updated = Snippet.From("Release");

        // Act
        Configuration result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Platform.ShouldBe(original.Platform);
    }
}