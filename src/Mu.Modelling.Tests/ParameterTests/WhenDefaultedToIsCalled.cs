namespace Mu.Modelling.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenDefaultedToIsCalled
{
    private const string UpdatedDefaultValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter original = ModellingTestData.CreateParameter();
        Snippet updated = Snippet.From(UpdatedDefaultValue);

        // Act
        Parameter result = original.DefaultedTo(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
    }
}