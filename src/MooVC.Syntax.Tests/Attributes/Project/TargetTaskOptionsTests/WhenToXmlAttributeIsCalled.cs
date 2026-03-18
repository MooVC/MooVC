namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

using System.Xml.Linq;

public sealed class WhenToXmlAttributeIsCalled
{
    [Test]
    public async Task GivenErrorAndStopThenReturnsEmptySequence()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.ErrorAndStop;

        // Act
        XAttribute[] attributes = [.. subject.ToXmlAttribute()];

        // Assert
        await Assert.That(attributes).IsEmpty();
    }

    [Test]
    public async Task GivenValueThenReturnsContinueOnErrorAttribute()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        XAttribute[] attributes = [.. subject.ToXmlAttribute()];

        // Assert
        _ = await attributes.Single();
        await Assert.That(attributes[0].Name.ToString()).IsEqualTo("ContinueOnError");
        await Assert.That(attributes[0].Value).IsEqualTo(subject.ToString());
    }
}