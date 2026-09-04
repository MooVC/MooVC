namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        var newName = new Declaration { Name = "Updated" };
        Record original = RecordTestsData.Create();

        // Act
        Record result = original.Named(newName);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Declaration).IsEqualTo(newName);
        _ = await Assert.That(original.Declaration).IsEqualTo(new Declaration { Name = RecordTestsData.DefaultName });
    }
}