namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("add => value"),
        };

        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = subject.ToSnippet(options!)).Throws<ArgumentNullException>();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenRemoveBodyThenAddStubIsPrepended()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Remove = Snippet.From("value;"),
        };

        // Act
        string representation = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        const string expected = """
            add;
            remove => value;
            """;

        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}