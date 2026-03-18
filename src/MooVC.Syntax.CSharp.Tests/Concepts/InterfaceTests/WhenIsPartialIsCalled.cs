namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.IsPartial).IsTrue();
        await Assert.That(original.IsPartial).IsFalse();
    }
}