namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create();
        var newName = new Declaration { Name = new Identifier("Other") };

        // Act
        Class result = original.WithName(newName);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(newName);
        original.Name.ShouldBe(new Declaration { Name = new Identifier(ClassTestsData.DefaultName) });
    }
}
