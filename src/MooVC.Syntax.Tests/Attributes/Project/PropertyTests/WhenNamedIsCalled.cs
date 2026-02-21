namespace MooVC.Syntax.Attributes.Project.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var updated = new Name("Other");

        // Act
        Property result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Value.ShouldBe(original.Value);
    }
}