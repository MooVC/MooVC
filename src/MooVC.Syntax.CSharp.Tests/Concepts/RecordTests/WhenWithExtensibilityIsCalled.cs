namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithExtensibilityIsCalled
{
    [Test]
    public async Task GivenExtensibilityThenReturnsUpdatedInstance()
    {
        // Arrange
        Record original = RecordTestsData.Create(extensibility: Extensibility.Abstract);

        // Act
        Record result = original.WithExtensibility(Extensibility.Implicit);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Extensibility).IsEqualTo(Extensibility.Implicit);
        await Assert.That(original.Extensibility).IsEqualTo(Extensibility.Abstract);
    }
}