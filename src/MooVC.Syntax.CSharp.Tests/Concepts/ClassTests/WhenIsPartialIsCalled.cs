namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

public sealed class WhenIsPartialIsCalled
{
    [Test]
    public async Task GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(isPartial: false);

        // Act
        Class result = original.IsPartial(true);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.IsPartial).IsTrue();
        _ = await Assert.That(original.IsPartial).IsFalse();
    }
}