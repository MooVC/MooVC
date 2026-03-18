namespace MooVC.Syntax.CSharp.EventTests.MethodsTests;

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
        Func<Snippet> act = () => _ = subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
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