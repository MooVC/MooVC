namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsString()
    {
        // Arrange
        Qualifier.Options subject = "File";

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("File");
    }
}