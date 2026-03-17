namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorMethodMethodIsCalled
{
    [Test]
    public void GivenEquivalentMethodsThenReturnsFalse()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create();

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentMethodsThenReturnsTrue()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeTrue();
    }
}