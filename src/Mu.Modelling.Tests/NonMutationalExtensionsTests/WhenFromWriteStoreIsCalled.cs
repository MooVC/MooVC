namespace Mu.Modelling.NonMutationalExtensionsTests;

public sealed class WhenFromWriteStoreIsCalled
{
    [Fact]
    public void GivenNonMutationalThenReturnsUpdatedInstance()
    {
        // Arrange
        NonMutational original = ModellingTestData.CreateNonMutational();

        // Act
        NonMutational result = original.FromWriteStore();

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Source.ShouldBe(NonMutational.Kind.WriteStore);
        result.View.ShouldBe(original.View);
    }
}