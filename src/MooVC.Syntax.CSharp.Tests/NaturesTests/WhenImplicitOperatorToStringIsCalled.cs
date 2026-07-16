namespace MooVC.Syntax.CSharp.NaturesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNaturesThenReturnsValue()
    {
        // Arrange
        Natures subject = "struct";

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}