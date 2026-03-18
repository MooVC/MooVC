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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Fields).IsEqualTo(new[] { existing, appended });
        _ = await Assert.That(result.Indexers).IsEqualTo(original.Indexers);
    }
}