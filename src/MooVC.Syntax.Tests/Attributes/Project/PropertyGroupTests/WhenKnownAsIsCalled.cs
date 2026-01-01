namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string UpdatedLabel = "UpdatedLabel";

    [Fact]
    public void GivenLabelThenReturnsUpdatedInstance()
    {
        // Arrange
        PropertyGroup original = PropertyGroupTestsData.Create(property: PropertyGroupTestsData.CreateProperty());
        var updated = Snippet.From(UpdatedLabel);

        // Act
        PropertyGroup result = original.KnownAs(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Label.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Properties.ShouldBe(original.Properties);
    }
}