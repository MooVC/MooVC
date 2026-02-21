namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Extensibility? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenExtensibilityThenStringMatchesToString()
    {
        // Arrange
        Extensibility subject = Extensibility.Static;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}