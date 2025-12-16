namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        string value = type;

        // Assert
        value.ShouldBe("+");
    }
}
