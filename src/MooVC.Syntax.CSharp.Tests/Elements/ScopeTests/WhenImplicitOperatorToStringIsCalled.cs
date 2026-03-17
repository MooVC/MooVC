namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "private";

    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Scope? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenScopeWithNullValueThenResultIsNull()
    {
        // Arrange
        Scope subject = (string?)null;

        // Act
        string result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Test]
    public void GivenScopeWithValueThenMatchesValue()
    {
        // Arrange
        Scope subject = Value;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Value);
    }
}