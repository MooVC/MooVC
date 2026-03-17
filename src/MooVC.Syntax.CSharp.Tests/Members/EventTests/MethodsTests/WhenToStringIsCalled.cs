namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenDefaultInstanceThenReturnsEmpty()
    {
        // Arrange
        Event.Methods subject = Event.Methods.Default;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenAutoImplementedMembersThenReturnsEmpty()
    {
        // Arrange
        var subject = new Event.Methods();

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBeEmpty();
    }

    [Test]
    public void GivenExpressionBodiesThenReturnsExpressions()
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

        representation.ShouldBe(expected);
    }

    [Test]
    public void GivenMultiLineBodyThenReturnsBlock()
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

        representation.ShouldBe(expected);
    }
}