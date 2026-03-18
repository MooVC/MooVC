namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorMethodsMethodsIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property.Methods? left = default!;
        Property.Methods? right = default!;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Property.Methods? left = default!;
        var right = new Property.Methods
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
        var left = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        Property.Methods? right = default!;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        Property.Methods second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        var right = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
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
        var left = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        var right = new Property.Methods
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
}