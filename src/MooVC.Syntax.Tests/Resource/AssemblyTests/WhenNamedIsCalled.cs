namespace MooVC.Syntax.Resource.AssemblyTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Assembly original = AssemblyTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Assembly result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.Alias).IsEqualTo(original.Alias);
    }
}