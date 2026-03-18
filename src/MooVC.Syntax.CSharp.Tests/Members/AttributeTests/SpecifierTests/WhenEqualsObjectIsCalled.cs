namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        object? value = default;
        Attribute.Specifier subject = Attribute.Specifier.Class;

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenNonMatchingTypeThenReturnsFalse()
    {
        // Arrange
        object value = new();
        Attribute.Specifier subject = Attribute.Specifier.Class;

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Class;
        object value = Attribute.Specifier.Class;

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Class;
        object value = Attribute.Specifier.Module;

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }
}