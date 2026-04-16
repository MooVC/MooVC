namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsString()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("Pascal");
    }
}