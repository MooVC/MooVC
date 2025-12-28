namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithParameterIsCalled
{
    private const string ParameterName = "value";

    [Fact]
    public void GivenParameterThenReturnsNewInstanceWithUpdatedParameter()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create();

        var parameter = new Parameter
        {
            Name = ParameterName,
            Type = new Symbol { Name = IndexerTestsData.DefaultParameterType },
        };

        // Act
        Indexer result = original.WithParameter(parameter);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Parameter.ShouldBe(parameter);
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(original.Scope);
    }
}