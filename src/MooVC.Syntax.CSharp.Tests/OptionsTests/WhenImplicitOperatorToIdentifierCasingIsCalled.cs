namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToIdentifierCasingIsCalled
{
    [Test]
    public async Task GivenOptionsThenParameterNamingIsUsed()
    {
        // Arrange
        Options subject = Options.Default;

        // Act
        Identifier.Casing result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Identifier.Casing.Camel);
    }

    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Identifier.Casing> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }
}