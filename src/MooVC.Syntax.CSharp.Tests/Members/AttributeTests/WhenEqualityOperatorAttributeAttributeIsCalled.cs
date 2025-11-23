namespace MooVC.Syntax.CSharp.Members.AttributeTests;

public sealed class WhenEqualityOperatorAttributeAttributeIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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