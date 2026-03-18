namespace MooVC.Syntax.CSharp.AttributeTests.SpecifierTests;

public sealed class WhenEqualityOperatorSpecifierSpecifierIsCalled
{
    private const string Alternative = "property";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier? left = default;
        Attribute.Specifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier? left = default;
        Attribute.Specifier right = Attribute.Specifier.Method;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Method;
        Attribute.Specifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier first = Attribute.Specifier.Method;
        Attribute.Specifier second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Method;
        Attribute.Specifier right = Attribute.Specifier.Method;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Method;
        Attribute.Specifier right = Alternative;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}