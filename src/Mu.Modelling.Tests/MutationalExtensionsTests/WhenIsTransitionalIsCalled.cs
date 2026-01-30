namespace Mu.Modelling.MutationalExtensionsTests;

public sealed class WhenIsTransitionalIsCalled
{
    [Fact]
    public void GivenMutationalThenReturnsUpdatedInstance()
    {
        // Arrange
        Mutational original = ModellingTestData.CreateMutational();

        // Act
        Mutational result = original.IsTransitional();

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(Mutational.Kind.Transitional);
        result.Fact.ShouldBe(original.Fact);
    }
}