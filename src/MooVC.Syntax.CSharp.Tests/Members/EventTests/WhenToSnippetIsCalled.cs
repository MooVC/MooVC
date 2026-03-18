namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = subject.ToSnippet(options!)).Throws<ArgumentNullException>();

        // Assert
        await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenDefaultBehavioursThenSignatureIsTerminated()
    {
        // Arrange
        Event subject = EventTestsData.Create();

        // Act
        string representation = subject.ToSnippet(Event.Options.Default);

        // Assert
        await Assert.That(representation).IsEqualTo("public event Handler Occurred;");
    }
}