namespace MooVC.Syntax.CSharp.ConversionTests.TypesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(Conversion.Types.Implicit as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}