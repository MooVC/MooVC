namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        var newName = new Declaration { Name = "Updated" };
        Record original = RecordTestsData.Create();

        // Act
        Record result = original.Named(newName);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Declaration.ShouldBe(newName);
        original.Declaration.ShouldBe(new Declaration { Name = RecordTestsData.DefaultName });
    }
}