namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenWithResultIsCalled
{
    [Fact]
    public void GivenResultThenReturnsNewInstanceWithUpdatedResult()
    {
        // Arrange
        Method original = MethodTestsData.Create();
        var result = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = "bool" },
        };

        // Act
        Method updated = original.WithResult(result);

        // Assert
        updated.ShouldNotBeSameAs(original);
        updated.Body.ShouldBe(original.Body);
        updated.Name.ShouldBe(original.Name);
        updated.Parameters.ShouldBe(original.Parameters);
        updated.Result.ShouldBe(result);
        updated.Scope.ShouldBe(original.Scope);
    }
}
