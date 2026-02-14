namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "TParameter";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenParameterThenMatchesToString()
    {
        // Arrange
        var subject = new Parameter
        {
            Name = new Identifier(Name),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}