namespace MooVC.Syntax.CSharp.IndexerTests.MethodsTests;

public sealed class WhenInequalityOperatorMethodsMethodsIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Indexer.Methods? left = default;
        Indexer.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Indexer.Methods? left = default;

        var right = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        Indexer.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        Indexer.Methods second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var right = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var right = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentGetValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var right = new Indexer.Methods
        {
            Get = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentSetValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        var right = new Indexer.Methods
        {
            Set = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}