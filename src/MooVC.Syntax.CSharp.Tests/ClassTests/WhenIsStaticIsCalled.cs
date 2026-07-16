namespace MooVC.Syntax.CSharp.ClassTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.IsStatic).IsTrue();
        _ = await Assert.That(original.IsStatic).IsFalse();
    }
}