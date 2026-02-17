namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenForPropertyIsCalled
{
    [Fact]
    public void GivenPropertyNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Output original = OutputTestsData.Create();
        var updated = new Name("Other");

        // Act
        Output result = original.ForProperty(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.PropertyName.ShouldBe(updated);
        result.ItemName.ShouldBe(original.ItemName);
        result.Condition.ShouldBe(original.Condition);
    }
}