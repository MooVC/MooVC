namespace MooVC.Syntax.CSharp.VariableTests.OptionsTests;

public sealed class WhenUseUnderscoreIsCalled
{
    [Test]
    public async Task GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        var original = new Variable.Options();

        // Act
        Variable.Options result = original.UseUnderscore(true);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Casing).IsEqualTo(original.Casing);
        _ = await Assert.That(result.UseUnderscore).IsTrue();
        _ = await Assert.That(original.UseUnderscore).IsFalse();
    }
}