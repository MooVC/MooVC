namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Base original = BaseTestsData.Create(name: (Qualification)"Comparable");
        var updated = (Qualification)"IComparable";

        // Act
        Base result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
    }
}