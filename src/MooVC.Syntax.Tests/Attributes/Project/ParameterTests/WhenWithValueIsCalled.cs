namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    private const string UpdatedValue = "UpdatedValue";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create();
        var updated = UpdatedValue;

        // Act
        Parameter result = original.WithValue(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Value.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}