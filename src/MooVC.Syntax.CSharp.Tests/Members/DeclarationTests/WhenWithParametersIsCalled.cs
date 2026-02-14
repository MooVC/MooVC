namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.CSharp.Generics;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenWithParametersIsCalled
{
    [Fact]
    public void GivenParametersThenReturnsNewInstanceWithUpdatedParameters()
    {
        // Arrange
        Declaration original = DeclarationTestsData.Create(parameterNames: "T");
        Parameter[] additional = [new Parameter { Name = new Identifier("U") }];

        // Act
        Declaration result = original.WithParameters(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Parameters.Length.ShouldBe(2);
        result.Parameters.ShouldBe(original.Parameters.Concat(additional));
        result.Name.ShouldBe(original.Name);
    }
}