namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithFieldsIsCalled
{
    [Fact]
    public void GivenFieldsThenReturnsUpdatedInstance()
    {
        // Arrange
        Field[] existing = [new Field { Name = new Identifier("_first"), Type = typeof(int) }];
        Field[] additional = [new Field { Name = new Identifier("_second"), Type = typeof(string) }];
        Class original = ClassTestsData.Create(fields: existing.ToImmutableArray());

        // Act
        Class result = original.WithFields(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Fields.ShouldBe(original.Fields.Concat(additional));
        result.IsPartial.ShouldBe(original.IsPartial);
        original.Fields.ShouldBe(existing);
    }
}