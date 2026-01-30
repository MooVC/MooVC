namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithMethodsIsCalled
{
    [Fact]
    public void GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        var execute = new Method { Name = new Declaration { Name = "Execute" } };
        var undo = new Method { Name = new Declaration { Name = "Undo" } };
        Record original = RecordTestsData.Create(methods: [execute]);

        // Act
        Record result = original.WithMethods(undo);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Methods.ShouldBe(new[] { execute, undo });
        result.Name.ShouldBe(original.Name);
    }
}