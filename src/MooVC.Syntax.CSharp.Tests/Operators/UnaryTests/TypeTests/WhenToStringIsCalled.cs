namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        string value = type.ToString();

        // Assert
        value.ShouldBe("!");
    }
}
