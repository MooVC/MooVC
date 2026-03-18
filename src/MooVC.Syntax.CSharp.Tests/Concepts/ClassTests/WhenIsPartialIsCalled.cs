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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.IsPartial).IsTrue();
        await Assert.That(original.IsPartial).IsFalse();
    }
}