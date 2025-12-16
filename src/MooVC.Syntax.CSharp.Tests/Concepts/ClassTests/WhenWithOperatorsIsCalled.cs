namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenWithOperatorsIsCalled
{
    [Fact]
    public void GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create();
        var operators = new Operators
        {
            Conversions = [new Conversion { Subject = Symbol.Undefined }],
        };

        // Act
        Class result = original.WithOperators(operators);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Operators.ShouldBe(operators);
        original.Operators.Conversions.ShouldBeEmpty();
    }
}