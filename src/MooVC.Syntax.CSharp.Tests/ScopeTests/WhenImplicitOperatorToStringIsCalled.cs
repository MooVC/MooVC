namespace MooVC.Syntax.CSharp.ScopeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "private";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Scope? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenScopeWithNullValueThenResultIsNull()
    {
        // Arrange
        Scope subject = (string?)null;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsNull();
    }

    [Test]
    public async Task GivenScopeWithValueThenMatchesValue()
    {
        // Arrange
        Scope subject = Value;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Value);
    }
}