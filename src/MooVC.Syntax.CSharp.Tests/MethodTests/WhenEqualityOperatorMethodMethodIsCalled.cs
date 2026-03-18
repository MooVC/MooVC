namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenEqualityOperatorMethodMethodIsCalled
{
    [Test]
    public async Task GivenEquivalentMethodsThenReturnsTrue()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create();

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentMethodsThenReturnsFalse()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}