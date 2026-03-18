namespace MooVC.Syntax.CSharp.Generics.ArgumentTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "TArgument";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Generic? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenArgumentThenMatchesToString()
    {
        // Arrange
        var subject = new Generic
        {
            Name = new Name(Name),
        };

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}