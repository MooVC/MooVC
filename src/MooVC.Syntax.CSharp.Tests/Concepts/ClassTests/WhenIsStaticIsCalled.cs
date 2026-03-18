namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

public sealed class WhenIsStaticIsCalled
{
    [Test]
    public async Task GivenIsStaticThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(isStatic: false);

        // Act
        Class result = original.IsStatic(true);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.IsStatic).IsTrue();
        await Assert.That(original.IsStatic).IsFalse();
    }
}