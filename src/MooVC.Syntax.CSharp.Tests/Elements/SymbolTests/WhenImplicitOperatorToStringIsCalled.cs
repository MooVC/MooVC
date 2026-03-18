namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "Symbol";

    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Symbol? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
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