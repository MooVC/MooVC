namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string UpdatedLabel = "UpdatedLabel";

    [Fact]
    public void GivenLabelThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = UpdatedLabel;

        // Act
        Import result = original.KnownAs(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Label.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Project.ShouldBe(original.Project);
    }
}