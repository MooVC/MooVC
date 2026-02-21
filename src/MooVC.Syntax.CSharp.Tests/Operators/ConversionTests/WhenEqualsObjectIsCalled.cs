namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNonConversionObjectThenReturnsFalse()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenConversionObjectThenReturnsResultOfConversionEquals()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        object target = ConversionTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }
}