namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenAcceptsIsCalled
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
                Name = new Variable("other"),
                Type = new Symbol { Name = MethodTestsData.DefaultParameterType },
            },
        ];

        // Act
        Method result = original.Accepts(additional);

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