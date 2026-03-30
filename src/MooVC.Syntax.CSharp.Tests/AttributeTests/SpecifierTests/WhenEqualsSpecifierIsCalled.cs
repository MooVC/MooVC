namespace MooVC.Syntax.CSharp.AttributeTests.SpecifierTests;

public sealed class WhenEqualsSpecifierIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Method;
        Attribute.Specifier right = Attribute.Specifier.Event;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Method;
        Attribute.Specifier right = Attribute.Specifier.Method;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Method;
        Attribute.Specifier? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Method;
        Attribute.Specifier other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}