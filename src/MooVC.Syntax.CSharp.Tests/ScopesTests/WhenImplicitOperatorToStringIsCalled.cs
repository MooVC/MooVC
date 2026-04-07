namespace MooVC.Syntax.CSharp.ScopesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "private";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Scopes? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenScopeWithNullValueThenResultIsNull()
    {
        // Arrange
        Scopes subject = (string?)null;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsNull();
    }

    [Test]
    public async Task GivenScopeWithValueThenMatchesValue()
    {
        // Arrange
        Scopes subject = Value;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Value);
    }
}