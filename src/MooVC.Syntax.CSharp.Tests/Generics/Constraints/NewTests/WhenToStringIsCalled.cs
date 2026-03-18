namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenRequiredThenReturnsNewConstraint()
    {
        // Arrange
        New subject = New.Required;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo("new()");
    }

    [Test]
    public async Task GivenNotRequiredThenReturnsEmpty()
    {
        // Arrange
        New subject = New.NotRequired;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }
}