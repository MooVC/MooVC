namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Constructor? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenConstructorThenStringMatchesToString()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(subject.ToString());
    }
}