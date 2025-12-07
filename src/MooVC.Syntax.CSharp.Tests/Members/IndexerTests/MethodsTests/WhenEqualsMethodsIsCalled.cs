namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

public sealed class WhenEqualsMethodsIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
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
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
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
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentValueThenReturnsTrue()
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
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
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
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentGetValuesThenReturnsFalse()
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
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentSetValuesThenReturnsFalse()
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
        result.ShouldBeFalse();
    }
}
