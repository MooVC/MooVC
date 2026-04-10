namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenEqualityOperatorSpecifierSpecifierIsCalled
{
    private const string Alternative = "property";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers? left = default;
        Attribute.Specifiers? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Method;
        Attribute.Specifiers right = Alternative;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Method;
        Attribute.Specifiers right = Attribute.Specifiers.Method;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers? left = default;
        Attribute.Specifiers right = Attribute.Specifiers.Method;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Method;
        Attribute.Specifiers? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers first = Attribute.Specifiers.Method;
        Attribute.Specifiers second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}