namespace MooVC.Syntax.StringExtensionsTests;

public sealed class WhenToSnippetIsCalled
{
    private const int MultiLineCount = 3;
    private const int SingleLineCount = 1;
    private const string FirstLine = "First";
    private const string SecondLine = "Second";
    private const string ThirdLine = "Third";
    private const string WhitespaceLine = " ";

    [Test]
    public async Task GivenDefaultOptionsThenSnippetIsReturned()
    {
        // Arrange
        string[] lines = [FirstLine, SecondLine];
        string expected = string.Join(Environment.NewLine, FirstLine, SecondLine);

        // Act
        var result = lines.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result.Lines).IsEqualTo(2);
        _ = await Assert.That(result.ToString()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenLineContainsNewLineThenLineIsSplit()
    {
        // Arrange
        string line = string.Join(Environment.NewLine, FirstLine, SecondLine);
        string[] lines = [line, ThirdLine];
        string expected = string.Join(Environment.NewLine, FirstLine, SecondLine, ThirdLine);

        // Act
        var result = lines.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result.Lines).IsEqualTo(MultiLineCount);
        _ = await Assert.That(result.ToString()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenLinesContainEmptyLineThenEmptyLineIsPreserved()
    {
        // Arrange
        string[] lines = [FirstLine, string.Empty, SecondLine];
        string expected = string.Join(Environment.NewLine, FirstLine, string.Empty, SecondLine);

        // Act
        var result = lines.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result.Lines).IsEqualTo(MultiLineCount);
        _ = await Assert.That(result.ToString()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNoLinesThenEmptySnippetIsReturned()
    {
        // Arrange
        string[] lines = [];

        // Act
        var result = lines.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(result.IsEmpty).IsTrue();
    }

    [Test]
    public async Task GivenNoOptionsThenDefaultOptionsAreUsed()
    {
        // Arrange
        string[] lines = [FirstLine, SecondLine];
        var expected = lines.ToSnippet(Snippet.Options.Default);

        // Act
        var result = lines.ToSnippet();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNullLinesThenAnExceptionIsThrown()
    {
        // Arrange
        IEnumerable<string>? lines = default;

        // Act
        Func<Snippet> act = () => _ = lines!.ToSnippet();

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(lines));
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        string[] lines = [FirstLine];
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = lines.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenOnlyEmptyLineThenEmptySnippetIsReturned()
    {
        // Arrange
        string[] lines = [string.Empty];

        // Act
        var result = lines.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(result.IsEmpty).IsTrue();
    }

    [Test]
    public async Task GivenOnlyNewLineThenBlankSnippetIsReturned()
    {
        // Arrange
        string[] lines = [Environment.NewLine];

        // Act
        var result = lines.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Blank);
        _ = await Assert.That(result.IsEmpty).IsFalse();
        _ = await Assert.That(result.ToString()).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenSingleLineThenSingleLineSnippetIsReturned()
    {
        // Arrange
        string[] lines = [FirstLine];

        // Act
        var result = lines.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result.IsSingleLine).IsTrue();
        _ = await Assert.That(result.Lines).IsEqualTo(SingleLineCount);
        _ = await Assert.That(result.ToString()).IsEqualTo(FirstLine);
    }

    [Test]
    public async Task GivenWhitespaceLineThenWhitespaceIsPreserved()
    {
        // Arrange
        string[] lines = [WhitespaceLine];

        // Act
        var result = lines.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result.IsSingleLine).IsTrue();
        _ = await Assert.That(result.ToString()).IsEqualTo(WhitespaceLine);
    }
}
