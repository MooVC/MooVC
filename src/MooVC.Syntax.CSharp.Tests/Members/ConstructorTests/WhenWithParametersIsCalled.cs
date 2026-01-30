namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenWithParametersIsCalled
{
    [Fact]
    public void GivenParametersThenReturnsNewInstanceWithUpdatedParameters()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();

        Parameter[] parameters =
        [
            ParameterTestsData.Create(name: "other"),
        ];

        // Act
        Constructor result = original.WithParameters([.. parameters]);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Extensibility.ShouldBe(original.Extensibility);
        result.Parameters.ShouldBe([.. parameters]);
        result.Scope.ShouldBe(original.Scope);

        original.Parameters.ShouldBeEmpty();
    }
}