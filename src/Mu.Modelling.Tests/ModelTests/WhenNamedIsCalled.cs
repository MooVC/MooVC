namespace Mu.Modelling.ModelTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedNameValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Model original = ModellingTestData.CreateModel();
        Name updated = UpdatedNameValue;

        // Act
        Model result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Company.ShouldBe(original.Company);
        result.Areas.ShouldBe(original.Areas);
    }
}