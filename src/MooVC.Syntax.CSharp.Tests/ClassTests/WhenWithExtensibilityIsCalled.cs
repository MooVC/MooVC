namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenWithExtensibilityIsCalled
{
    [Test]
    public async Task GivenExtensibilityThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(extensibility: Modifiers.Sealed);

        // Act
        Class result = original.WithExtensibility(Modifiers.Abstract);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Extensibility).IsEqualTo(Modifiers.Abstract);
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        _ = await Assert.That(original.Extensibility).IsEqualTo(Modifiers.Sealed);
    }
}