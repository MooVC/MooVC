namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenEqualityOperatorOptionsStringIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string option = "Block";
        Qualifier.Options subject = option;

        // Act
        bool result = subject == option;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}