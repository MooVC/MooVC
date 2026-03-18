namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNonConversionObjectThenReturnsFalse()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenConversionObjectThenReturnsResultOfConversionEquals()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        object target = ConversionTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}