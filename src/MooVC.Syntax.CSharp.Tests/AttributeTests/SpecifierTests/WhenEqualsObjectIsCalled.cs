namespace MooVC.Syntax.CSharp.AttributeTests.SpecifierTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Class;
        object value = Attribute.Specifier.Module;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Class;
        object value = Attribute.Specifier.Class;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonMatchingTypeThenReturnsFalse()
    {
        // Arrange
        object value = new();
        Attribute.Specifier subject = Attribute.Specifier.Class;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        object? value = default;
        Attribute.Specifier subject = Attribute.Specifier.Class;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}