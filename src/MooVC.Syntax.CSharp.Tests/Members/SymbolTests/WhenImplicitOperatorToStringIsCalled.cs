namespace MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "Symbol";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Symbol? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenSymbolThenStringMatchesToString()
    {
        // Arrange
        var subject = new Symbol
        {
            Name = Value,
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}