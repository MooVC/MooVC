namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorAttributeAttributeIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Attribute? left = default;
        Attribute? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Attribute? left = default;
        Attribute right = AttributeTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create();
        Attribute? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute first = AttributeTestsData.Create(target: Attribute.Specifier.Method);
        Attribute second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifier.Method);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifier.Method);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentTargetsThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifier.Method);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifier.Property);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentArgumentsThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(
            arguments: new Argument { Name = new Identifier("Left"), Value = Snippet.From("value") });

        Attribute right = AttributeTestsData.Create(
            arguments: new Argument { Name = new Identifier("Right"), Value = Snippet.From("value") });

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}