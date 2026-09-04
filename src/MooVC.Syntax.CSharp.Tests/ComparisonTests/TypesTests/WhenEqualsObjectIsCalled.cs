namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(Comparison.Types.Inequality as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenAnUnrecognisedTypeThenReturnsFalse()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(Comparison.Types.Equality as object);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}