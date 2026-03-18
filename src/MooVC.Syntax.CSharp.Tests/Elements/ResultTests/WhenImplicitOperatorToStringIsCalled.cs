namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public void GivenNullSubjectThenThrows()
    {
        // Arrange
        Result? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenResultThenStringMatchesToString()
    {
        // Arrange
        Result subject = ResultTestsData.Create(modifier: Result.Kind.Ref, mode: Result.Modality.Asynchronous);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}