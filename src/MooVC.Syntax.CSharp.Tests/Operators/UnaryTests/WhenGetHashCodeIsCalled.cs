namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentUnaryOperatorsThenReturnTheSameValue()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(secondHash).IsEqualTo(firstHash);
    }
}