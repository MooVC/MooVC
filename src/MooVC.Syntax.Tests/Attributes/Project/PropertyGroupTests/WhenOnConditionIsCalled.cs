namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        PropertyGroup original = PropertyGroupTestsData.Create(property: PropertyGroupTestsData.CreateProperty());
        var updated = Snippet.From(UpdatedCondition);

        // Act
        PropertyGroup result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.Label.ShouldBe(original.Label);
        result.Properties.ShouldBe(original.Properties);
    }
}