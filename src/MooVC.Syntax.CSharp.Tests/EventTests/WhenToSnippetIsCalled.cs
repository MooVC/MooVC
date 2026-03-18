namespace MooVC.Syntax.CSharp.EventTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenDefaultBehavioursThenSignatureIsTerminated()
    {
        // Arrange
        Event subject = EventTestsData.Create();

        // Act
        string representation = subject.ToSnippet(Event.Options.Default);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("public event Handler Occurred;");
    }
}