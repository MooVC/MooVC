namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "private";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Scope? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenScopeWithNullValueThenResultIsNull()
    {
        // Arrange
        Scope subject = (string?)null;

        // Act
        string result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
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