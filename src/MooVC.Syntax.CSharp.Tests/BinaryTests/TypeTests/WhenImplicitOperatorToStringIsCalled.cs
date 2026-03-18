namespace MooVC.Syntax.CSharp.BinaryTests.TypeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        string value = type;

        // Assert
        _ = await Assert.That(value).IsEqualTo("+");
    }
}