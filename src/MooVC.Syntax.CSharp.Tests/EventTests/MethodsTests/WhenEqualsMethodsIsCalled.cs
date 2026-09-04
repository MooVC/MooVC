namespace MooVC.Syntax.CSharp.EventTests.MethodsTests;

public sealed class WhenEqualsMethodsIsCalled
{
    [Test]
    public async Task GivenDifferentAddValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var target = new Event.Methods
        {
            Add = Snippet.From("alternative"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentRemoveValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        var target = new Event.Methods
        {
            Remove = Snippet.From("alternative"),
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
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var target = new Event.Methods
        {
            Remove = Snippet.From("value"),
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
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var target = new Event.Methods
        {
            Add = Snippet.From("value"),
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
        Event.Methods? subject = default;

        var target = new Event.Methods
        {
            Add = Snippet.From("value"),
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
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}