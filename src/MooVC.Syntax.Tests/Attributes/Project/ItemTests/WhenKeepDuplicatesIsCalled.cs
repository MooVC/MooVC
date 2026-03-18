namespace MooVC.Syntax.Attributes.Project.ItemTests;

public sealed class WhenKeepDuplicatesIsCalled
{
    [Test]
    public async Task GivenKeepDuplicatesThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        const bool updated = true;

        // Act
        Item result = original.KeepDuplicates(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.KeepDuplicates).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}