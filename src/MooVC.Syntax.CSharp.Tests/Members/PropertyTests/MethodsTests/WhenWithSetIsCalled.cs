namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

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

        var set = new Property.Setter
        {
            Behaviour = Snippet.From("value = input"),
            Mode = Property.Mode.Init,
            Scope = Scope.Private,
        };

        // Act
        Property.Methods result = original.WithSet(set);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Get).IsEqualTo(original.Get);
        await Assert.That(result.Set).IsEqualTo(set);
        await Assert.That(original.Set).IsEqualTo(Property.Setter.Default);
    }
}