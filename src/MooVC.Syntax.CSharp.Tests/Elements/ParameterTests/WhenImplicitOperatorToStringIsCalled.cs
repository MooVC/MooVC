namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = ParameterTestsData.DefaultName;

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
    public void GivenParameterThenStringMatchesToString()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create(name: Name);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}