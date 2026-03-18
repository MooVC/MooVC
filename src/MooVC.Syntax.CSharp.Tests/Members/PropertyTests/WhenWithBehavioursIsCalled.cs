namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBehavioursIsCalled
{
    [Test]
    public async Task GivenBehavioursThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var behaviours = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        Property result = original.WithBehaviours(behaviours);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviours).IsEqualTo(behaviours);
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Type).IsEqualTo(original.Type);

        await Assert.That(original.Behaviours).IsNotEqualTo(behaviours);
    }
}