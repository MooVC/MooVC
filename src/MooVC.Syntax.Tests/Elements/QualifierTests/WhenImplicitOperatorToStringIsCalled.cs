namespace MooVC.Syntax.Elements.QualifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string First = "System";
    private const string Second = "Collections";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenQualifierThenStringMatchesToString()
    {
        // Arrange
        Qualifier subject = new Name[] { First, Second };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}