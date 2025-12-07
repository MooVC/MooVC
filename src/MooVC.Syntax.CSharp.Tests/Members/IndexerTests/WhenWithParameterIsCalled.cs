namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenWithParameterIsCalled
{
    [Fact]
    public void GivenParameterThenReturnsNewInstanceWithUpdatedParameter()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create();
        Parameter parameter = ParameterTestsData.Create(name: "updated");

        // Act
        Indexer result = original.WithParameter(parameter);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Parameter.ShouldBe(parameter);
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(original.Scope);
    }
}
