namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenWithOperatorsIsCalled
{
    [Fact]
    public void GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var operators = new Operators { Conversions = [new Conversion { Subject = Symbol.Undefined }] };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithOperators(operators);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Operators.ShouldBe(operators);
        original.Operators.ShouldBe(new Operators());
    }
}