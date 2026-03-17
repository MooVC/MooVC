namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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