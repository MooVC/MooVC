namespace MooVC.Syntax.CSharp.EventTests.MethodsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        object target = new();

        // Act
        bool result = subject.Equals(target);

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

        object target = new Event.Methods
        {
            Add = Snippet.From("alternative"),
        };

        // Act
        bool result = subject.Equals(target);

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

        object target = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        object? target = default;

        // Act
        bool result = subject.Equals(target);

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

        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}