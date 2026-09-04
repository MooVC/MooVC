namespace MooVC.Syntax.CSharp.ConversionTests.TypesTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(Conversion.Types.Implicit);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(default(Conversion.Types));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        bool result = type.Equals(type);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}