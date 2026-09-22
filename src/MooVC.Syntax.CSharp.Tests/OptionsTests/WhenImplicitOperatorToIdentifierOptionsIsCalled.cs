namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToIdentifierOptionsIsCalled
{
    [Test]
    public async Task GivenOptionsThenParameterNamingIsUsed()
    {
        // Arrange
        Options subject = Options.Default;

        // Act
        Identifier.Options result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Identifier.Options.Camel);
    }

    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Identifier.Options> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }
}