namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenTaskParameterIsUndefined()
    {
        // Act
        var subject = new Parameter();

        // Assert
        await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.Value).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Parameter
        {
            Name = ParameterTestsData.DefaultName,
            Value = Snippet.From(ParameterTestsData.DefaultValue),
        };

        // Assert
        await Assert.That(subject.Name).IsEqualTo(new Name(ParameterTestsData.DefaultName));
        await Assert.That(subject.Value).IsEqualTo(Snippet.From(ParameterTestsData.DefaultValue));
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}