namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

public sealed class WhenWithIsPartialIsCalled
{
    [Test]
    public async Task GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Record original = RecordTestsData.Create(isPartial: true);

        // Act
        Record result = original.IsPartial(false);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.IsPartial).IsFalse();
        await Assert.That(original.IsPartial).IsTrue();
    }
}