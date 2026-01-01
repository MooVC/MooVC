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
        var newName = new Declaration { Name = new Variable("Other") };

        // Act
        Class result = original.Named(newName);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(newName);
        original.Name.ShouldBe(new Declaration { Name = new Variable(ClassTestsData.DefaultName) });
    }
}