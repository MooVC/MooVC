namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers subject = Attribute.Specifiers.Class;
        object value = Attribute.Specifiers.Module;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers subject = Attribute.Specifiers.Class;
        object value = Attribute.Specifiers.Class;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonMatchingTypeThenReturnsFalse()
    {
        // Arrange
        object value = new object();
        Attribute.Specifiers subject = Attribute.Specifiers.Class;

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
        Attribute.Specifiers subject = Attribute.Specifiers.Class;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}