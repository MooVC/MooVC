namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Casing).IsEqualTo(original.Casing);
        await Assert.That(result.UseUnderscore).IsTrue();
        await Assert.That(original.UseUnderscore).IsFalse();
    }
}