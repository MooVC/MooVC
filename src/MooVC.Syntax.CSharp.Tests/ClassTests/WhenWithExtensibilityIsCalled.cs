namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenWithExtensibilityIsCalled
{
    [Test]
    public async Task GivenExtensibilityThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(extensibility: Extensibility.Sealed);

        // Act
        Class result = original.WithExtensibility(Extensibility.Abstract);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Extensibility).IsEqualTo(Extensibility.Abstract);
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        _ = await Assert.That(original.Extensibility).IsEqualTo(Extensibility.Sealed);
    }
}