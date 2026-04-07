namespace MooVC.Syntax.CSharp.AttributeTests;

public sealed class WhenInequalityOperatorAttributeAttributeIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Attribute? left = default;
        Attribute? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("left") });
        Attribute right = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("right") });

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifiers.Constructor);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifiers.Constructor);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Attribute? left = default;
        Attribute right = AttributeTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create();
        Attribute? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}