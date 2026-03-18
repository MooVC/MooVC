namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenWithOperatorsIsCalled
{
    [Test]
    public async Task GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var operators = new Operators { Conversions = [new Conversion { Target = Symbol.Undefined }] };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithOperators(operators);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Operators).IsEqualTo(operators);
        await Assert.That(original.Operators).IsEqualTo(new Operators());
    }
}