namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Constructor? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenConstructorThenStringMatchesToString()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}