namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        string value = type.ToString();

        // Assert
        _ = await Assert.That(value).IsEqualTo("+");
    }
}