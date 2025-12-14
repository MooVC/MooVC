namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenPropertiesAreAccessed
{
    [Fact]
    public void GivenToThenFlagsReflectValue()
    {
        // Arrange
        Conversion.Intent subject = Conversion.Intent.To;

        // Act
        bool isTo = subject.IsTo;
        bool isFrom = subject.IsFrom;

        // Assert
        isTo.ShouldBeTrue();
        isFrom.ShouldBeFalse();
    }
}
