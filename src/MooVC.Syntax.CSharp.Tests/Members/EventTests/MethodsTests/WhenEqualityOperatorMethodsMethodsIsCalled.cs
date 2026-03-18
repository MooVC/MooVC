namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorMethodsMethodsIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Event.Methods? left = default;
        Event.Methods? right = default;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Event.Methods? left = default;

        var right = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods? right = default!;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods second = first;

        // Act
        bool result = first == second;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        await Assert.That(resultLeftRight).IsTrue();
        await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        await Assert.That(resultLeftRight).IsFalse();
        await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenDifferentAddValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Add = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        await Assert.That(resultLeftRight).IsFalse();
        await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenDifferentRemoveValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Remove = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        await Assert.That(resultLeftRight).IsFalse();
        await Assert.That(resultRightLeft).IsFalse();
    }
}