namespace MooVC.Syntax.Attributes.Project.ItemTests;

public sealed class WhenKeepDuplicatesIsCalled
{
    [Test]
    public async Task GivenKeepDuplicatesThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();

        // Act
        Item result = original.KeepDuplicates(true);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.KeepDuplicates).IsTrue();
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}