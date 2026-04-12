namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenInequalityOperatorOptionsStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Qualifier.Options subject = "Block";

        // Act
        bool result = subject != "File";

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}