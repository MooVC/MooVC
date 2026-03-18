namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

public sealed class WhenWithFieldsIsCalled
{
    [Test]
    public async Task GivenFieldsThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Field { Name = new Variable("_value"), Type = typeof(int) };
        var appended = new Field { Name = new Variable("_other"), Type = typeof(int) };
        Record original = RecordTestsData.Create(fields: [existing]);

        // Act
        Record result = original.WithFields(appended);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Fields).IsEquivalentTo([existing, appended]);
        _ = await Assert.That(result.Indexers).IsEqualTo(original.Indexers);
    }
}