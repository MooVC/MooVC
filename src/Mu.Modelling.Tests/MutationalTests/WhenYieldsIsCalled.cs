namespace Mu.Modelling.MutationalTests;

using MooVC.Syntax.Elements;

public sealed class WhenYieldsIsCalled
{
    private const string UpdatedFactValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Mutational original = ModellingTestData.CreateMutational();
        Name updated = UpdatedFactValue;

        // Act
        Mutational result = original.Yields(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Fact.ShouldBe(updated);
        result.Type.ShouldBe(original.Type);
    }
}