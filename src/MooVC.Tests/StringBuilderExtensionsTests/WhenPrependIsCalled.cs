namespace MooVC.StringBuilderExtensionsTests;

using System.Text;

public sealed class WhenPrependIsCalled
{
    private const char DefaultChar = default;
    private const char SpaceChar = ' ';
    private const char LetterChar = 'H';
    private const string EmptyString = "";
    private const string SpaceString = "   ";
    private const string Word = "World";
    private const string Greeting = "Hello";

    [Fact]
    public void GivenNullBuilderWhenValueIsCharThenThrowsArgumentNullException()
    {
        // Arrange
        StringBuilder? builder = default;

        // Act
        Action act = () => _ = builder!.Prepend(LetterChar);

        // Assert
        _ = Should.Throw<ArgumentNullException>(act);
    }

    [Fact]
    public void GivenNullBuilderWhenValueIsStringThenThrowsArgumentNullException()
    {
        // Arrange
        StringBuilder? builder = default;

        // Act
        Action act = () => _ = builder!.Prepend(Greeting);

        // Assert
        _ = Should.Throw<ArgumentNullException>(act);
    }

    [Fact]
    public void GivenDefaultCharWhenPrependThenBuilderIsUpdated()
    {
        // Arrange
        var builder = new StringBuilder("abc");

        // Act
        StringBuilder result = builder.Prepend(DefaultChar);

        // Assert
        ReferenceEquals(result, builder).ShouldBeTrue();
        builder.ToString().ShouldBe("\0abc");
    }

    [Fact]
    public void GivenWhitespaceCharWhenPrependThenBuilderStartsWithWhitespace()
    {
        // Arrange
        var builder = new StringBuilder("abc");

        // Act
        StringBuilder result = builder.Prepend(SpaceChar);

        // Assert
        ReferenceEquals(result, builder).ShouldBeTrue();
        builder.ToString().ShouldBe(" abc");
    }

    [Fact]
    public void GivenLetterCharWhenPrependThenBuilderStartsWithThatLetter()
    {
        // Arrange
        var builder = new StringBuilder(Word);

        // Act
        StringBuilder result = builder.Prepend(LetterChar);

        // Assert
        ReferenceEquals(result, builder).ShouldBeTrue();
        builder.ToString().ShouldBe("HWorld");
    }

    [Fact]
    public void GivenMultipleCharsWhenPrependThenOrderIsReversed()
    {
        // Arrange
        var builder = new StringBuilder("c");

        // Act
        _ = builder.Prepend('b');
        _ = builder.Prepend('a');

        // Assert
        builder.ToString().ShouldBe("abc");
    }

    [Fact]
    public void GivenNullStringWhenPrependThenThrowsArgumentNullException()
    {
        // Arrange
        var builder = new StringBuilder("abc");
        string? value = default;

        // Act
        Action act = () => _ = builder.Prepend(value!);

        // Assert
        _ = Should.Throw<ArgumentNullException>(act);
    }

    [Fact]
    public void GivenEmptyStringWhenPrependThenBuilderIsUnchanged()
    {
        // Arrange
        var builder = new StringBuilder("abc");

        // Act
        StringBuilder result = builder.Prepend(EmptyString);

        // Assert
        ReferenceEquals(result, builder).ShouldBeTrue();
        builder.ToString().ShouldBe("abc");
    }

    [Fact]
    public void GivenWhitespaceStringWhenPrependThenBuilderStartsWithWhitespace()
    {
        // Arrange
        var builder = new StringBuilder("abc");

        // Act
        StringBuilder result = builder.Prepend(SpaceString);

        // Assert
        ReferenceEquals(result, builder).ShouldBeTrue();
        builder.ToString().ShouldBe("   abc");
    }

    [Fact]
    public void GivenStringWhenPrependThenValueAppearsAtStart()
    {
        // Arrange
        var builder = new StringBuilder(Word);

        // Act
        StringBuilder result = builder.Prepend(Greeting);

        // Assert
        ReferenceEquals(result, builder).ShouldBeTrue();
        builder.ToString().ShouldBe("HelloWorld");
    }

    [Fact]
    public void GivenMultipleStringsWhenPrependThenOrderIsReversed()
    {
        // Arrange
        var builder = new StringBuilder("c");

        // Act
        _ = builder.Prepend("b");
        _ = builder.Prepend("a");

        // Assert
        builder.ToString().ShouldBe("abc");
    }

    [Fact]
    public void GivenRandomStringsWhenPrependThenConcatenationMatches()
    {
        // Arrange
        var faker = new Faker();
        string head = faker.Random.String2(10);
        string tail = faker.Random.String2(8);
        var builder = new StringBuilder(tail);

        // Act
        StringBuilder result = builder.Prepend(head);

        // Assert
        ReferenceEquals(result, builder).ShouldBeTrue();
        builder.ToString().ShouldBe(head + tail);
    }
}