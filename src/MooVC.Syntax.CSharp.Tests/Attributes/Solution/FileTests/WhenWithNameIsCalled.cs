namespace MooVC.Syntax.CSharp.Attributes.Solution.FileTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        File original = FileTestsData.Create();
        Snippet updated = Snippet.From("OtherName");

        // Act
        File result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Path.ShouldBe(original.Path);
    }
}