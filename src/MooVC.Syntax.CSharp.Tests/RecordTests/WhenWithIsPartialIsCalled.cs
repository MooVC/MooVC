namespace MooVC.Syntax.CSharp.RecordTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.IsPartial).IsFalse();
        _ = await Assert.That(original.IsPartial).IsTrue();
    }
}