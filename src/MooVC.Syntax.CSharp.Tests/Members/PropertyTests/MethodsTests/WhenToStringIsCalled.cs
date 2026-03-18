namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenDefaultInstanceThenReturnsAutoImplementedAccessors()
    {
        // Arrange
        Property.Methods subject = Property.Methods.Default;

        // Act
        string representation = subject.ToString();

        // Assert
        await Assert.That(representation).Contains("get");
        await Assert.That(representation).Contains("init");
    }

    [Test]
    public async Task GivenReadOnlyPropertyThenOnlyGetterIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value;"),
            Set = new Property.Setter { Mode = Property.Mode.ReadOnly },
        };

        // Act
        string representation = subject.ToString();

        // Assert
        await Assert.That(representation).IsEqualTo("value;");
    }
}