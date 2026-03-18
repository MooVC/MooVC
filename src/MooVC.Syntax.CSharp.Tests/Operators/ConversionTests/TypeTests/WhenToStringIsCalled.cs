namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        string value = type.ToString();

        // Assert
        value.ShouldBe("explicit");
    }
}