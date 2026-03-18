namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter.Mode? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenModeThenStringMatchesToString()
    {
        // Arrange
        Parameter.Mode subject = Parameter.Mode.RefReadonly;

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(subject.ToString());
    }
}