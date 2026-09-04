namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "!";
    private const string Other = "++";

    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(Other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(Value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}