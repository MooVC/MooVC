namespace MooVC.Syntax.CSharp.Elements.VariableTests;

using MooVC.Syntax.Formatting;
using Casing = MooVC.Syntax.Elements.Identifier.Casing;
using Options = MooVC.Syntax.CSharp.Elements.Variable.Options;

public sealed class WhenToSnippetIsCalled
{
    private const string Mixed = "myValue";
    private const string MultiWord = "MyValue";

    [Test]
    public void GivenOptionsWithPascalCasingThenReturnsPascalCasedValue()
    {
        // Arrange
        var subject = new Variable(Mixed);

        Options options = new Options()
            .WithCasing(Casing.Pascal);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("MyValue");
    }

    [Test]
    public void GivenOptionsWithCamelCasingThenReturnsCamelCasedValue()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Camel);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("myValue");
    }

    [Test]
    public void GivenOptionsWithSnakeCasingThenReturnsSnakeCasedValue()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Snake);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("my_value");
    }

    [Test]
    public void GivenOptionsWithKebabCasingThenReturnsKebabCasedValue()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Kebab);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("my-value");
    }

    [Test]
    public void GivenOptionsWithUnderscoreThenResultIsPrefixed()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Camel)
            .UseUnderscore(true);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("_myValue");
    }

    [Test]
    [Arguments(1)]
    [Arguments(2)]
    [Arguments(3)]
    public void GivenOptionsWithoutUnderscoreWhenReservedThenResultIsPrefixed(int casing)
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
        result.ShouldBe($"@{expected}");
    }

    [Test]
    public void GivenUnsupportedCasingThenThrows()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        Options options = new Options()
            .WithCasing((Casing)999);

        // Act
        Func<string> act = () => subject.ToSnippet(options);

        // Assert
        _ = Should.Throw<NotSupportedException>(act);
    }

    [Test]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Variable(MultiWord);
        Options? options = default;

        // Act
        Func<string> act = () => subject.ToSnippet(options);

        // Assert
        _ = Should.Throw<ArgumentNullException>(act);
    }
}