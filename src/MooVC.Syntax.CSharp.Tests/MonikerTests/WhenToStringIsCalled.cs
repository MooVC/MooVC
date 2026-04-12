namespace MooVC.Syntax.CSharp.MonikerTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenValueThenValueIsReturned()
    {
        // Arrange
        Moniker subject = "Value";

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("Value");
    }
}