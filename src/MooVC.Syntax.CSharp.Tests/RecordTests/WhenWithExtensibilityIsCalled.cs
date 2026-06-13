namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenWithExtensibilityIsCalled
{
    [Test]
    public async Task GivenExtensibilityThenReturnsUpdatedInstance()
    {
        // Arrange
        Record original = RecordTestsData.Create(extensibility: Modifiers.Abstract);

        // Act
        Record result = original.WithExtensibility(Modifiers.Implicit);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Extensibility).IsEqualTo(Modifiers.Implicit);
        _ = await Assert.That(original.Extensibility).IsEqualTo(Modifiers.Abstract);
    }
}