namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenEqualStringThenReturnsTrue()
    {
        // Arrange
        Qualifier.Options subject = "Block";

        // Act
        bool result = subject.Equals("Block");

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}