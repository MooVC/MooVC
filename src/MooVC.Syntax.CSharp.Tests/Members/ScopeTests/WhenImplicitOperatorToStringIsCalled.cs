namespace MooVC.Syntax.CSharp.Members.ScopeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "private";

    [Fact]
    public void GivenNullSubjectThenEmptyStringReturned()
    {
        // Arrange
        Scope? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
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