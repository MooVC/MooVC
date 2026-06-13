namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        string value = type.ToString();

        // Assert
        _ = await Assert.That(value).IsEqualTo("!");
    }
}