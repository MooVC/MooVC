namespace MooVC.Syntax.Attributes.Solution.FileTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        File original = FileTestsData.Create();
        var updated = Snippet.From("OtherName");

        // Act
        File result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Path.ShouldBe(original.Path);
    }
}