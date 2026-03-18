namespace MooVC.Syntax.CSharp.ConversionTests;

public sealed class WhenEqualsConversionIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Conversion? subject = default;
        Conversion target = ConversionTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        Conversion target = ConversionTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        Conversion target = ConversionTestsData.Create(mode: Conversion.Type.Explicit);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}