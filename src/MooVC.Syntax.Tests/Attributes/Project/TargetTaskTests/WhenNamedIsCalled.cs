namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedName = "UpdatedName";

    [Test]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask original = TargetTaskTestsData.Create(output: TargetTaskTestsData.CreateOutput());
        var updated = new Name(UpdatedName);

        // Act
        TargetTask result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.ContinueOnError.ShouldBe(original.ContinueOnError);
    }
}