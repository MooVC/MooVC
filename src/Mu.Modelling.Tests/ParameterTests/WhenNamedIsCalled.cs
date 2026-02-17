namespace Mu.Modelling.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedNameValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter original = ModellingTestData.CreateParameter();
        Name updated = UpdatedNameValue;

        // Act
        Parameter result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Default.ShouldBe(original.Default);
        result.Type.ShouldBe(original.Type);
    }
}