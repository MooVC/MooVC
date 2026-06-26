namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(Comparison.Types.Inequality);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(default(Comparison.Types));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(type);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(Comparison.Types.Equality);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}