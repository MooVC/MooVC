namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorAttributeAttributeIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Attribute? left = default;
        Attribute? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Attribute? left = default;
        Attribute right = AttributeTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create();
        Attribute? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifier.Constructor);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifier.Constructor);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("left") });
        Attribute right = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("right") });

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}