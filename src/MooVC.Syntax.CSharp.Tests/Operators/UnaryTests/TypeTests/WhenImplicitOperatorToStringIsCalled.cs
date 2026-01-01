namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        string value = type;

        // Assert
        value.ShouldBe("!");
    }
}