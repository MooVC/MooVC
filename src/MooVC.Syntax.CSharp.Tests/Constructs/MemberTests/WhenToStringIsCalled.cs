namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

using static MooVC.Syntax.CSharp.Constructs.Member;

public sealed class WhenToStringIsCalled
{
    private const string Mixed = "myValue";
    private const string MultiWord = "MyValue";

    [Fact]
    public void GivenDefaultOptionsWhenCalledThenUsesCamelCase()
    {
        // Arrange
        var subject = new Member(MultiWord);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe("myValue");
    }

    [Fact]
    public void GivenOptionsWithPascalCasingWhenCalledThenReturnsPascalCasedValue()
    {
        // Arrange
        var subject = new Member(Mixed);

        Options options = new Options()
            .WithCasing(Casing.Pascal);

        // Act
        string result = subject.ToString(options);

        // Assert
        result.ShouldBe("MyValue");
    }

    [Fact]
    public void GivenOptionsWithCamelCasingWhenCalledThenReturnsCamelCasedValue()
    {
        // Arrange
        var subject = new Member(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Camel);

        // Act
        string result = subject.ToString(options);

        // Assert
        result.ShouldBe("myValue");
    }

    [Fact]
    public void GivenOptionsWithSnakeCasingWhenCalledThenReturnsSnakeCasedValue()
    {
        // Arrange
        var subject = new Member(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Snake);

        // Act
        string result = subject.ToString(options);

        // Assert
        result.ShouldBe("my_value");
    }

    [Fact]
    public void GivenOptionsWithKebabCasingWhenCalledThenReturnsKebabCasedValue()
    {
        // Arrange
        var subject = new Member(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Kebab);

        // Act
        string result = subject.ToString(options);

        // Assert
        result.ShouldBe("my-value");
    }

    [Fact]
    public void GivenOptionsWithUnderscoreWhenCalledThenResultIsPrefixed()
    {
        // Arrange
        var subject = new Member(MultiWord);

        Options options = new Options()
            .WithCasing(Casing.Camel)
            .UseUnderscores(true);

        // Act
        string result = subject.ToString(options);

        // Assert
        result.ShouldBe("_myValue");
    }

    [Fact]
    public void GivenUnsupportedCasingWhenCalledThenThrows()
    {
        // Arrange
        var subject = new Member(MultiWord);

        Options options = new Options()
            .WithCasing((Casing)999);

        // Act
        Func<string> act = () => subject.ToString(options);

        // Assert
        _ = Should.Throw<NotSupportedException>(act);
    }

    [Fact]
    public void GivenNullOptionsWhenCalledThenThrows()
    {
        // Arrange
        var subject = new Member(MultiWord);
        Options? options = default;

        // Act
        Func<string> act = () => subject.ToString(options);

        // Assert
        _ = Should.Throw<ArgumentNullException>(act);
    }

    [Fact]
    public void GivenDifferentValuesWhenCalledThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Member("MyName");
        var right = new Member("MyOtherName");

        // Act
        string leftString = left.ToString();
        string rightString = right.ToString();

        // Assert
        leftString.ShouldNotBe(rightString);
    }

    [Fact]
    public void GivenRepeatedCallsWhenCalledThenResultIsStable()
    {
        // Arrange
        var subject = new Member(MultiWord);

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        first.ShouldBe(second);
    }
}