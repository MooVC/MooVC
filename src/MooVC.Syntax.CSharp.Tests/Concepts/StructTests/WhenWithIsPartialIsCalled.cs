namespace MooVC.Syntax.CSharp.Concepts.StructTests;

public sealed class WhenWithIsPartialIsCalled
{
    [Test]
    public async Task GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(isPartial: false);

        // Act
        Struct result = original.IsPartial(true);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.IsPartial).IsTrue();
        await Assert.That(original.IsPartial).IsFalse();
    }
}