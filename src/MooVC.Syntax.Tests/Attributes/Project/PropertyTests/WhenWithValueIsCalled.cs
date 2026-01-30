namespace MooVC.Syntax.Attributes.Project.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    private const string UpdatedValue = "UpdatedValue";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var updated = Snippet.From(UpdatedValue);

        // Act
        Property result = original.WithValue(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Value.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Name.ShouldBe(original.Name);
    }
}