namespace MooVC.Syntax.CSharp.AttributeTests;

public sealed class WhenEqualityOperatorAttributeAttributeIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Attribute? left = default;
        Attribute? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Attribute? left = default;
        Attribute right = AttributeTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create();
        Attribute? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute first = AttributeTestsData.Create(target: Attribute.Specifier.Method);
        Attribute second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifier.Method);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifier.Method);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentTargetsThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifier.Method);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifier.Property);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentArgumentsThenReturnsFalse()
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
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}