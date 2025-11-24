namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "TParameter";

    [Fact]
    public void GivenNullSubjectThenReturnsEmpty()
    {
        // Arrange
        Parameter? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
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
