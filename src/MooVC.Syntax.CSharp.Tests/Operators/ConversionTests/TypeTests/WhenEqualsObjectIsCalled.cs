namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(Conversion.Type.Implicit as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}