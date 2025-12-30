namespace MooVC.Syntax.CSharp.Attributes.Solution.PropertyTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithValueIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var updated = Snippet.From("OtherValue");

        // Act
        Property result = original.WithValue(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Value.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}