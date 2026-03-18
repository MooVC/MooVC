namespace MooVC.Syntax.CSharp.StructTests.KindTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenKindThenReturnsUnderlyingValue()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.Ref;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("ref");
    }
}