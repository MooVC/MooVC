namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "==";
    private const string Other = "!=";

    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(Other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        bool result = type.Equals(Value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}