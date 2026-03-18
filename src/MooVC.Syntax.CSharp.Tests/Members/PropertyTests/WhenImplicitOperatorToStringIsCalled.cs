namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Property? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenPropertyThenStringMatchesToString()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        string expected = subject.ToString();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }
}