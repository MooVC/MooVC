namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsString()
    {
        // Arrange
        Qualifier.Options subject = "Block";

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("Block");
    }
}