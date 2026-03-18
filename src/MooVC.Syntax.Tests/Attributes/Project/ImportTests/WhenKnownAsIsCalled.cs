namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string UpdatedLabel = "UpdatedLabel";

    [Test]
    public async Task GivenLabelThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = Snippet.From(UpdatedLabel);

        // Act
        Import result = original.KnownAs(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Label).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Project).IsEqualTo(original.Project);
    }
}