namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenKindThenReturnsUnderlyingValue()
    {
        // Arrange
        Struct.Kinds subject = Struct.Kinds.Ref;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("ref");
    }
}