namespace MooVC.Syntax.CSharp.Members.IdentifierTests;

using MooVC.Syntax.CSharp;
using static MooVC.Syntax.CSharp.Members.Identifier;

public sealed class WhenToSnippetIsCalled
{
    private const string Mixed = "myValue";
    private const string MultiWord = "MyValue";

    [Fact]
    public void GivenOptionsWithPascalCasingThenReturnsPascalCasedValue()
    {
        // Arrange
        var subject = new Identifier(Mixed);

        Options options = new Options()
            .WithCasing(Casing.Pascal);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("MyValue");
    }

    [Fact]
    public void GivenOptionsWithCamelCasingThenReturnsCamelCasedValue()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Camel);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("myValue");
    }

    [Fact]
    public void GivenOptionsWithSnakeCasingThenReturnsSnakeCasedValue()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Snake);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("my_value");
    }

    [Fact]
    public void GivenOptionsWithKebabCasingThenReturnsKebabCasedValue()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Kebab);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("my-value");
    }

    [Fact]
    public void GivenOptionsWithUnderscoreThenResultIsPrefixed()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Camel)
            .UseUnderscores(true);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("_myValue");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GivenOptionsWithoutUnderscoreWhenReservedThenResultIsPrefixed(Casing casing)
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);
        string keyword = Keywords.Reserved.ElementAt(element);
        var subject = new Identifier(keyword);
        string expected = keyword.ToCamelCase();

        Options options = new Options()
            .WithCasing(casing)
            .UseUnderscores(false);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe($"@{expected}");
    }

    [Fact]
    public void GivenUnsupportedCasingThenThrows()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        Options options = new Options()
            .WithCasing((Casing)999);

        // Act
        Func<string> act = () => subject.ToSnippet(options);

        // Assert
        _ = Should.Throw<NotSupportedException>(act);
    }

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Identifier(MultiWord);
        Options? options = default;

        // Act
        Func<string> act = () => subject.ToSnippet(options);

        // Assert
        _ = Should.Throw<ArgumentNullException>(act);
    }
}