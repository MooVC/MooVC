namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenAcceptsIsCalled
{
    private const string ParameterName = "value";

    [Test]
    public async Task GivenParameterThenReturnsNewInstanceWithUpdatedParameter()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create();

        var parameter = new Parameter
        {
            Name = ParameterName,
            Type = new Symbol { Name = IndexerTestsData.DefaultParameterType },
        };

        // Act
        Indexer result = original.Accepts(parameter);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(result.Parameter).IsEqualTo(parameter);
        await Assert.That(result.Result).IsEqualTo(original.Result);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}