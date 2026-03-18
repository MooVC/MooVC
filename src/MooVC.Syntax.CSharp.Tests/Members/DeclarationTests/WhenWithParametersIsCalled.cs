namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.CSharp.Generics;
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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Parameters.Length).IsEqualTo(2);
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters.Concat(additional));
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}