namespace MooVC.Syntax.CSharp.ConstructorTests;

public sealed class WhenWithExtensibilityIsCalled
{
    [Test]
    public async Task GivenExtensibilityThenReturnsNewInstanceWithUpdatedExtensibility()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();

        // Act
        Constructor result = original.WithExtensibility(Modifiers.Static);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Extensibility).IsEqualTo(Modifiers.Static);
        _ = await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);

        _ = await Assert.That(original.Extensibility).IsEqualTo(Modifiers.Implicit);
    }
}