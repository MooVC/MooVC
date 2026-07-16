namespace MooVC.Syntax.CSharp.VariableTests.OptionsTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Casing).IsEqualTo(Identifier.Casing.Pascal);
        _ = await Assert.That(result.UseUnderscore).IsEqualTo(original.UseUnderscore);
        _ = await Assert.That(original.Casing).IsEqualTo(Identifier.Casing.Camel);
    }
}