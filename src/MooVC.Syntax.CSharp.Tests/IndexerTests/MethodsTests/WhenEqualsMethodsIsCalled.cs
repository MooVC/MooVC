namespace MooVC.Syntax.CSharp.IndexerTests.MethodsTests;

public sealed class WhenEqualsMethodsIsCalled
{
    [Test]
    public async Task GivenDifferentGetValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var target = new Indexer.Methods
        {
            Get = Snippet.From("alternative"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentSetValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        var target = new Indexer.Methods
        {
            Set = Snippet.From("alternative"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var target = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var target = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Indexer.Methods? subject = default;

        var target = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        Indexer.Methods target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}