namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithFieldsIsCalled
{
    [Fact]
    public void GivenFieldsThenReturnsUpdatedInstance()
    {
        // Arrange
        var field = new Field { Name = new Identifier("_value"), Type = typeof(int) };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithFields(field);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Fields.ShouldContain(field);
        original.Fields.ShouldBeEmpty();
    }
}