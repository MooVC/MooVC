namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

public sealed class WhenWithMethodsIsCalled
{
    [Test]
    public async Task GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        var execute = new Method { Name = new Declaration { Name = "Execute" } };
        var undo = new Method { Name = new Declaration { Name = "Undo" } };
        Record original = RecordTestsData.Create(methods: [execute]);

        // Act
        Record result = original.WithMethods(undo);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Methods).IsEquivalentTo([execute, undo]);
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
    }
}