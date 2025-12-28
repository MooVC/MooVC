namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithParametersIsCalled
{
    [Fact]
    public void GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        var parameter = new Parameter { Name = new Identifier("input"), Type = typeof(int) };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithParameters(parameter);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Parameters.ShouldContain(parameter);
        original.Parameters.ShouldBeEmpty();
    }
}