namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenWithOperatorsIsCalled
{
    [Test]
    public async Task GivenOperatorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var operators = new Operators { Conversions = [new() { Target = Symbol.Undefined }] };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithOperators(operators);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Operators).IsEqualTo(operators);
        _ = await Assert.That(original.Operators).IsEqualTo(new Operators());
    }
}