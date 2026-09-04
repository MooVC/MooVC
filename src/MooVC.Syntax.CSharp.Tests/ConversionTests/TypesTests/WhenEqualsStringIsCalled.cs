namespace MooVC.Syntax.CSharp.ConversionTests.TypesTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "explicit";
    private const string Other = "implicit";

    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(Other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(Value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}