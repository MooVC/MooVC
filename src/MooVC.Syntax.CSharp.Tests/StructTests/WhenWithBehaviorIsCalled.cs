namespace MooVC.Syntax.CSharp.StructTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behavior).IsEqualTo(Struct.Kind.ReadOnly);
        _ = await Assert.That(original.Behavior).IsEqualTo(Struct.Kind.Ref);
    }
}