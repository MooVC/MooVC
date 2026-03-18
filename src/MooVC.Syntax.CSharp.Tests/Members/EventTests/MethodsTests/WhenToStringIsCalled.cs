namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenDefaultInstanceThenReturnsEmpty()
    {
        // Arrange
        Event.Methods subject = Event.Methods.Default;

        // Act
        string representation = subject.ToString();

        // Assert
        await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenAutoImplementedMembersThenReturnsEmpty()
    {
        // Arrange
        var subject = new Event.Methods();

        // Act
        string representation = subject.ToString();

        // Assert
        await Assert.That(representation).IsEmpty();
    }

    [Test]
    public async Task GivenExpressionBodiesThenReturnsExpressions()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("value;"),
        };

        // Act
        string representation = subject.ToString();

        // Assert
        const string expected = """
            add => value;
            remove;
            """;

        await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenMultiLineBodyThenReturnsBlock()
    {
        // Arrange
        var add = Snippet.From($"first{Environment.NewLine}second");

        var subject = new Event.Methods
        {
            Add = add,
        };

        // Act
        string representation = subject.ToString();

        // Assert
        const string expected = """
            add
            {
                first
                second
            }
            remove;
            """;

        await Assert.That(representation).IsEqualTo(expected);
    }
}