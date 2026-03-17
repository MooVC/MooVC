namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Field? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenFieldThenStringMatchesToString()
    {
        // Arrange
        Field subject = FieldTestsData.Create();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}