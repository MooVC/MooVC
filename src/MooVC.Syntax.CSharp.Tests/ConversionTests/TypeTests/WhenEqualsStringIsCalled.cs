namespace MooVC.Syntax.CSharp.ConversionTests.TypeTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "explicit";
    private const string Other = "implicit";

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(Value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(Other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}