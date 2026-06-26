namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests;

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
        _ = await Assert.That(representation).Contains("get");
        _ = await Assert.That(representation).Contains("init");
    }

    [Test]
    public async Task GivenReadOnlyPropertyThenOnlyGetterIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value;"),
            Set = new() { Mode = Property.Methods.Setter.Modes.ReadOnly },
        };

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo("value;");
    }
}