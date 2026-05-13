namespace MooVC.Syntax.CSharp.VariableTests;

using MooVC.Syntax.Formatting;
using Casing = MooVC.Syntax.Identifier.Casing;
using Options = MooVC.Syntax.CSharp.Variable.Options;

public sealed class WhenToSnippetIsCalled
{
    private const string Mixed = "myValue";
    private const string MultiWord = "MyValue";

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Variable(MultiWord);
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
        var subject = new Variable(MultiWord);

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
        var subject = new Variable(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Kebab);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("my-value");
    }

    [Test]
    [Arguments("Camel")]
    [Arguments("Kebab")]
    [Arguments("Snake")]
    public async Task GivenOptionsWithoutUnderscoreWhenReservedThenResultIsPrefixed(string casing)
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);
        string keyword = Keywords.Reserved.ElementAt(element);
        var subject = new Variable(keyword);
        string expected = keyword.ToCamelCase();

        Options options = new Options()
            .WithCasing(casing)
            .UseUnderscore(false);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo($"@{expected}");
    }

    [Test]
    public async Task GivenOptionsWithPascalCasingThenReturnsPascalCasedValue()
    {
        // Arrange
        var subject = new Variable(Mixed);

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
        var subject = new Variable(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Snake);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("my_value");
    }

    [Test]
    public async Task GivenOptionsWithUnderscoreThenResultIsPrefixed()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Camel)
            .UseUnderscore(true);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("_myValue");
    }
}