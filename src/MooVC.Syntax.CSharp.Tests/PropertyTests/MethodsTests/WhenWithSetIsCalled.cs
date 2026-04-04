namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests;

public sealed class WhenWithSetIsCalled
{
    [Test]
    public async Task GivenSetterThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        var set = new Property.Methods.Setter
        {
            Behaviour = Snippet.From("value = input"),
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scope.Private,
        };

        // Act
        Property.Methods result = original.WithSet(set);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Get).IsEqualTo(original.Get);
        _ = await Assert.That(result.Set).IsEqualTo(set);
        _ = await Assert.That(original.Set).IsEqualTo(Property.Methods.Setter.Default);
    }
}