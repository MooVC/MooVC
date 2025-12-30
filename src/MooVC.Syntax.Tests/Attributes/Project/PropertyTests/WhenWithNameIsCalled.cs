namespace MooVC.Syntax.Attributes.Project.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var updated = new Identifier("Other");

        // Act
        Property result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Value.ShouldBe(original.Value);
    }
}