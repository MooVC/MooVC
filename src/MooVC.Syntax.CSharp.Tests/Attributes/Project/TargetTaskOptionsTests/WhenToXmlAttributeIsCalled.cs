namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskOptionsTests;

using System.Linq;

public sealed class WhenToXmlAttributeIsCalled
{
    [Fact]
    public void GivenErrorAndStopThenReturnsEmptySequence()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.ErrorAndStop;

        // Act
        var attributes = subject.ToXmlAttribute().ToArray();

        // Assert
        attributes.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValueThenReturnsContinueOnErrorAttribute()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        var attributes = subject.ToXmlAttribute().ToArray();

        // Assert
        _ = attributes.ShouldHaveSingleItem();
        attributes[0].Name.ToString().ShouldBe("ContinueOnError");
        attributes[0].Value.ShouldBe(subject.ToString());
    }
}