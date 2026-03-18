namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Extensibility).IsEqualTo(Extensibility.Implicit);
        _ = await Assert.That(original.Extensibility).IsEqualTo(Extensibility.Abstract);
    }
}