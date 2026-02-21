namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter.Mode? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenModeThenStringMatchesToString()
    {
        // Arrange
        Parameter.Mode subject = Parameter.Mode.RefReadonly;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}