namespace MooVC.Syntax.IdentifierTests;

using static MooVC.Syntax.Identifier;

public sealed class WhenToSnippetIsCalled
{
    private const string Mixed = "myValue";
    private const string MultiWord = "MyValue";

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Identifier(MultiWord);
        Options? options = default;

        // Act
        Func<string> act = () => subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenOptionsWithCamelCasingThenReturnsCamelCasedValue()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Camel);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("myValue");
    }

    [Test]
    public async Task GivenOptionsWithKebabCasingThenReturnsKebabCasedValue()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Kebab);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("my-value");
    }

    [Test]
    public async Task GivenOptionsWithPascalCasingThenReturnsPascalCasedValue()
    {
        // Arrange
        var subject = new Identifier(Mixed);

        Options options = new Options()
            .WithCasing(Casing.Pascal);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("MyValue");
    }

    [Test]
    public async Task GivenOptionsWithSnakeCasingThenReturnsSnakeCasedValue()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Snake);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("my_value");
    }

    [Test]
    public async Task GivenUnsupportedCasingThenThrows()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing((Casing)999);

        // Act
        Func<string> act = () => subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(act).Throws<NotSupportedException>();
    }
}