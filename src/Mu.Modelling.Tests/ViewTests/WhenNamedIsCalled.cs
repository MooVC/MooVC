namespace Mu.Modelling.ViewTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedNameValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        View original = ModellingTestData.CreateView();
        Identifier updated = ModellingTestData.CreateIdentifier(UpdatedNameValue);

        // Act
        View result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Attributes.ShouldBe(original.Attributes);
        result.Facts.ShouldBe(original.Facts);
    }
}