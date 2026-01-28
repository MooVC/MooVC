namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenWithOperatorsIsCalled
{
    [Fact]
    public void GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var operators = new Operators { Conversions = [new Conversion { Subject = Symbol.Undefined }] };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithOperators(operators);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Operators.ShouldBe(operators);
        original.Operators.ShouldBe(new Operators());
    }
}