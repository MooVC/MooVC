namespace MooVC.Syntax.CSharp.Attributes.Solution.PropertyTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        Snippet updated = Snippet.From("OtherName");

        // Act
        Property result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Value.ShouldBe(original.Value);
    }
}