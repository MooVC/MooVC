namespace MooVC.Syntax.CSharp.ComparisonTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Comparison.Type.Inequality);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(default(Comparison.Type));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(type);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Comparison.Type.Equality);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}