namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenToStringIsCalled
{
    private const string BaseName = "BaseType";

    [Test]
    public async Task GivenUnspecifiedBaseThenReturnsEmpty()
    {
        // Arrange
        Base subject = Base.Unspecified;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenSpecifiedBaseThenReturnsName()
    {
        // Arrange
        Base subject = new Symbol { Name = BaseName };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(BaseName);
    }
}