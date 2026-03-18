namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithExtensibilityIsCalled
{
    [Test]
    public async Task GivenExtensibilityThenReturnsNewInstanceWithUpdatedExtensibility()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();

        // Act
        Constructor result = original.WithExtensibility(Extensibility.Static);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Extensibility).IsEqualTo(Extensibility.Static);
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);

        await Assert.That(original.Extensibility).IsEqualTo(Extensibility.Implicit);
    }
}