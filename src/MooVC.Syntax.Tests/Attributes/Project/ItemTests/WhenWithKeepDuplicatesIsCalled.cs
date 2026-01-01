namespace MooVC.Syntax.Attributes.Project.ItemTests;

public sealed class WhenWithKeepDuplicatesIsCalled
{
    [Fact]
    public void GivenKeepDuplicatesThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        const bool updated = true;

        // Act
        Item result = original.WithKeepDuplicates(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.KeepDuplicates.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Include.ShouldBe(original.Include);
    }
}