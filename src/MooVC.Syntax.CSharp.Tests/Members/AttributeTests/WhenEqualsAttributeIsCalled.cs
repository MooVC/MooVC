namespace MooVC.Syntax.CSharp.Members.AttributeTests;

public sealed class WhenEqualsAttributeIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Attribute subject = AttributeTestsData.Create();
        Attribute? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute subject = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("value") });
        Attribute other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifier.Property);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifier.Property);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentArgumentsThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("left") });
        Attribute right = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("right") });

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}
