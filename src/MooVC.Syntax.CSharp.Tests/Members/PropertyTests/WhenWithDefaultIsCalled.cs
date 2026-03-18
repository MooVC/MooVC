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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(result.Default).IsEqualTo(defaultValue);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);

        _ = await Assert.That(original.Default).IsEqualTo(Snippet.Empty);
    }
}