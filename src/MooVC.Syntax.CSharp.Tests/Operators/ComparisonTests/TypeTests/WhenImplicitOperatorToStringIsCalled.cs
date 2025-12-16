namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenATypeThenReturnsTheValue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        string value = type;

        // Assert
        value.ShouldBe(Comparison.Type.Equality.ToString());
    }
}
