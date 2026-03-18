namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        string value = type;

        // Assert
        _ = await Assert.That(value).IsEqualTo("!");
    }
}