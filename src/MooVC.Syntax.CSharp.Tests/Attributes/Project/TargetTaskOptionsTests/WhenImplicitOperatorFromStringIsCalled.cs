namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenValueThenCreatesOption()
    {
        // Arrange
        const string Value = "WarnAndContinue";

        // Act
        TargetTask.Options subject = Value;

        // Assert
        (subject == Value).ShouldBeTrue();
        subject.Equals(Value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenReturnsOriginal()
    {
        // Arrange
        const string Value = "ErrorAndContinue";

        // Act
        TargetTask.Options subject = Value;
        string result = subject;

        // Assert
        result.ShouldBe(Value);
    }
}