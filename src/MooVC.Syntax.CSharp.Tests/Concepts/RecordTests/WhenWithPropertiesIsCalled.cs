namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Properties).IsEqualTo(new[] { existing, appended });
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}