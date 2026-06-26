namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenInequalityOperatorSpecifierSpecifierIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers? left = default;
        Attribute.Specifiers? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Method;
        Attribute.Specifiers right = Attribute.Specifiers.Class;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Method;
        Attribute.Specifiers right = Attribute.Specifiers.Method;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers? left = default;
        Attribute.Specifiers right = Attribute.Specifiers.Method;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Method;
        Attribute.Specifiers? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}