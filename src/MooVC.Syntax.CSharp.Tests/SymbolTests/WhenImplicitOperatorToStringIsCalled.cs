namespace MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "Symbol";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Symbol? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenSymbolThenStringMatchesToString()
    {
        // Arrange
        var subject = new Symbol
        {
            Name = Value,
        };

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}