namespace MooVC.Syntax.CSharp.IndexerTests;

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
            Type = new() { Name = IndexerTestsData.DefaultParameterType },
        };

        // Act
        Indexer result = original.Accepts(parameter);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(result.Parameter).IsEqualTo(parameter);
        _ = await Assert.That(result.Result).IsEqualTo(original.Result);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }

    [Test]
    public async Task GivenUndefinedParameterThenClearsAllParameters()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create()
            .WithParameters(Parameter.Undefined.Named(ParameterName).OfType(typeof(int)));

        // Act
        Indexer result = original.Accepts(Parameter.Undefined);

        // Assert
        _ = await Assert.That(result.Parameters).IsEmpty();
        _ = await Assert.That(original.Parameters.Length).IsEqualTo(2);
    }
}