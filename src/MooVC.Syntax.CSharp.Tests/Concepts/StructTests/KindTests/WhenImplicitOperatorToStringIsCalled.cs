namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenKindThenReturnsString()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.ReadOnly;

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo("readonly");
    }
}