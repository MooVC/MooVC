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

    [Test]
    public async Task GivenNullBuilderWhenValueIsCharThenThrowsArgumentNullException()
    {
        // Arrange
        StringBuilder? builder = default;

        // Act
        Action act = () => _ = builder!.Prepend(LetterChar);

        // Assert
        await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenNullBuilderWhenValueIsStringThenThrowsArgumentNullException()
    {
        // Arrange
        StringBuilder? builder = default;

        // Act
        Action act = () => _ = builder!.Prepend(Greeting);

        // Assert
        await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenDefaultCharWhenPrependThenBuilderIsUpdated()
    {
        // Arrange
        var builder = new StringBuilder("abc");

        // Act
        StringBuilder result = builder.Prepend(DefaultChar);

        // Assert
        await Assert.That(ReferenceEquals(result, builder)).IsTrue();
        await Assert.That(builder.ToString()).IsEqualTo("\0abc");
    }

    [Test]
    public async Task GivenWhitespaceCharWhenPrependThenBuilderStartsWithWhitespace()
    {
        // Arrange
        var builder = new StringBuilder("abc");

        // Act
        StringBuilder result = builder.Prepend(SpaceChar);

        // Assert
        await Assert.That(ReferenceEquals(result, builder)).IsTrue();
        await Assert.That(builder.ToString()).IsEqualTo(" abc");
    }

    [Test]
    public async Task GivenLetterCharWhenPrependThenBuilderStartsWithThatLetter()
    {
        // Arrange
        var builder = new StringBuilder(Word);

        // Act
        StringBuilder result = builder.Prepend(LetterChar);

        // Assert
        await Assert.That(ReferenceEquals(result, builder)).IsTrue();
        await Assert.That(builder.ToString()).IsEqualTo("HWorld");
    }

    [Test]
    public async Task GivenMultipleCharsWhenPrependThenOrderIsReversed()
    {
        // Arrange
        var builder = new StringBuilder("c");

        // Act
        _ = builder.Prepend('b');
        _ = builder.Prepend('a');

        // Assert
        await Assert.That(builder.ToString()).IsEqualTo("abc");
    }

    [Test]
    public async Task GivenNullStringWhenPrependThenThrowsArgumentNullException()
    {
        // Arrange
        var builder = new StringBuilder("abc");
        string? value = default;

        // Act
        Action act = () => _ = builder.Prepend(value!);

        // Assert
        await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenEmptyStringWhenPrependThenBuilderIsUnchanged()
    {
        // Arrange
        var builder = new StringBuilder("abc");

        // Act
        StringBuilder result = builder.Prepend(EmptyString);

        // Assert
        await Assert.That(ReferenceEquals(result, builder)).IsTrue();
        await Assert.That(builder.ToString()).IsEqualTo("abc");
    }

    [Test]
    public async Task GivenWhitespaceStringWhenPrependThenBuilderStartsWithWhitespace()
    {
        // Arrange
        var builder = new StringBuilder("abc");

        // Act
        StringBuilder result = builder.Prepend(SpaceString);

        // Assert
        await Assert.That(ReferenceEquals(result, builder)).IsTrue();
        await Assert.That(builder.ToString()).IsEqualTo("   abc");
    }

    [Test]
    public async Task GivenStringWhenPrependThenValueAppearsAtStart()
    {
        // Arrange
        var builder = new StringBuilder(Word);

        // Act
        StringBuilder result = builder.Prepend(Greeting);

        // Assert
        await Assert.That(ReferenceEquals(result, builder)).IsTrue();
        await Assert.That(builder.ToString()).IsEqualTo("HelloWorld");
    }

    [Test]
    public async Task GivenMultipleStringsWhenPrependThenOrderIsReversed()
    {
        // Arrange
        var builder = new StringBuilder("c");

        // Act
        _ = builder.Prepend("b");
        _ = builder.Prepend("a");

        // Assert
        await Assert.That(builder.ToString()).IsEqualTo("abc");
    }

    [Test]
    public async Task GivenRandomStringsWhenPrependThenConcatenationMatches()
    {
        // Arrange
        var faker = new Faker();
        string head = faker.Random.String2(10);
        string tail = faker.Random.String2(8);
        var builder = new StringBuilder(tail);

        // Act
        StringBuilder result = builder.Prepend(head);

        // Assert
        await Assert.That(ReferenceEquals(result, builder)).IsTrue();
        await Assert.That(builder.ToString()).IsEqualTo(head + tail);
    }
}