namespace MooVC.Syntax.CSharp.ClassTests;

using System.Collections.Immutable;

public sealed class WhenWithFieldsIsCalled
{
    [Test]
    public async Task GivenFieldsThenReturnsUpdatedInstance()
    {
        // Arrange
        Field[] existing = [new() { Name = new("_first"), Type = typeof(int) }];
        Field[] additional = [new() { Name = new("_second"), Type = typeof(string) }];
        Class original = ClassTestsData.Create(fields: existing.ToImmutableArray());

        // Act
        Class result = original.WithFields(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Fields).IsEquivalentTo([.. original.Fields, .. additional]);
        _ = await Assert.That(result.IsPartial).IsEqualTo(original.IsPartial);
        _ = await Assert.That(original.Fields).IsEquivalentTo(existing);
    }
}