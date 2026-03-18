namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithCasingIsCalled
{
    [Test]
    public async Task GivenCasingThenReturnsNewInstanceWithUpdatedCasing()
    {
        // Arrange
        var original = new Variable.Options();

        // Act
        Variable.Options result = original.WithCasing(Identifier.Casing.Pascal);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Casing).IsEqualTo(Identifier.Casing.Pascal);
        await Assert.That(result.UseUnderscore).IsEqualTo(original.UseUnderscore);
        await Assert.That(original.Casing).IsEqualTo(Identifier.Casing.Camel);
    }
}