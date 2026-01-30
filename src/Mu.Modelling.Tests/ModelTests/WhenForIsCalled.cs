namespace Mu.Modelling.ModelTests;

using MooVC.Syntax.Elements;

public sealed class WhenForIsCalled
{
    private const string UpdatedCompanyValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Model original = ModellingTestData.CreateModel();
        Identifier updated = ModellingTestData.CreateIdentifier(UpdatedCompanyValue);

        // Act
        Model result = original.For(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Company.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Areas.ShouldBe(original.Areas);
    }
}