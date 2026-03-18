namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Test]
    public async Task GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();
        var body = Snippet.From("Shutdown();");

        // Act
        Constructor result = original.WithBody(body);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(body);
        await Assert.That(result.Extensibility).IsEqualTo(original.Extensibility);
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);

        await Assert.That(original.Body).IsEqualTo(Snippet.From("Initialize();"));
    }
}