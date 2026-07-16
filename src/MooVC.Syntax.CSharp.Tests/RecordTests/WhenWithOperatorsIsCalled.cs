namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenWithOperatorsIsCalled
{
    [Test]
    public async Task GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Operators { Binaries = [new() { Scope = Scopes.Public }] };
        var updated = new Operators { Unaries = [new() { Scope = Scopes.Internal }] };
        Record record = RecordTestsData.Create(operators: original);

        // Act
        Record result = record.WithOperators(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(record);
        _ = await Assert.That(result.Operators).IsEqualTo(updated);
        _ = await Assert.That(record.Operators).IsEqualTo(original);
    }
}