namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = "add => value",
        };

        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenRemoveBodyThenAddStubIsPrepended()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Remove = "value;",
        };

        // Act
        string representation = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        const string expected = """
            add;
            remove => value;
            """;

        representation.ShouldBe(expected);
    }
}