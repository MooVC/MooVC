namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Property { Name = new Name("Value"), Type = typeof(string) };
        var appended = new Property { Name = new Name("Other"), Type = typeof(int) };
        Record original = RecordTestsData.Create(properties: [existing]);

        // Act
        Record result = original.WithProperties(appended);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Properties).IsEquivalentTo([existing, appended]);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}