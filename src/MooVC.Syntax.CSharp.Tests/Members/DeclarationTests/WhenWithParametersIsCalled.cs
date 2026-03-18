namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.Elements;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenWithParametersIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsNewInstanceWithUpdatedParameters()
    {
        // Arrange
        Declaration original = DeclarationTestsData.Create(parameterNames: "T");
        Parameter[] additional = [new Parameter { Name = new Name("U") }];

        // Act
        Declaration result = original.WithParameters(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Parameters.Length).IsEqualTo(2);
        _ = await Assert.That(result.Parameters).IsEquivalentTo([.. original.Parameters, .. additional]);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}