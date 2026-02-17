namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create();
        var newName = new Declaration { Name = "Other" };

        // Act
        Class result = original.Named(newName);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Declaration.ShouldBe(newName);
        original.Declaration.ShouldBe(new Declaration { Name = ClassTestsData.DefaultName });
    }
}