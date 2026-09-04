namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Implementation original = ImplementationTestsData.Create(name: (Qualification)"IComparable");
        var updated = (Qualification)"IDisposable";

        // Act
        Implementation result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
    }
}