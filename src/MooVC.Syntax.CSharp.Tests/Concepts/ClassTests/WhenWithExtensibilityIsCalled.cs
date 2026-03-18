namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Extensibility).IsEqualTo(Extensibility.Abstract);
        await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        await Assert.That(original.Extensibility).IsEqualTo(Extensibility.Sealed);
    }
}