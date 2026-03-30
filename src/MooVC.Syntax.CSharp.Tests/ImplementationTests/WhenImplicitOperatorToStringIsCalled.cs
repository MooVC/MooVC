namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "IDisposable";

    [Test]
    public async Task GivenImplementationThenStringMatchesToString()
    {
        // Arrange
        Implementation subject = new Declaration
        {
            Name = Name,
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
        Implementation? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}