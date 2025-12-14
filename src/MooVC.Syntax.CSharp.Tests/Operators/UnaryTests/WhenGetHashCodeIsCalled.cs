namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentUnaryOperatorsThenReturnTheSameValue()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        secondHash.ShouldBe(firstHash);
    }
}