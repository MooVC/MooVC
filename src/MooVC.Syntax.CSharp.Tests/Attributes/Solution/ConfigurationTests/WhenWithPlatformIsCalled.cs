namespace MooVC.Syntax.CSharp.Attributes.Solution.ConfigurationTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithPlatformIsCalled
{
    [Fact]
    public void GivenPlatformThenReturnsUpdatedInstance()
    {
        // Arrange
        Configuration original = ConfigurationTestsData.Create();
        Snippet updated = Snippet.From("x64");

        // Act
        Configuration result = original.WithPlatform(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Platform.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}