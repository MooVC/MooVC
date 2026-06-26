namespace MooVC.Syntax.Resource.AssemblyTests;

public sealed class WhenKnownAsIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Assembly original = AssemblyTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Assembly result = original.KnownAs(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Alias).IsEqualTo(updated);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}