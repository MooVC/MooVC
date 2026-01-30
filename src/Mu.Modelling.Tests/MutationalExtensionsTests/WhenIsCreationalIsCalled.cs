namespace Mu.Modelling.MutationalExtensionsTests;

public sealed class WhenIsCreationalIsCalled
{
    [Fact]
    public void GivenMutationalThenReturnsUpdatedInstance()
    {
        // Arrange
        Mutational original = ModellingTestData.CreateMutational();

        // Act
        Mutational result = original.IsCreational();

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(Mutational.Kind.Creational);
        result.Fact.ShouldBe(original.Fact);
    }
}