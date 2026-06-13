namespace MooVC.Syntax.CSharp.PropertyTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Property? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenPropertyThenStringMatchesToString()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        string expected = subject.ToString();

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}