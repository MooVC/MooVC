namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenWithOperatorsIsCalled
{
    [Fact]
    public void GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Operators { Binaries = [new Binary { Scope = Scope.Public }] };
        var updated = new Operators { Unaries = [new Unary { Scope = Scope.Internal }] };
        Record record = RecordTestsData.Create(operators: original);

        // Act
        Record result = record.WithOperators(updated);

        // Assert
        result.ShouldNotBeSameAs(record);
        result.Operators.ShouldBe(updated);
        record.Operators.ShouldBe(original);
    }
}