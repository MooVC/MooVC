namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenDefaultBehavioursThenSignatureIsTerminated()
    {
        // Arrange
        Event subject = EventTestsData.Create();

        // Act
        string representation = subject.ToSnippet(Event.Options.Default);

        // Assert
        representation.ShouldBe("public event Handler Occurred;");
    }
}