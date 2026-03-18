namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(default(Conversion.Type));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(type);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(Conversion.Type.Implicit);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}