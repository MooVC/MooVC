namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        string value = type;

        // Assert
        _ = await Assert.That(value).IsEqualTo("!");
    }
}