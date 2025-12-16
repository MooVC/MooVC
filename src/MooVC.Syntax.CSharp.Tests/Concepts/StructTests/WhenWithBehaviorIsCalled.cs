namespace MooVC.Syntax.CSharp.Concepts.StructTests;

public sealed class WhenWithBehaviorIsCalled
{
    [Fact]
    public void GivenBehaviorThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(behavior: Struct.Kind.Ref);

        // Act
        Struct result = original.WithBehavior(Struct.Kind.ReadOnly);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behavior.ShouldBe(Struct.Kind.ReadOnly);
        original.Behavior.ShouldBe(Struct.Kind.Ref);
    }
}
