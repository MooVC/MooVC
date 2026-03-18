namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenWithOperatorsIsCalled
{
    [Test]
    public async Task GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Operators { Binaries = [new Binary { Scope = Scope.Public }] };
        var updated = new Operators { Unaries = [new Unary { Scope = Scope.Internal }] };
        Record record = RecordTestsData.Create(operators: original);

        // Act
        Record result = record.WithOperators(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, record)).IsFalse();
        await Assert.That(result.Operators).IsEqualTo(updated);
        await Assert.That(record.Operators).IsEqualTo(original);
    }
}