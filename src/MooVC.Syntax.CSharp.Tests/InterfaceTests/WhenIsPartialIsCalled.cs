namespace MooVC.Syntax.CSharp.InterfaceTests;

public sealed class WhenIsPartialIsCalled
{
    [Test]
    public async Task GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(isPartial: false);

        // Act
        Interface result = original.IsPartial(true);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.IsPartial).IsTrue();
        _ = await Assert.That(original.IsPartial).IsFalse();
    }
}