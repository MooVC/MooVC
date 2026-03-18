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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Behaviours).IsEqualTo(behaviours);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);

        _ = await Assert.That(original.Behaviours).IsNotEqualTo(behaviours);
    }
}