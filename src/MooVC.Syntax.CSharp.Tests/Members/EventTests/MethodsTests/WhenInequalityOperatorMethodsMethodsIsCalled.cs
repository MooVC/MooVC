namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorMethodsMethodsIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Event.Methods? left = default;
        Event.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Event.Methods? left = default;

        var right = new Event.Methods
        {
            Add = Snippet.From("value"),
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
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
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
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentAddValuesThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentRemoveValuesThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}