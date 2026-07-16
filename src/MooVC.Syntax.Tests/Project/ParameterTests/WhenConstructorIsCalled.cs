namespace MooVC.Syntax.Project.ParameterTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenTaskParameterIsUndefined()
    {
        // Act
        var subject = new Parameter();

        // Assert
        _ = await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.Value).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(ParameterTestsData.DefaultName));
        _ = await Assert.That(subject.Value).IsEqualTo(Snippet.From(ParameterTestsData.DefaultValue));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}