namespace MooVC.Syntax.CSharp.UnaryTests.TypeTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        string value = type.ToString();

        // Assert
        _ = await Assert.That(value).IsEqualTo("!");
    }
}