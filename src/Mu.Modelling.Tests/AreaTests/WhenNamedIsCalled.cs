namespace Mu.Modelling.AreaTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedNameValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Area original = ModellingTestData.CreateArea();
        Name updated = UpdatedNameValue;

        // Act
        Area result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Units.ShouldBe(original.Units);
    }
}