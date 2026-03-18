namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenWithOperatorsIsCalled
{
    [Test]
    public async Task GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create();
        var operators = new Operators
        {
            Conversions = [new Conversion { Target = Symbol.Undefined }],
        };

        // Act
        Class result = original.WithOperators(operators);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Operators).IsEqualTo(operators);
        await Assert.That(original.Operators.Conversions).IsEmpty();
    }
}