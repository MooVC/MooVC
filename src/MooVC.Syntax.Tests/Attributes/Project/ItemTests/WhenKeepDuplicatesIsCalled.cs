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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.KeepDuplicates).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}