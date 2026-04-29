namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenEqualsSpecifierIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Method;
        Attribute.Specifiers right = Attribute.Specifiers.Event;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Method;
        Attribute.Specifiers right = Attribute.Specifiers.Method;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers subject = Attribute.Specifiers.Method;
        Attribute.Specifiers? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers subject = Attribute.Specifiers.Method;
        Attribute.Specifiers other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}