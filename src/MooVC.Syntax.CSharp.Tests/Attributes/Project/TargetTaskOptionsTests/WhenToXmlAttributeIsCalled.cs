namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskOptionsTests;

using System.Linq;
using System.Xml.Linq;

public sealed class WhenToXmlAttributeIsCalled
{
    [Fact]
    public void GivenErrorAndStopThenReturnsEmptySequence()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.ErrorAndStop;

        // Act
        XAttribute[] attributes = [.. subject.ToXmlAttribute()];

        // Assert
        attributes.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValueThenReturnsContinueOnErrorAttribute()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        XAttribute[] attributes = [.. subject.ToXmlAttribute()];

        // Assert
        _ = attributes.ShouldHaveSingleItem();
        attributes[0].Name.ToString().ShouldBe("ContinueOnError");
        attributes[0].Value.ShouldBe(subject.ToString());
    }
}