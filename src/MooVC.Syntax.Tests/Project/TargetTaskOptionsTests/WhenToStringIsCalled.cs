namespace MooVC.Syntax.Project.TargetTaskOptionsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    [Arguments("WarnAndContinue", nameof(TargetTask.Options.WarnAndContinue))]
    [Arguments("ErrorAndContinue", nameof(TargetTask.Options.ErrorAndContinue))]
    [Arguments("ErrorAndStop", nameof(TargetTask.Options.ErrorAndStop))]
    public async Task GivenOptionThenReturnsValue(string expected, string field)
    {
        // Arrange
        TargetTask.Options subject = typeof(TargetTask.Options)
            .GetField(field)!
            .GetValue(null) as TargetTask.Options ?? TargetTask.Options.ErrorAndStop;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}