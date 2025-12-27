namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithFieldsIsCalled
{
    [Fact]
    public void GivenFieldsThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Field { Name = new Identifier("_value"), Type = typeof(int) };
        var appended = new Field { Name = new Identifier("_other"), Type = typeof(int) };
        Record original = RecordTestsData.Create(fields: [existing]);

        // Act
        Record result = original.WithFields(appended);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Fields.ShouldBe(new[] { existing, appended });
        result.Indexers.ShouldBe(original.Indexers);
    }
}