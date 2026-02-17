namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenToStringIsCalled
{
    [Theory]
    [InlineData("WarnAndContinue", nameof(TargetTask.Options.WarnAndContinue))]
    [InlineData("ErrorAndContinue", nameof(TargetTask.Options.ErrorAndContinue))]
    [InlineData("ErrorAndStop", nameof(TargetTask.Options.ErrorAndStop))]
    public void GivenOptionThenReturnsValue(string expected, string field)
    {
        // Arrange
        TargetTask.Options subject = typeof(TargetTask.Options)
            .GetField(field)!
            .GetValue(null) as TargetTask.Options ?? TargetTask.Options.ErrorAndStop;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}