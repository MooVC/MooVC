namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenImportIsUndefined()
    {
        // Act
        var subject = new Import();

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Label).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Project).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Sdk).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Import
        {
            Condition = Snippet.From(ImportTestsData.DefaultCondition),
            Label = Snippet.From(ImportTestsData.DefaultLabel),
            Project = Snippet.From(ImportTestsData.DefaultProject),
            Sdk = Snippet.From(ImportTestsData.DefaultSdk),
        };

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.From(ImportTestsData.DefaultCondition));
        await Assert.That(subject.Label).IsEqualTo(Snippet.From(ImportTestsData.DefaultLabel));
        await Assert.That(subject.Project).IsEqualTo(Snippet.From(ImportTestsData.DefaultProject));
        await Assert.That(subject.Sdk).IsEqualTo(Snippet.From(ImportTestsData.DefaultSdk));
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}