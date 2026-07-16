namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenKindThenReturnsString()
    {
        // Arrange
        Struct.Kinds subject = Struct.Kinds.ReadOnly;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("readonly");
    }
}