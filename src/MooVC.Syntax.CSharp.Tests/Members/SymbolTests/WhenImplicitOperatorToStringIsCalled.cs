namespace MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "Symbol";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Symbol? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenSymbolThenStringMatchesToString()
    {
        // Arrange
        var subject = new Symbol(Value);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
