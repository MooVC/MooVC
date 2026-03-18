namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenToStringIsCalled
{
    private const string Value = "TResult";

    [Test]
    public async Task GivenNamedIdentifierThenReturnsValue()
    {
        // Arrange
        var subject = new Identifier(Value);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenUnnamedIdentifierThenReturnsEmpty()
    {
        // Arrange
        Identifier subject = Identifier.Unnamed;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }
}