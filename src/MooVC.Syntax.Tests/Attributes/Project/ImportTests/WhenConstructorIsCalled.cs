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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Label).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Project).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Sdk).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.From(ImportTestsData.DefaultCondition));
        _ = await Assert.That(subject.Label).IsEqualTo(Snippet.From(ImportTestsData.DefaultLabel));
        _ = await Assert.That(subject.Project).IsEqualTo(Snippet.From(ImportTestsData.DefaultProject));
        _ = await Assert.That(subject.Sdk).IsEqualTo(Snippet.From(ImportTestsData.DefaultSdk));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}