namespace MooVC.Syntax.CSharp.StructTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.IsPartial).IsTrue();
        _ = await Assert.That(original.IsPartial).IsFalse();
    }
}