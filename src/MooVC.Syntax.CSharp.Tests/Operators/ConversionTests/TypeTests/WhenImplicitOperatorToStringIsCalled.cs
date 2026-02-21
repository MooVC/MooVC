namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        string value = type;

        // Assert
        value.ShouldBe("explicit");
    }
}