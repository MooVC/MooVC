namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithDefaultIsCalled
{
    [Test]
    public async Task GivenDefaultThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var defaultValue = Snippet.From("value");

        // Act
        Property result = original.WithDefault(defaultValue);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(result.Default).IsEqualTo(defaultValue);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Type).IsEqualTo(original.Type);

        await Assert.That(original.Default).IsEqualTo(Snippet.Empty);
    }
}