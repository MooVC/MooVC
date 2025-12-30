namespace MooVC.Syntax.CSharp.Attributes.Solution.ConfigurationTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Configuration original = ConfigurationTestsData.Create();
        Snippet updated = Snippet.From("Release");

        // Act
        Configuration result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Platform.ShouldBe(original.Platform);
    }
}