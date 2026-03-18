namespace MooVC.Syntax.CSharp.Concepts.StructTests;

public sealed class WhenWithBehaviorIsCalled
{
    [Test]
    public async Task GivenBehaviorThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(behavior: Struct.Kind.Ref);

        // Act
        Struct result = original.WithBehavior(Struct.Kind.ReadOnly);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behavior).IsEqualTo(Struct.Kind.ReadOnly);
        await Assert.That(original.Behavior).IsEqualTo(Struct.Kind.Ref);
    }
}