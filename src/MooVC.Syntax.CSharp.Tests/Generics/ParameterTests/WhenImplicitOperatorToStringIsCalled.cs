namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "TParameter";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenParameterThenMatchesToString()
    {
        // Arrange
        var subject = new Parameter
        {
            Name = new Name(Name),
        };

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(subject.ToString());
    }
}