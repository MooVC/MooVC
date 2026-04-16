namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        string value = type;

        // Assert
        _ = await Assert.That(value).IsEqualTo("+");
    }
}