namespace MooVC.Syntax.CSharp.ResultTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenThrows()
    {
        // Arrange
        Result? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenResultThenStringMatchesToString()
    {
        // Arrange
        Result subject = ResultTestsData.Create(modifier: Result.Kind.Ref, mode: Result.Modality.Asynchronous);

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}