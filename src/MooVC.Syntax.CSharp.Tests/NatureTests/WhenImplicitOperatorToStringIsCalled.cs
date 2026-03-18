namespace MooVC.Syntax.CSharp.NatureTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNatureThenReturnsValue()
    {
        // Arrange
        Nature subject = "struct";

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}