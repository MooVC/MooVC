namespace Mu.Modelling.ResultTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedNameValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ModellingTestData.CreateResult();
        Name updated = UpdatedNameValue;

        // Act
        Result result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Type.ShouldBe(original.Type);
    }
}