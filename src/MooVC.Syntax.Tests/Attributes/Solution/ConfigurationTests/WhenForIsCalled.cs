namespace MooVC.Syntax.Attributes.Solution.ConfigurationTests;

using MooVC.Syntax.Elements;

public sealed class WhenForIsCalled
{
    [Fact]
    public void GivenPlatformThenReturnsUpdatedInstance()
    {
        // Arrange
        Configuration original = ConfigurationTestsData.Create();
        var updated = Snippet.From("x64");

        // Act
        Configuration result = original.For(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Platform.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}