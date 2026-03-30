namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "BaseClass";

    [Test]
    public async Task GivenBaseThenStringMatchesToString()
    {
        // Arrange
        Base subject = new Symbol
        {
            Name = Value,
        };

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Base? @base = default;

        // Act
        Func<string> result = () => @base;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}