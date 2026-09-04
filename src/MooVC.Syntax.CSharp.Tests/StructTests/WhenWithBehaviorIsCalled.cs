namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenWithBehaviorIsCalled
{
    [Test]
    public async Task GivenBehaviorThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(behavior: Struct.Kinds.Ref);

        // Act
        Struct result = original.WithBehavior(Struct.Kinds.ReadOnly);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behavior).IsEqualTo(Struct.Kinds.ReadOnly);
        _ = await Assert.That(original.Behavior).IsEqualTo(Struct.Kinds.Ref);
    }
}