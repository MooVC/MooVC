namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenWithParametersIsCalled
{
    [Fact]
    public void GivenParametersThenReturnsNewInstanceWithUpdatedParameters()
    {
        // Arrange
        Method original = MethodTestsData.Create();
        Parameter[] additional =
        [
            new Parameter
            {
                Name = new Identifier("other"),
                Type = new Symbol { Name = MethodTestsData.DefaultParameterType },
            },
        ];

        // Act
        Method result = original.WithParameters(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Name.ShouldBe(original.Name);
        result.Parameters.Length.ShouldBe(original.Parameters.Length + additional.Length);
        result.Parameters.ShouldBe(original.Parameters.Concat(additional));
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(original.Scope);
    }
}