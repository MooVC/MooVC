namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.Elements;

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
            Name = Name,
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}