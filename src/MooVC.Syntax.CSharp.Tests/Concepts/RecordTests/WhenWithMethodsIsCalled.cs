namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Methods).IsEqualTo(new[] { execute, undo });
        await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
    }
}