namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenWithParametersIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Parameter { Name = new("first"), Type = typeof(string) };
        var appended = new Parameter { Name = new("second"), Type = typeof(int) };
        Record original = RecordTestsData.Create(parameters: [existing]);

        // Act
        Record result = original.WithParameters(appended);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Parameters).IsEquivalentTo([existing, appended]);
        _ = await Assert.That(result.Properties).IsEqualTo(original.Properties);
    }
}