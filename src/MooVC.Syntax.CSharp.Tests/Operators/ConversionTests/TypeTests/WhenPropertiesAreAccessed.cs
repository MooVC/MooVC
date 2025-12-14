namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    [Fact]
    public void GivenImplicitThenFlagsReflectValue()
    {
        // Arrange
        Conversion.Type subject = Conversion.Type.Implicit;

        // Act
        bool isImplicit = subject.IsImplicit;
        bool isExplicit = subject.IsExplicit;
        string representation = subject.ToString();

        // Assert
        isImplicit.ShouldBeTrue();
        isExplicit.ShouldBeFalse();
        representation.ShouldBe("implicit");
    }
}