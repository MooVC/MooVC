namespace MooVC.Syntax.Attributes.Solution.PropertyTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var updated = Snippet.From("OtherName");

        // Act
        Property result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Value.ShouldBe(original.Value);
    }
}