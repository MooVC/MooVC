namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenCreatesOption()
    {
        // Arrange
        const string Value = "WarnAndContinue";

        // Act
        TargetTask.Options subject = Value;

        // Assert
        _ = await Assert.That(subject == Value).IsTrue();
        _ = await Assert.That(subject.Equals(Value)).IsTrue();
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenReturnsOriginal()
    {
        // Arrange
        const string Value = "ErrorAndContinue";

        // Act
        TargetTask.Options subject = Value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Value);
    }
}