namespace MooVC.Syntax.CSharp.Attributes.Project.MetadataTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        Identifier updated = new Identifier("Other");

        // Act
        Metadata result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Value.ShouldBe(original.Value);
    }
}