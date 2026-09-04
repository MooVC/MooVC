namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenInequalityOperatorMethodMethodIsCalled
{
    [Test]
    public async Task GivenDifferentMethodsThenReturnsTrue()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentMethodsThenReturnsFalse()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create();

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}