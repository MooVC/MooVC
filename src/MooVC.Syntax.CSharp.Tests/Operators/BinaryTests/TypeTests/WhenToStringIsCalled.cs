namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        string value = type.ToString();

        // Assert
        value.ShouldBe("+");
    }
}