namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Operators;

public sealed class WhenWithOperatorsIsCalled
{
    [Fact]
    public void GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        Operators originalOperators = new Operators { Equality = [new Equality { Target = typeof(string) }] };
        Operators updated = new Operators { Arithmetic = [new Arithmetic { Target = typeof(int), Type = Arithmetic.Types.Addition }], Equality = originalOperators.Equality };
        Record original = RecordTestsData.Create(operators: originalOperators);

        // Act
        Record result = original.WithOperators(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Operators.ShouldBe(updated);
        original.Operators.ShouldBe(originalOperators);
    }
}
