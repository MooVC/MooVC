namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        var newName = new Declaration { Name = new Identifier("Updated") };
        Record original = RecordTestsData.Create();

        // Act
        Record result = original.Named(newName);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(newName);
        original.Name.ShouldBe(new Declaration { Name = new Identifier(RecordTestsData.DefaultName) });
    }
}