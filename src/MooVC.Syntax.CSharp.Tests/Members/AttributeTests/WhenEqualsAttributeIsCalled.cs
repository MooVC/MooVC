namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsAttributeIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Attribute subject = AttributeTestsData.Create();
        Attribute? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute subject = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("value") });
        Attribute other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifier.Property);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifier.Property);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentArgumentsThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("left") });
        Attribute right = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("right") });

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}