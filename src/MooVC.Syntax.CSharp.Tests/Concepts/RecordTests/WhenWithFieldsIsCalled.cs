namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Fields).IsEqualTo(new[] { existing, appended });
        await Assert.That(result.Indexers).IsEqualTo(original.Indexers);
    }
}