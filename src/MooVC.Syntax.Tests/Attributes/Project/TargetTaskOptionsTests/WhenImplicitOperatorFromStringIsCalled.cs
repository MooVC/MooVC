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
        await Assert.That((subject == Value)).IsTrue();
        await Assert.That(subject.Equals(Value)).IsTrue();
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
        await Assert.That(result).IsEqualTo(Value);
    }
}