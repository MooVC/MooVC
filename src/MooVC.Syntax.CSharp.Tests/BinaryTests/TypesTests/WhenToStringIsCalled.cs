namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        string value = type.ToString();

        // Assert
        _ = await Assert.That(value).IsEqualTo("+");
    }
}