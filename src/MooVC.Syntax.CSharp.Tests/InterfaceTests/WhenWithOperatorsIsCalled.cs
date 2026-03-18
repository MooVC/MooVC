namespace MooVC.Syntax.CSharp.InterfaceTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Operators).IsEqualTo(operators);
        _ = await Assert.That(original.Operators).IsEqualTo(new Operators());
    }
}