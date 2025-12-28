namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        object? value = default;
        Attribute subject = AttributeTestsData.Create();

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonMatchingTypeThenReturnsFalse()
    {
        // Arrange
        object value = new();
        Attribute subject = AttributeTestsData.Create();

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute subject = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("value") });
        object value = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("value") });

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute subject = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("left") });
        object value = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("right") });

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }
}