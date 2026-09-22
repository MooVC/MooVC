namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToVariableOptionsIsCalled
{
    [Test]
    public async Task GivenOptionsThenParameterNamingIsUsed()
    {
        // Arrange
        Options subject = Options.Default;

        // Act
        Variable.Options result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Variable.Options.Camel);
    }

    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Variable.Options> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }
}